using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest
{
	class GateContext : BaseContext
	{
		private static List<ValueInfo> valueInfos = new List<ValueInfo>
		{
			new ValueInfo{ StationNo = 1, EquipNo = 11, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 12, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 13, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 14, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 15, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 16, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 17, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 18, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 19, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 20, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 11, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 12, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 13, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 14, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 15, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 16, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 11, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 12, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 13, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 14, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 15, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 16, Point = 0, },
		};

		/// <summary>
		/// 計測データリスト作成
		/// </summary>
		/// <returns></returns>
		public List<KansokuData> CreateKansokuDataList()
		{
			List<KansokuData> kansokus = CreateKansokuDataList(valueInfos);
			return kansokus;
		}

		/// <summary>
		/// 計測データリスト更新
		/// </summary>
		/// <param name="updates"></param>
		public void UpdateKansokuDataList(List<UpdateData> updates)
		{
			UpdateKansokuDataList(valueInfos, updates);
		}
	}
}
