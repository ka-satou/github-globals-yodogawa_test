using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest.DB
{
	[Table("t_recent")]
	class RecentDataEntity : IStationNoEntity
	{
		[Column("date")]
		public int Date { get; set; }
		[Column("time")]
		public int Time { get; set; }
		[Key]
		[Column("dev_no", Order=1)]
		public int DeviceNo { get; set; }
		[Key]
		[Column("s_no", Order=2)]
		public int StationNo { get; set; }
		[Column("st1")]
		public int Status1 { get; set; }
		[Column("data1")]
		public int Data1 { get; set; }
		[Column("st2")]
		public int Status2 { get; set; }
		[Column("data2")]
		public int Data2 { get; set; }
		[Column("st3")]
		public int Status3 { get; set; }
		[Column("data3")]
		public int Data3 { get; set; }
		[Column("st4")]
		public int Status4 { get; set; }
		[Column("data4")]
		public int Data4 { get; set; }
		[Column("st5")]
		public int Status5 { get; set; }
		[Column("data5")]
		public int Data5 { get; set; }
		[Column("st6")]
		public int Status6 { get; set; }
		[Column("data6")]
		public int Data6 { get; set; }
		[Column("st7")]
		public int Status7 { get; set; }
		[Column("data7")]
		public int Data7 { get; set; }
		[Column("st8")]
		public int Status8 { get; set; }
		[Column("data8")]
		public int Data8 { get; set; }
		[Column("st9")]
		public int Status9 { get; set; }
		[Column("data9")]
		public int Data9 { get; set; }
		[Column("st10")]
		public int Status10 { get; set; }
		[Column("data10")]
		public int Data10 { get; set; }
		[Column("st11")]
		public int Status11 { get; set; }
		[Column("data11")]
		public int Data11 { get; set; }
		[Column("st12")]
		public int Status12 { get; set; }
		[Column("data12")]
		public int Data12 { get; set; }
		[Column("st13")]
		public int Status13 { get; set; }
		[Column("data13")]
		public int Data13 { get; set; }
		[Column("st14")]
		public int Status14 { get; set; }
		[Column("data14")]
		public int Data14 { get; set; }
		[Column("st15")]
		public int Status15 { get; set; }
		[Column("data15")]
		public int Data15 { get; set; }
		[Column("st16")]
		public int Status16 { get; set; }
		[Column("data16")]
		public int Data16 { get; set; }
		[Column("st17")]
		public int Status17 { get; set; }
		[Column("data17")]
		public int Data17 { get; set; }
		[Column("st18")]
		public int Status18 { get; set; }
		[Column("data18")]
		public int Data18 { get; set; }
		[Column("st19")]
		public int Status19 { get; set; }
		[Column("data19")]
		public int Data19 { get; set; }
		[Column("st20")]
		public int Status20 { get; set; }
		[Column("data20")]
		public int Data20 { get; set; }
		[Column("st21")]
		public int Status21 { get; set; }
		[Column("data21")]
		public int Data21 { get; set; }
		[Column("st22")]
		public int Status22 { get; set; }
		[Column("data22")]
		public int Data22 { get; set; }
		[Column("st23")]
		public int Status23 { get; set; }
		[Column("data23")]
		public int Data23 { get; set; }
		[Column("st24")]
		public int Status24 { get; set; }
		[Column("data24")]
		public int Data24 { get; set; }
		[Column("st25")]
		public int Status25 { get; set; }
		[Column("data25")]
		public int Data25 { get; set; }
		[Column("st26")]
		public int Status26 { get; set; }
		[Column("data26")]
		public int Data26 { get; set; }
		[Column("st27")]
		public int Status27 { get; set; }
		[Column("data27")]
		public int Data27 { get; set; }
		[Column("st28")]
		public int Status28 { get; set; }
		[Column("data28")]
		public int Data28 { get; set; }
		[Column("st29")]
		public int Status29 { get; set; }
		[Column("data29")]
		public int Data29 { get; set; }
		[Column("st30")]
		public int Status30 { get; set; }
		[Column("data30")]
		public int Data30 { get; set; }
		[Column("st31")]
		public int Status31 { get; set; }
		[Column("data31")]
		public int Data31 { get; set; }
		[Column("st32")]
		public int Status32 { get; set; }
		[Column("data32")]
		public int Data32 { get; set; }
		[Column("st33")]
		public int Status33 { get; set; }
		[Column("data33")]
		public int Data33 { get; set; }
		[Column("st34")]
		public int Status34 { get; set; }
		[Column("data34")]
		public int Data34 { get; set; }
		[Column("st35")]
		public int Status35 { get; set; }
		[Column("data35")]
		public int Data35 { get; set; }
		[Column("st36")]
		public int Status36 { get; set; }
		[Column("data36")]
		public int Data36 { get; set; }
		[Column("st37")]
		public int Status37 { get; set; }
		[Column("data37")]
		public int Data37 { get; set; }
		[Column("st38")]
		public int Status38 { get; set; }
		[Column("data38")]
		public int Data38 { get; set; }
		[Column("st39")]
		public int Status39 { get; set; }
		[Column("data39")]
		public int Data39 { get; set; }
		[Column("st40")]
		public int Status40 { get; set; }
		[Column("data40")]
		public int Data40 { get; set; }
		[Column("st41")]
		public int Status41 { get; set; }
		[Column("data41")]
		public int Data41 { get; set; }
		[Column("st42")]
		public int Status42 { get; set; }
		[Column("data42")]
		public int Data42 { get; set; }
		[Column("st43")]
		public int Status43 { get; set; }
		[Column("data43")]
		public int Data43 { get; set; }
		[Column("st44")]
		public int Status44 { get; set; }
		[Column("data44")]
		public int Data44 { get; set; }
		[Column("st45")]
		public int Status45 { get; set; }
		[Column("data45")]
		public int Data45 { get; set; }
		[Column("st46")]
		public int Status46 { get; set; }
		[Column("data46")]
		public int Data46 { get; set; }
		[Column("st47")]
		public int Status47 { get; set; }
		[Column("data47")]
		public int Data47 { get; set; }
		[Column("st48")]
		public int Status48 { get; set; }
		[Column("data48")]
		public int Data48 { get; set; }
		[Column("st49")]
		public int Status49 { get; set; }
		[Column("data49")]
		public int Data49 { get; set; }
		[Column("st50")]
		public int Status50 { get; set; }
		[Column("data50")]
		public int Data50 { get; set; }
		[Column("st51")]
		public int Status51 { get; set; }
		[Column("data51")]
		public int Data51 { get; set; }
		[Column("st52")]
		public int Status52 { get; set; }
		[Column("data52")]
		public int Data52 { get; set; }
		[Column("st53")]
		public int Status53 { get; set; }
		[Column("data53")]
		public int Data53 { get; set; }
		[Column("st54")]
		public int Status54 { get; set; }
		[Column("data54")]
		public int Data54 { get; set; }
		[Column("st55")]
		public int Status55 { get; set; }
		[Column("data55")]
		public int Data55 { get; set; }
		[Column("st56")]
		public int Status56 { get; set; }
		[Column("data56")]
		public int Data56 { get; set; }
		[Column("st57")]
		public int Status57 { get; set; }
		[Column("data57")]
		public int Data57 { get; set; }
		[Column("st58")]
		public int Status58 { get; set; }
		[Column("data58")]
		public int Data58 { get; set; }
		[Column("st59")]
		public int Status59 { get; set; }
		[Column("data59")]
		public int Data59 { get; set; }
		[Column("st60")]
		public int Status60 { get; set; }
		[Column("data60")]
		public int Data60 { get; set; }
		[Column("st61")]
		public int Status61 { get; set; }
		[Column("data61")]
		public int Data61 { get; set; }
		[Column("st62")]
		public int Status62 { get; set; }
		[Column("data62")]
		public int Data62 { get; set; }
		[Column("st63")]
		public int Status63 { get; set; }
		[Column("data63")]
		public int Data63 { get; set; }
		[Column("st64")]
		public int Status64 { get; set; }
		[Column("data64")]
		public int Data64 { get; set; }
		[Column("st65")]
		public int Status65 { get; set; }
		[Column("data65")]
		public int Data65 { get; set; }
		[Column("st66")]
		public int Status66 { get; set; }
		[Column("data66")]
		public int Data66 { get; set; }
		[Column("st67")]
		public int Status67 { get; set; }
		[Column("data67")]
		public int Data67 { get; set; }
		[Column("st68")]
		public int Status68 { get; set; }
		[Column("data68")]
		public int Data68 { get; set; }
		[Column("st69")]
		public int Status69 { get; set; }
		[Column("data69")]
		public int Data69 { get; set; }
		[Column("st70")]
		public int Status70 { get; set; }
		[Column("data70")]
		public int Data70 { get; set; }
		[Column("st71")]
		public int Status71 { get; set; }
		[Column("data71")]
		public int Data71 { get; set; }
		[Column("st72")]
		public int Status72 { get; set; }
		[Column("data72")]
		public int Data72 { get; set; }
		[Column("st73")]
		public int Status73 { get; set; }
		[Column("data73")]
		public int Data73 { get; set; }
		[Column("st74")]
		public int Status74 { get; set; }
		[Column("data74")]
		public int Data74 { get; set; }
		[Column("st75")]
		public int Status75 { get; set; }
		[Column("data75")]
		public int Data75 { get; set; }
		[Column("st76")]
		public int Status76 { get; set; }
		[Column("data76")]
		public int Data76 { get; set; }
		[Column("st77")]
		public int Status77 { get; set; }
		[Column("data77")]
		public int Data77 { get; set; }
		[Column("st78")]
		public int Status78 { get; set; }
		[Column("data78")]
		public int Data78 { get; set; }
		[Column("st79")]
		public int Status79 { get; set; }
		[Column("data79")]
		public int Data79 { get; set; }
		[Column("st80")]
		public int Status80 { get; set; }
		[Column("data80")]
		public int Data80 { get; set; }
		[Column("st81")]
		public int Status81 { get; set; }
		[Column("data81")]
		public int Data81 { get; set; }
		[Column("st82")]
		public int Status82 { get; set; }
		[Column("data82")]
		public int Data82 { get; set; }
		[Column("st83")]
		public int Status83 { get; set; }
		[Column("data83")]
		public int Data83 { get; set; }
		[Column("st84")]
		public int Status84 { get; set; }
		[Column("data84")]
		public int Data84 { get; set; }
		[Column("st85")]
		public int Status85 { get; set; }
		[Column("data85")]
		public int Data85 { get; set; }
		[Column("st86")]
		public int Status86 { get; set; }
		[Column("data86")]
		public int Data86 { get; set; }
		[Column("st87")]
		public int Status87 { get; set; }
		[Column("data87")]
		public int Data87 { get; set; }
		[Column("st88")]
		public int Status88 { get; set; }
		[Column("data88")]
		public int Data88 { get; set; }
		[Column("st89")]
		public int Status89 { get; set; }
		[Column("data89")]
		public int Data89 { get; set; }
		[Column("st90")]
		public int Status90 { get; set; }
		[Column("data90")]
		public int Data90 { get; set; }
		[Column("st91")]
		public int Status91 { get; set; }
		[Column("data91")]
		public int Data91 { get; set; }
		[Column("st92")]
		public int Status92 { get; set; }
		[Column("data92")]
		public int Data92 { get; set; }
		[Column("st93")]
		public int Status93 { get; set; }
		[Column("data93")]
		public int Data93 { get; set; }
		[Column("st94")]
		public int Status94 { get; set; }
		[Column("data94")]
		public int Data94 { get; set; }
		[Column("st95")]
		public int Status95 { get; set; }
		[Column("data95")]
		public int Data95 { get; set; }
		[Column("st96")]
		public int Status96 { get; set; }
		[Column("data96")]
		public int Data96 { get; set; }
		[Column("sv1")]
		public int SV1 { get; set; }
		[Column("sv2")]
		public int SV2 { get; set; }
		[Column("sv3")]
		public int SV3 { get; set; }
		[Column("sv4")]
		public int SV4 { get; set; }
		[Column("sv5")]
		public int SV5 { get; set; }
		[Column("sv6")]
		public int SV6 { get; set; }
		[Column("sv7")]
		public int SV7 { get; set; }
		[Column("sv8")]
		public int SV8 { get; set; }
		[Column("sv9")]
		public int SV9 { get; set; }
		[Column("sv10")]
		public int SV10 { get; set; }
		[Column("sv11")]
		public int SV11 { get; set; }
		[Column("sv12")]
		public int SV12 { get; set; }
		[Column("sv13")]
		public int SV13 { get; set; }
		[Column("sv14")]
		public int SV14 { get; set; }
		[Column("sv15")]
		public int SV15 { get; set; }
		[Column("sv16")]
		public int SV16 { get; set; }
		[Column("sv17")]
		public int SV17 { get; set; }
		[Column("sv18")]
		public int SV18 { get; set; }
		[Column("sv19")]
		public int SV19 { get; set; }
		[Column("sv20")]
		public int SV20 { get; set; }
		[Column("sv21")]
		public int SV21 { get; set; }
		[Column("sv22")]
		public int SV22 { get; set; }
		[Column("sv23")]
		public int SV23 { get; set; }
		[Column("sv24")]
		public int SV24 { get; set; }
		[Column("sv25")]
		public int SV25 { get; set; }
		[Column("sv26")]
		public int SV26 { get; set; }
		[Column("sv27")]
		public int SV27 { get; set; }
		[Column("sv28")]
		public int SV28 { get; set; }
		[Column("sv29")]
		public int SV29 { get; set; }
		[Column("sv30")]
		public int SV30 { get; set; }
		[Column("sv31")]
		public int SV31 { get; set; }
		[Column("sv32")]
		public int SV32 { get; set; }
		[Column("sv33")]
		public int SV33 { get; set; }
		[Column("sv34")]
		public int SV34 { get; set; }
		[Column("sv35")]
		public int SV35 { get; set; }
		[Column("sv36")]
		public int SV36 { get; set; }
		[Column("sv37")]
		public int SV37 { get; set; }
		[Column("sv38")]
		public int SV38 { get; set; }
		[Column("sv39")]
		public int SV39 { get; set; }
		[Column("sv40")]
		public int SV40 { get; set; }
		[Column("sv41")]
		public int SV41 { get; set; }
		[Column("sv42")]
		public int SV42 { get; set; }
		[Column("sv43")]
		public int SV43 { get; set; }
		[Column("sv44")]
		public int SV44 { get; set; }
		[Column("sv45")]
		public int SV45 { get; set; }
		[Column("sv46")]
		public int SV46 { get; set; }
		[Column("sv47")]
		public int SV47 { get; set; }
		[Column("sv48")]
		public int SV48 { get; set; }
		[Column("sv49")]
		public int SV49 { get; set; }
		[Column("sv50")]
		public int SV50 { get; set; }
		[Column("sv51")]
		public int SV51 { get; set; }
		[Column("sv52")]
		public int SV52 { get; set; }
		[Column("sv53")]
		public int SV53 { get; set; }
		[Column("sv54")]
		public int SV54 { get; set; }
		[Column("sv55")]
		public int SV55 { get; set; }
		[Column("sv56")]
		public int SV56 { get; set; }
		[Column("sv57")]
		public int SV57 { get; set; }
		[Column("sv58")]
		public int SV58 { get; set; }
		[Column("sv59")]
		public int SV59 { get; set; }
		[Column("sv60")]
		public int SV60 { get; set; }
		[Column("sv61")]
		public int SV61 { get; set; }
		[Column("sv62")]
		public int SV62 { get; set; }
		[Column("sv63")]
		public int SV63 { get; set; }
		[Column("sv64")]
		public int SV64 { get; set; }

		[NotMapped]
		public int RecordType { get; set; } = 2;
	}
}
