using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

		public async Task UpdateData<T>(
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
			Debug.WriteLine(strTargetDB + "EndUpdateData");
		}
	}
}
