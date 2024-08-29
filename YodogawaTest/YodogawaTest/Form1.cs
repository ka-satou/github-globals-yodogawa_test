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








		public TestConsolForm()
		{
			InitializeComponent();
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
