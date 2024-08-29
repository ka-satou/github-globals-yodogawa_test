using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest.DB
{
	public class DBConnectionInfo
	{
		public string Server { get; set; }
		public string Port { get; set; }
		public string Database { get; set; }
		public string UserId { get; set; }
		public string Password { get; set; }
		public string Schema { get; set; }
	}
	public delegate object GetEntitiesFunc();

	class DBConnection : DbContext
	{
	   #region 接続プロパティ
		/// <summary>
		/// テーブル接続情報。
		/// </summary>
		// 最新瞬時値
		public DbSet<RecentDataEntity> RecentDataDbSet { get; set; }
		public DbSet<RecentRiverDataEntity> RecentRiverDataDbSet { get; set; }
		public DbSet<KeisokuDataInfoEntity> KeisokuDataInfoDbSet { get; set; }

		/// <summary>
		/// エンティティクラスとDbSetのマッピングテーブル
		/// </summary>
		public Dictionary<Type, GetEntitiesFunc> GetEntitiesTable;

		/// <summary>
		/// 参照するスキーマ。
		/// </summary>
		public string DefaultSchema { get; private set; }

		#endregion

		#region イベント

		/// <summary>
		/// スキーマを変更したい場合はここで変更。
		/// 指定が無いとスキーマ名は『dbo』に設定される。
		/// </summary>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
			=> modelBuilder.HasDefaultSchema(DefaultSchema);

		#endregion

		#region メソッド

		/// <summary>
		/// コネクションの取得。
		/// </summary>
		/// <param name="userid">ユーザーID</param>
		/// <param name="password">パスワード</param>
		static NpgsqlConnection GetConnecting(string server, string port, string database, string userid, string password)
		{
			StringBuilder sb = new StringBuilder();
			_ = sb.Append($"Server={server};")
			.Append($"Port={port};")
			.Append($"Database={database};")
			.Append($"User Id={userid};")
			.Append($"Password={password};");
			return new NpgsqlConnection(sb.ToString());
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="server">接続サーバー。</param>
		/// <param name="port">接続ポート番号。</param>
		/// <param name="database">接続データベース。</param>
		/// <param name="userid">接続ID。</param>
		/// <param name="password">接続パスワード。</param>
		/// <param name="defaultSchema">接続先スキーマ。</param>
		public DBConnection(string server, string port, string database, string userid, string password, string defaultSchema)
			: base(GetConnecting(server, port, database, userid, password), true)
		{
			Init(defaultSchema);
		}
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="dBConnectionInfo"></param>
		public DBConnection(DBConnectionInfo dBConnectionInfo)
			: base(GetConnecting(dBConnectionInfo.Server, dBConnectionInfo.Port, dBConnectionInfo.Database, dBConnectionInfo.UserId, dBConnectionInfo.Password), true)
		{
			Init(dBConnectionInfo.Schema);
		}
		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="defaultSchema"></param>
		private void Init(string defaultSchema)
		{
			DefaultSchema = defaultSchema;

			GetEntitiesTable = new Dictionary<Type, GetEntitiesFunc>
			{
				{ typeof(RecentDataEntity), () => RecentDataDbSet },
				{ typeof(RecentRiverDataEntity), () => RecentRiverDataDbSet },
				{ typeof(KeisokuDataInfoEntity), () => KeisokuDataInfoDbSet },
			};
		}

		#endregion
	}
}
