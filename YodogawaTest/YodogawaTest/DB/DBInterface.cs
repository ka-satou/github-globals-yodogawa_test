using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YodogawaTest.DB
{

	public interface IStationNoEntity
	{
		int StationNo { get; set; }
	}

	class DBInterface
	{
		/// <summary>
		/// コンテキストの取得。
		/// コンストラクタの中でDB接続文字列を変更するために引数付きのコンストラクタを呼び出す。
		/// </summary>
		/// <returns></returns>
		public static DBConnection GetConnection(TargetDB? targetDB = null) => DatabaseManager.Instance.GetDBConnection(targetDB);

		private static Dictionary<TargetDB, Task<int>> targetDBIfTaskMap{ get; set; } = new Dictionary<TargetDB, Task<int>>();


		/// <summary>
		/// ターゲットDB結果情報
		/// </summary>
		private static Dictionary<TargetDB, TaskCompletionSource<int>> targetDBResultMap{ get; set; } = new Dictionary<TargetDB, TaskCompletionSource<int>>();

		/// <summary>
		/// ターゲットDB通知情報
		/// </summary>
		private static Dictionary<TargetDB, TaskCompletionSource<int>> targetDBNotifyMap{ get; set; } = new Dictionary<TargetDB, TaskCompletionSource<int>>();


		private static Dictionary<TargetDB, DBEachInterface> dbInterfaceMap { get; set; } = new Dictionary<TargetDB, DBEachInterface>();

		/// <summary>
		/// ターゲットDBインターフェースクラスリスト
		/// </summary>
		private static List<DBEachInterface> _dbIfList;
		private static List<DBEachInterface> dbIfList 
		{ 
			get
			{
				if(_dbIfList == null)
				{
					_dbIfList = GetdbIfList();
				}
				return _dbIfList;
			}
		}

		private Task<int> MainUpdateTask { get; set; }

		private Type updateEntity { get; set; }

		private object DBUpdateLock { get; set; } = new object();


		/// <summary>
		/// ターゲットDBインターフェースクラス取得
		/// </summary>
		/// <returns></returns>
		private static List<DBEachInterface> GetdbIfList()
		{
			List<DBEachInterface> dbIfList = new List<DBEachInterface>();
			foreach (TargetDB targetDB in Enum.GetValues(typeof(TargetDB)))
			{
				DBEachInterface dBEach = new DBEachInterface(targetDB);
				dbIfList.Add(dBEach);
				dbInterfaceMap.Add(targetDB, dBEach);
			}
			return dbIfList;
		}

		/// <summary>
		/// 全データ取得
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public List<T> SelectAll<T>() where T : class
		{
			using (DBConnection connection = GetConnection())
			{
				List<T> list = DatabaseManager.Instance.GetEntities<T>(connection).ToList();
				return list;
			}
		}

		/// <summary>
		/// 施設番号リストで絞込
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="stations"></param>
		/// <returns></returns>
		public List<T> SelectAll<T>(List<int> stations) where T : class, IStationNoEntity
		{
			int data = WaitTargetDBUpdate<T>();
			using (DBConnection connection = GetConnection())
			{
				List<T> list = DatabaseManager.Instance.GetEntities<T>(connection)
					// 最後に施設番号で絞り込む
					.Where(v => stations.Contains(v.StationNo))
					.ToList();
				return list;
			}
		}

		/// <summary>
		/// 施設番号条件で更新
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="station"></param>
		/// <param name="updateData"></param>
//		public Task<int> UpdateAll<T>(int station, T updateData) where T : class, IStationNoEntity
		public void UpdateAll<T>(int station, T updateData) where T : class, IStationNoEntity
		{
			Debug.WriteLine("Main:StartUpdateData");
			Monitor.Enter(DBUpdateLock);	// 排他開始
			updateEntity = typeof(T);
			MainUpdateTask = Task.Run(() => UpdateAllTask<T>(station, updateData));
			Monitor.Exit(DBUpdateLock);		// 排他終了
			Debug.WriteLine("Main:EndUpdateData");
		}

		/// <summary>
		/// 施設番号条件で更新タスク
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="station"></param>
		/// <param name="updateData"></param>
		/// <returns></returns>
		public async Task<int> UpdateAllTask<T>(int station, T updateData) where T : class, IStationNoEntity
		{
			Debug.WriteLine("Main:StartUpdateDataTask");
			Task<int>[] tasks = new Task<int>[6]; 
			try
			{
				foreach(DBEachInterface dbIf in dbIfList)
				{
					TaskCompletionSource<int> targetDBResult = new TaskCompletionSource<int>();
					targetDBResultMap[dbIf.targetDB] = targetDBResult;
					TaskCompletionSource<int> targetDBNotify = new TaskCompletionSource<int>();
					targetDBNotifyMap[dbIf.targetDB] = targetDBNotify;
					targetDBIfTaskMap[dbIf.targetDB] = Task.Run(() => dbIf.UpdateData<T>(station, updateData, targetDBResult, targetDBNotify));
				}

				Debug.WriteLine("Main:AllTaskWaitIn");
				int[] dbResults = await Task.WhenAll(
												targetDBResultMap[TargetDB.Target1].Task, 
												targetDBResultMap[TargetDB.Target2].Task,
												targetDBResultMap[TargetDB.Target3].Task,
												targetDBResultMap[TargetDB.Target4].Task, 
												targetDBResultMap[TargetDB.Target5].Task,
												targetDBResultMap[TargetDB.Target6].Task
											);
				Debug.WriteLine("Main:AllTaskWaitOut");
				int notyfy = 0;
				foreach(int dbResult in dbResults)
				{
					if(dbResult == 0)
					{
						continue;
					}
					else
					{
						notyfy = 1;
						break;
					}
				}
				foreach(TargetDB targetDB in Enum.GetValues(typeof(TargetDB)))
				{
					Debug.WriteLine(DBEachInterface.strTargetDBMap[targetDB] + "NotifyIn");
					targetDBNotifyMap[targetDB].SetResult(notyfy);
					Debug.WriteLine(DBEachInterface.strTargetDBMap[targetDB] + "NotifyOut");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}

			Debug.WriteLine("Main:AllTaskExitWaitIn");
			int[] exitResults = await Task.WhenAll(
											targetDBIfTaskMap[TargetDB.Target1], 
											targetDBIfTaskMap[TargetDB.Target2],
											targetDBIfTaskMap[TargetDB.Target3],
											targetDBIfTaskMap[TargetDB.Target4], 
											targetDBIfTaskMap[TargetDB.Target5],
											targetDBIfTaskMap[TargetDB.Target6]
										);
			Debug.WriteLine("Main:AllTaskExitWaitOut");

			int result = 0;
			foreach(int exitResult in exitResults)
			{
				if(exitResult == 0)
				{
					continue;
				}
				else
				{
					result = 1;
					break;
				}
			}

#pragma warning disable 4014
			Task.Run(() => ExitUpdate());
#pragma warning restore 4014
			Debug.WriteLine("Main:EndUpdateDataTask");
			return result;
		}

		/// <summary>
		/// 更新後処理
		/// </summary>
		void ExitUpdate()
		{
			Debug.WriteLine("Main:StartExitUpdate");
			Monitor.Enter(DBUpdateLock);	// 排他開始
			while(!MainUpdateTask.IsCompleted)
			{
				Thread.Sleep(100);
			}
			MainUpdateTask = null;
			updateEntity = null;
			Monitor.Exit(DBUpdateLock);		// 排他終了
			Debug.WriteLine("Main:EndExitUpdate");
		}


		/// <summary>
		/// 更新処理完了待ち
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public int WaitTargetDBUpdate<T>()
		{
			Monitor.Enter(DBUpdateLock);	// 排他開始
			if(MainUpdateTask != null)
			{
				if(typeof(T) == updateEntity)
				{
					Monitor.Exit(DBUpdateLock);		// 排他終了
					Debug.WriteLine("ReadTask:WaitReadStart");
					int result = MainUpdateTask.Result;
					Debug.WriteLine("ReadTask:WaitReadEnd");
					return 0;
				}
			}
			Monitor.Exit(DBUpdateLock);				// 排他終了
			return 0;
		}

		/// <summary>
		/// src→targetでプロパティ全体をコピーする
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="target"></param>
		/// <param name="src"></param>
		public static void CopyProperyt<T>(T target, T src)
		{
			// 親クラスのプロパティ情報を一気に取得して使用する。
			List<PropertyInfo> props = src
				.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)?
				.ToList();

			props.ForEach(prop =>
			{
				var propValue = prop.GetValue(src);
				typeof(T).GetProperty(prop.Name).SetValue(target, propValue);
			});
		}

		/// <summary>
		/// DBインターフェースインスタンス
		/// </summary>
		private static DBInterface _instance;
		private static DBInterface Instance => _instance ?? (_instance = new DBInterface());

		/// <summary>
		/// 瞬時値データの取得
		/// </summary>
		/// <returns></returns>
		public static List<RecentDataEntity> FindRecentDataListBy(List<int> stations) => Instance.SelectAll<RecentDataEntity>(stations);

		/// <summary>
		/// 河川情報瞬時値データの取得
		/// </summary>
		/// <returns></returns>
		public static List<RecentRiverDataEntity> FindRecentRiverDataListBy(List<int> stations) => Instance.SelectAll<RecentRiverDataEntity>(stations);

		/// <summary>
		/// 計測値情報の取得
		/// </summary>
		/// <returns></returns>
		public static List<KeisokuDataInfoEntity> FindKeisokuDataInfoAll() => Instance.SelectAll<KeisokuDataInfoEntity>();

		/// <summary>
		/// 瞬時値データの更新
		/// </summary>
		/// <param name="station"></param>
		/// <param name="entity"></param>
		public static void UpdateRecentDataListBy(int station, RecentDataEntity entity) => Instance.UpdateAll<RecentDataEntity>(station, entity);

		/// <summary>
		/// 河川情報瞬時値データの更新
		/// </summary>
		/// <param name="station"></param>
		/// <param name="entity"></param>
		public static void UpdateRecentRiverDataListBy(int station, RecentRiverDataEntity entity) => Instance.UpdateAll<RecentRiverDataEntity>(station, entity);
	}
}
