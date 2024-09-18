using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static YodogawaTest.DB.DBInterface;

namespace YodogawaTest.DB
{
	class DBEachInterface
	{
		/// <summary>
		/// ターゲットDB
		/// </summary>
		public TargetDB targetDB { get; set; }

		/// <summary>
		/// デバック表示用
		/// </summary>
		private string strTargetDB { get; set; }



		public class DBUpdateInfo
		{
			public Type							updateEntity { get; set; }
			public TaskCompletionSource<int>	Wait { get; set; }

		}

		/// <summary>
		/// ターゲットDB更新中
		/// </summary>
//		private static Dictionary<TargetDB, DBUpdateInfo> DBUpdateMap = new Dictionary<TargetDB, DBUpdateInfo>();
		public DBUpdateInfo dbUpdate { get; set; }

		/// <summary>
		/// ターゲットDB更新中排他オブジェクト
		/// </summary>
/*
		private static Dictionary<TargetDB, object> DBUpdateMapLockMap = new Dictionary<TargetDB, object>
		{
			{ TargetDB.Target1, new object() },
			{ TargetDB.Target2, new object() },
			{ TargetDB.Target3, new object() },
			{ TargetDB.Target4, new object() },
			{ TargetDB.Target5, new object() },
			{ TargetDB.Target6, new object() },
		};
*/
		private object DBUpdateLock { get; set; } = new object();

		/// <summary>
		/// デバック表示用マップ
		/// </summary>
		public static Dictionary<TargetDB, string> strTargetDBMap = new Dictionary<TargetDB, string>
		{
			{ TargetDB.Target1, "TARGET1DB:" },
			{ TargetDB.Target2, "TARGET2DB:" },
			{ TargetDB.Target3, "TARGET3DB:" },
			{ TargetDB.Target4, "TARGET4DB:" },
			{ TargetDB.Target5, "TARGET5DB:" },
			{ TargetDB.Target6, "TARGET6DB:" },
		};

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="targetDB"></param>
		public DBEachInterface(TargetDB targetDB)
		{
			this.targetDB = targetDB;
			strTargetDB = strTargetDBMap[targetDB];
		}

		public async Task<int> UpdateData<T>(
							int station,
							T updateData,
							TaskCompletionSource<int> targetDBResult,
							TaskCompletionSource<int> targetDBNotify
			) where T : class, IStationNoEntity
		{
			Debug.WriteLine(strTargetDB + "StartUpdateData");

			using (DBConnection connection = GetConnection(targetDB))
			using (var tran = connection.Database.BeginTransaction())
			{
				try
				{
//					connection.Database.Log = sql => { Debug.Write(strTargetDB + sql); };
					var entities = DatabaseManager.Instance.GetEntities<T>(connection)
					.Where(v => v.StationNo == station)
					.FirstOrDefault();
					CopyProperyt<T>(entities, updateData);
					connection.SaveChanges();
					Debug.WriteLine(strTargetDB + "Process0");
					targetDBResult.SetResult(0);
					Debug.WriteLine(strTargetDB + "Process1");
					int data = await targetDBNotify.Task;
					Debug.WriteLine(strTargetDB + "Process2");
					if(data == 0)
					{
						Debug.WriteLine(strTargetDB + "Commit");
						tran.Commit();
					}
					else
					{
						Debug.WriteLine(strTargetDB + "Rollback");
						tran.Rollback();
					}
				}
				catch
				{
					targetDBResult.SetResult(1);
					int data = await targetDBNotify.Task;
					tran.Rollback();
				}
			}
/*
			Monitor.Enter(DBUpdateLock);	// 排他開始
			if(dbUpdate != null)
			{
				dbUpdate.Wait.SetResult(0);
//				dbUpdate = null;
			}
			Monitor.Exit(DBUpdateLock);		// 排他停止
*/
			Debug.WriteLine(strTargetDB + "EndUpdateData");
			return 0;
		}

/*
		public async Task<int> WaitTargetDBUpdate<T>()
		{
			TargetDB selfTargetDB = DatabaseManager.Instance.GetSelfDB();
			Monitor.Enter(DBUpdateLock);	// 排他開始
			if(dbUpdate != null)
			{
//				DBUpdateInfo updateInfo = dbUpdate;
				if(typeof(T) == dbUpdate.updateEntity)
				{
					Monitor.Exit(DBUpdateLock);		// 排他終了
					Debug.WriteLine(strTargetDBMap[selfTargetDB] + "WaitReadStart");
					int a = await dbUpdate.Wait.Task;
//					dbUpdate = null;
					Debug.WriteLine(strTargetDBMap[selfTargetDB] + "WaitReadEnd");
					return 0;
				}
			}
			Monitor.Exit(DBUpdateLock);				// 排他終了
			return 0;
		}
*/

		/// <summary>
		/// DB更新情報取得
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetDBUpdateInfo<T>()
		{
			Monitor.Enter(DBUpdateLock);	// 排他開始
			dbUpdate = new DBUpdateInfo { updateEntity = typeof(T), Wait = new TaskCompletionSource<int>() };
			Monitor.Exit(DBUpdateLock);		// 排他停止
		}
	}
}
