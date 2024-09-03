using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest
{
	class DamContext : BaseContext
	{
		private static List<ValueInfo> valueInfos = new List<ValueInfo>
		{
			new ValueInfo{ StationNo = 11, EquipNo = 61, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 62, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 63, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 64, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 65, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 66, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 67, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 68, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 69, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 70, Point = 0, },
			new ValueInfo{ StationNo = 11, EquipNo = 71, Point = 0, },
		};

		public List<KansokuData> CreateKansokuDataList()
		{
			List<KansokuData> kansokus = CreateKansokuDataList(valueInfos);
			return kansokus;
		}
	}
}
