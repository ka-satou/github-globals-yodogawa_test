using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest.DB
{
	public enum TargetDB
	{
		Target1,
		Target2,
		Target3,
		Target4,
		Target5,
		Target6,
	}
	class DatabaseManager
	{
		public static readonly DatabaseManager Instance = new DatabaseManager();

		public const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";
		public const string DATE_FORMAT = "yyyyMMdd";
		public const string MONTH_FORMAT = "yyyyMM";
		public const string YEAR_FORMAT = "yyyy";
		public const string DATE_CONVERT_FORMAT = "00000000";
		public const string TIME_CONVERT_FORMAT = "000000";

		private TargetDB SelfDB;

		private readonly Dictionary<TargetDB, DBConnectionInfo> DBConnectionIfnoTable;
		private DatabaseManager()
		{
			DBConnectionIfnoTable = new Dictionary<TargetDB, DBConnectionInfo>();
			foreach (TargetDB targetDB in Enum.GetValues(typeof(TargetDB)))
			{
				string server = ConfigurationManager.AppSettings[$"{targetDB}.Server"];
				// サーバー名がない場合にはスキップ
				if (string.IsNullOrEmpty(server))
				{
					continue;
				}
				string port = ConfigurationManager.AppSettings[$"{targetDB}.Port"];
				// 
				if (string.IsNullOrEmpty(port))
				{
					port = "5432";
				}
				string database = ConfigurationManager.AppSettings[$"{targetDB}.Database"];
				if (string.IsNullOrEmpty(database))
				{
					database = "yodogawa_oozeki";
				}
				string userId = ConfigurationManager.AppSettings[$"{targetDB}.UserId"];
				if (string.IsNullOrEmpty(userId))
				{
					userId = "postgres";
				}
				string password = ConfigurationManager.AppSettings[$"{targetDB}.Password"];
				if (string.IsNullOrEmpty(password))
				{
					password = "admin@00";
				}
				string schema = ConfigurationManager.AppSettings[$"{targetDB}.Schema"];
				if (string.IsNullOrEmpty(schema))
				{
					schema = "public";
				}
				// 接続情報を生成
				DBConnectionIfnoTable.Add(targetDB, new DBConnectionInfo
				{
					Server = server,
					Port = port,
					Database = database,
					UserId = userId,
					Password = password,
					Schema = schema,
				});
			}
			// 自分のDB
			try
			{
				SelfDB = (TargetDB)Enum.Parse(typeof(TargetDB), ConfigurationManager.AppSettings[$"SelfDB"]);
			}
			catch (Exception)
			{
				// 指定がない場合は先頭とする
				SelfDB = TargetDB.Target1;
			}
		}

		public DBConnection GetDBConnection(TargetDB? targetDB = null)
		{
			if (!targetDB.HasValue)
			{
				targetDB = SelfDB;
			}
			if (DBConnectionIfnoTable.TryGetValue(targetDB.Value, out DBConnectionInfo dbConnectionInfo))
			{
				return new DBConnection(dbConnectionInfo);
			}
//			NLogManager.Error($"コネクションが取得できません（{targetDB.Value}）");
			return null;
		}

		public DbSet<T> GetEntities<T>(GetEntitiesFunc func) where T : class => func.Invoke() as DbSet<T>;
		public DbSet<T> GetEntities<T>(DBConnection connection) where T : class
		{
			if (connection.GetEntitiesTable.TryGetValue(typeof(T), out GetEntitiesFunc func))
			{
				return Instance.GetEntities<T>(func);
			}
//			NLogManager.Error($"DbSetが取得できません（{typeof(T)}）");
			return null;
		}
		/// <summary>
		/// 日付との変換
		/// DBのカラムの保存方式で変わってきてしまうためDataBaseManagerで処理することにする。
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static string DateTime2DateTimeString(DateTime dateTime) => dateTime.ToString(DATE_TIME_FORMAT);
		public static string DateTime2DateString(DateTime dateTime) => dateTime.ToString(DATE_FORMAT);
		public static string DateTime2MonthString(DateTime dateTime) => dateTime.ToString(MONTH_FORMAT);
		public static string DateTime2YearString(DateTime dateTime) => dateTime.ToString(YEAR_FORMAT);
		public static int DateTime2IntDate(DateTime dateTime) => int.Parse(DateTime2DateTimeString(dateTime).Substring(0, 8));
		public static int DateTime2IntTime(DateTime dateTime) => int.Parse(DateTime2DateTimeString(dateTime).Substring(8, 6));
		public static string Int2DateString(int value) => value.ToString(DATE_CONVERT_FORMAT);
		public static string Int2TimeString(int value) => value.ToString(TIME_CONVERT_FORMAT);
	}
}
