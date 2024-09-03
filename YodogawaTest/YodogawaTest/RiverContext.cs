using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest
{
	class RiverContext : BaseContext
	{
		private static List<ValueInfo> valueInfos = new List<ValueInfo>
		{
			new ValueInfo{ StationNo = 8, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 42, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 43, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 44, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 45, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 46, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 47, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 48, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 49, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 50, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 51, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 52, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 54, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 58, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 61, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 62, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 64, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 65, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 66, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 69, Point = 0, },
			new ValueInfo{ StationNo = 8, EquipNo = 71, Point = 0, },
			new ValueInfo{ StationNo = 9, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 9, EquipNo = 42, Point = 0, },
			new ValueInfo{ StationNo = 9, EquipNo = 43, Point = 0, },
			new ValueInfo{ StationNo = 9, EquipNo = 46, Point = 0, },
			new ValueInfo{ StationNo = 9, EquipNo = 48, Point = 0, },
			new ValueInfo{ StationNo = 9, EquipNo = 49, Point = 0, },
			new ValueInfo{ StationNo = 9, EquipNo = 50, Point = 0, },
			new ValueInfo{ StationNo = 10, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 10, EquipNo = 42, Point = 0, },
			new ValueInfo{ StationNo = 10, EquipNo = 62, Point = 0, },
			new ValueInfo{ StationNo = 10, EquipNo = 63, Point = 0, },
			new ValueInfo{ StationNo = 10, EquipNo = 64, Point = 0, },
			new ValueInfo{ StationNo = 10, EquipNo = 65, Point = 0, },
			new ValueInfo{ StationNo = 12, EquipNo = 41, Point = 0, },
			new ValueInfo{ StationNo = 12, EquipNo = 61, Point = 0, },
		};

		public List<KansokuData> CreateKansokuDataList()
		{
			List<KansokuData> kansokus = CreateKansokuDataList(valueInfos);
			return kansokus;
		}
	}
}
