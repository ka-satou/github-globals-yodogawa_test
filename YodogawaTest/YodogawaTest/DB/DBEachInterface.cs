using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest.DB
{
	class DBEachInterface
	{
		/// <summary>
		/// ターゲットDB
		/// </summary>
		private TargetDB targetDB { get; set; }

		/// <summary>
		/// デバック表示用
		/// </summary>
		private string strTargetDB { get; set; }

		/// <summary>
		/// デバック表示用マップ
		/// </summary>
		private static Dictionary<TargetDB, string> strTargetDBMap = new Dictionary<TargetDB, string>
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

		public Task<int> UpdateData<T>(int station, T updateData) where T : class, IStationNoEntity
		{
			int result = 0;
			using (DBConnection connection = DBInterface.GetConnection(targetDB))
			using (var tran = connection.Database.BeginTransaction())
			{
				try
				{
					connection.Database.Log = sql => { Debug.Write(strTargetDB + sql); };
					var entities = DatabaseManager.Instance.GetEntities<T>(connection)
					.Where(v => v.StationNo == station)
					.FirstOrDefault();
					DBInterface.CopyProperyt<T>(entities, updateData);
					connection.SaveChanges();
					
					tran.Commit();
				}
				catch
				{
					tran.Rollback();
					
				}
			}
			return Task.FromResult(result);
		}
	}
}
