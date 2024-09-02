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

		private DataTable valueStatusDS { get; set; } = new DataTable();
		private static List<string> valueStatusStrList  { get; set; } = new List<string>
		{
			"欠測", "正常", "点検", "異常", "データ異常", "無効"
		};
		private static List<DataStatus> valueStatusIdList  { get; set; } = new List<DataStatus>
		{
			DataStatus.Missing, DataStatus.Normal, DataStatus.Inspection, DataStatus.Abnormal, DataStatus.DataAbnormal, DataStatus.Invalid
		};
		public DataTable valueChangeDS  { get; set; } = new DataTable();
		private static List<string> valueChangeStrList  { get; set; } = new List<string>
		{
			"上昇", "下降", "水平"
		};
		private static List<DataChange> valueChangeIdList  { get; set; } = new List<DataChange>
		{
			DataChange.Rise, DataChange.Fall, DataChange.Horizon
		};


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
		}

		private void TestConsolForm_Load(object sender, EventArgs e)
		{
			ShowGridView();
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			int indx = tabControl.SelectedIndex;
			ShowGridView(indx);
		}

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

		private void ShowSekiGridView()
		{






		}


		private void ShowRiverGridView()
		{






		}


		private void ShowDamGridView()
		{






		}

		private void ShowRainGridView()
		{






		}


	}
}
