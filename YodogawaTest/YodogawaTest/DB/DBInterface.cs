﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
		public static DBConnection GetConnection(TargetDB? targetDB = null) => DatabaseManager.Instance.GetDBConnection(targetDB);


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

		private static List<DBEachInterface> GetdbIfList()
		{
			List<DBEachInterface> dbIfList = new List<DBEachInterface>();
			foreach (TargetDB targetDB in Enum.GetValues(typeof(TargetDB)))
			{
				DBEachInterface dBEach = new DBEachInterface(targetDB);
				dbIfList.Add(dBEach);
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
		public async Task<int> UpdateAll<T>(int station, T updateData) where T : class, IStationNoEntity
		{
			try
			{
				foreach(DBEachInterface dbIf in dbIfList)
				{
					await dbIf.UpdateData<T>(station, updateData);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
/*
			try
			{
				foreach (TargetDB targetDB in Enum.GetValues(typeof(TargetDB)))
				{
					using (DBConnection connection = GetConnection(targetDB))
					{
						var entities = DatabaseManager.Instance.GetEntities<T>(connection)
						.Where(v => v.StationNo == station)
						.FirstOrDefault();
						CopyProperyt<T>(entities, updateData);
						connection.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
*/
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
//		public static void UpdateRecentDataListBy(int station, RecentDataEntity entity) => Instance.UpdateAll<RecentDataEntity>(station, entity);
		public static async void UpdateRecentDataListBy(int station, RecentDataEntity entity) => await Instance.UpdateAll<RecentDataEntity>(station, entity);

		/// <summary>
		/// 河川情報瞬時値データの更新
		/// </summary>
		/// <param name="station"></param>
		/// <param name="entity"></param>
		public static async void UpdateRecentRiverDataListBy(int station, RecentRiverDataEntity entity) => await Instance.UpdateAll<RecentRiverDataEntity>(station, entity);
	}
}
