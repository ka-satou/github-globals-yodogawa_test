using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest
{
	class RainContext : BaseContext
	{
		private static List<ValueInfo> valueInfos = new List<ValueInfo>
		{
			new ValueInfo{ StationNo = 10, EquipNo = 149, Point = 0, },
			new ValueInfo{ StationNo = 10, EquipNo = 165, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 149, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 150, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 151, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 152, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 165, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 166, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 167, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 168, Point = 0, },
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
