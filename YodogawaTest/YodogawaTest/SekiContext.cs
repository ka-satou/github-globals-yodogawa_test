using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest
{
	class SekiContext : BaseContext
	{
		private static List<ValueInfo> valueInfos = new List<ValueInfo>
		{
			new ValueInfo{ StationNo = 1, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 42, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 43, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 44, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 45, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 46, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 47, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 49, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 97, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 98, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 99, Point = 0, },
			new ValueInfo{ StationNo = 1, EquipNo = 101, Point = 0, },
			new ValueInfo{ StationNo = 2, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 2, EquipNo = 42, Point = 0, },
			new ValueInfo{ StationNo = 2, EquipNo = 43, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 42, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 43, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 44, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 45, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 46, Point = 0, },
			new ValueInfo{ StationNo = 3, EquipNo = 64, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 42, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 43, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 44, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 45, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 46, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 47, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 48, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 49, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 50, Point = 0, },
			new ValueInfo{ StationNo = 5, EquipNo = 64, Point = 0, },
//			new ValueInfo{ StationNo = 6, EquipNo = 61, Point = 0, },
		};

		public List<KansokuData> CreateKansokuDataList()
		{
			List<KansokuData> kansokus = CreateKansokuDataList(valueInfos);
			return kansokus;
		}
	}
}
