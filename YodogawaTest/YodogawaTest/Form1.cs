using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YodogawaTest.DB;
using static YodogawaTest.BaseContext;

namespace YodogawaTest
{
	public partial class TestConsolForm : Form
	{
		/// <summary>
		/// 値ステータスリストボックスデータソース一式
		/// </summary>
		private DataTable valueStatusDS { get; set; } = new DataTable();
		private static List<string> valueStatusStrList { get; set; } = new List<string>
		{
			"欠測", "正常", "点検", "異常", "データ異常", "無効"
		};
		private static List<DataStatus> valueStatusIdList { get; set; } = new List<DataStatus>
		{
			DataStatus.Missing, DataStatus.Normal, DataStatus.Inspection, DataStatus.Abnormal, DataStatus.DataAbnormal, DataStatus.Invalid
		};

		/// <summary>
		/// 値変化リストボックスデータソース一式
		/// </summary>
		public DataTable valueChangeDS { get; set; } = new DataTable();
		private static List<string> valueChangeStrList { get; set; } = new List<string>
		{
			"上昇", "下降", "水平"
		};
		private static List<DataChange> valueChangeIdList  { get; set; } = new List<DataChange>
		{
			DataChange.Rise, DataChange.Fall, DataChange.Horizon
		};

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TestConsolForm()
		{
			InitializeComponent();

			// ValueStatus
			valueStatusDS.Columns.Add("name", typeof(string));
			valueStatusDS.Columns.Add("id", typeof(DataStatus));
			for(int index = 0;index < 6;index++)
			{
				DataRow dr = valueStatusDS.NewRow();
				dr["name"] = valueStatusStrList[index];
				dr["id"] = valueStatusIdList[index];
				valueStatusDS.Rows.Add(dr);
			}
			gateValueStatus.DataSource = valueStatusDS;
			gateValueStatus.DisplayMember = "name";
			gateValueStatus.ValueMember = "id";
			sekiValueStatus.DataSource = valueStatusDS;
			sekiValueStatus.DisplayMember = "name";
			sekiValueStatus.ValueMember = "id";
			riverValueStatus.DataSource = valueStatusDS;
			riverValueStatus.DisplayMember = "name";
			riverValueStatus.ValueMember = "id";
			damValueStatus.DataSource = valueStatusDS;
			damValueStatus.DisplayMember = "name";
			damValueStatus.ValueMember = "id";
			rainValueStatus.DataSource = valueStatusDS;
			rainValueStatus.DisplayMember = "name";
			rainValueStatus.ValueMember = "id";

			// ValueChange
			valueChangeDS.Columns.Add("name", typeof(string));
			valueChangeDS.Columns.Add("id", typeof(DataChange));
			for(int index = 0;index < 3;index++)
			{
				DataRow dr = valueChangeDS.NewRow();
				dr["name"] = valueChangeStrList[index];
				dr["id"] = valueChangeIdList[index];
				valueChangeDS.Rows.Add(dr);
			}
			gateValueChange.DataSource = valueChangeDS;
			gateValueChange.DisplayMember = "name";
			gateValueChange.ValueMember = "id";
			sekiValueChange.DataSource = valueChangeDS;
			sekiValueChange.DisplayMember = "name";
			sekiValueChange.ValueMember = "id";
			riverValueChange.DataSource = valueChangeDS;
			riverValueChange.DisplayMember = "name";
			riverValueChange.ValueMember = "id";
			damValueChange.DataSource = valueChangeDS;
			damValueChange.DisplayMember = "name";
			damValueChange.ValueMember = "id";
			rainValueChange.DataSource = valueChangeDS;
			rainValueChange.DisplayMember = "name";
			rainValueChange.ValueMember = "id";
		}

		/// <summary>
		/// 初期画面表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TestConsolForm_Load(object sender, EventArgs e)
		{
			ShowGridView();
		}

		/// <summary>
		/// タブコントールチェンジ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			int indx = tabControl.SelectedIndex;
			ShowGridView(indx);
		}

		/// <summary>
		/// 一覧表表示
		/// </summary>
		/// <param name="indx"></param>
		private void ShowGridView(int indx = 0)
		{
			switch(indx)
			{
			case 0:
				ShowGateGridView();
				break;
			case 1:
				ShowSekiGridView();
				break;
			case 2:
				ShowRiverGridView();
				break;
			case 3:
				ShowDamGridView();
				break;
			case 4:
				ShowRainGridView();
				break;
			}
		}

		/// <summary>
		/// ゲート一覧表示
		/// </summary>
		private void ShowGateGridView()
		{
			GateContext context = new GateContext();
			List<KansokuData> kansokus = context.CreateKansokuDataList();
			gateDataGridView.Rows.Clear();
			foreach(KansokuData kansoku in kansokus)
			{
				gateDataGridView.Rows.Add(kansoku.PointName,kansoku.ValueStatus,kansoku.ValueView,kansoku.ValueUpdate,kansoku.ValueChange);
			}
		}

		/// <summary>
		/// 大堰周辺一覧表示
		/// </summary>
		private void ShowSekiGridView()
		{
			SekiContext context = new SekiContext();
			List<KansokuData> kansokus = context.CreateKansokuDataList();
			sekiDataGridView.Rows.Clear();
			foreach(KansokuData kansoku in kansokus)
			{
				sekiDataGridView.Rows.Add(kansoku.PointName,kansoku.ValueStatus,kansoku.ValueView,kansoku.ValueUpdate,kansoku.ValueChange);
			}
		}

		/// <summary>
		/// 河川一覧表示
		/// </summary>
		private void ShowRiverGridView()
		{
			RiverContext context = new RiverContext();
			List<KansokuData> kansokus = context.CreateKansokuDataList();
			riverDataGridView.Rows.Clear();
			foreach(KansokuData kansoku in kansokus)
			{
				riverDataGridView.Rows.Add(kansoku.PointName,kansoku.ValueStatus,kansoku.ValueView,kansoku.ValueUpdate,kansoku.ValueChange);
			}
		}

		/// <summary>
		/// ダム一覧表示
		/// </summary>
		private void ShowDamGridView()
		{
			DamContext context = new DamContext();
			List<KansokuData> kansokus = context.CreateKansokuDataList();
			damDataGridView.Rows.Clear();
			foreach(KansokuData kansoku in kansokus)
			{
				damDataGridView.Rows.Add(kansoku.PointName,kansoku.ValueStatus,kansoku.ValueView,kansoku.ValueUpdate,kansoku.ValueChange);
			}
		}

		/// <summary>
		/// 雨量一覧表示
		/// </summary>
		private void ShowRainGridView()
		{
			RainContext context = new RainContext();
			List<KansokuData> kansokus = context.CreateKansokuDataList();
			rainDataGridView.Rows.Clear();
			foreach(KansokuData kansoku in kansokus)
			{
				rainDataGridView.Rows.Add(kansoku.PointName,kansoku.ValueStatus,kansoku.ValueView,kansoku.ValueUpdate,kansoku.ValueChange);
			}
		}

		/// <summary>
		/// データリフレシュ開始/停止
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void refreshButton_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkBox = (CheckBox)sender; 
			if(chkBox.Checked == true)
			{
				// データリフレシュタイマー開始
			}
			else
			{
				// データリフレシュタイマー停止
			}
		}

		/// <summary>
		/// データ更新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void updateButton_Click(object sender, EventArgs e)
		{
			UpdateChangeData();
		}
	}
}
