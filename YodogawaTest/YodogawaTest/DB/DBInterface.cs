using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		protected DBConnection GetConnection(TargetDB? targetDB = null) => DatabaseManager.Instance.GetDBConnection(targetDB);

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
			using (DBConnection connection = GetConnection())
			{
				List<T> list = DatabaseManager.Instance.GetEntities<T>(connection)
					// 最後に施設番号で絞り込む
					.Where(v => stations.Contains(v.StationNo))
					.ToList();
				return list;
			}
		}


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
	}
}
