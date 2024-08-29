using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest.DB
{
	[Table("t_set_keisoku")]
	class KeisokuDataInfoEntity
	{
		[Key]
		[Column("s_no", Order = 1)]
		public int StationNo { get; set; }
		[Key]
		[Column("data_no", Order = 2)]
		public int DataNo { get; set; }
		[Column("e_no")]
		public int EquipNo { get; set; }
		[Column("name")]
		public string Name { get; set; }
		[Column("len")]
		public int Len { get; set; }
		[Column("dp")]
		public int DecimalPoint { get; set; }
		[Column("unit")]
		public string Unit { get; set; }
	}
}
