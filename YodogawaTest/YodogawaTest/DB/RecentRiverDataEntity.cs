using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodogawaTest.DB
{
	[Table("t_recent_river")]

	class RecentRiverDataEntity : IStationNoEntity
	{
		[Key]
		[Column("date", Order=1)]
		public int Date { get; set; }
		[Key]
		[Column("time", Order = 2)]
		public int Time { get; set; }
		[Key]
		[Column("dev_no", Order = 3)]
		public int DeviceNo { get; set; }
		[Key]
		[Column("s_no", Order = 4)]
		public int StationNo { get; set; }
		[Column("st201")]
		public int Status201 { get; set; }
		[Column("data201")]
		public int Data201 { get; set; }
		[Column("st202")]
		public int Status202 { get; set; }
		[Column("data202")]
		public int Data202 { get; set; }
		[Column("st203")]
		public int Status203 { get; set; }
		[Column("data203")]
		public int Data203 { get; set; }
		[Column("st204")]
		public int Status204 { get; set; }
		[Column("data204")]
		public int Data204 { get; set; }
		[Column("st205")]
		public int Status205 { get; set; }
		[Column("data205")]
		public int Data205 { get; set; }
		[Column("st206")]
		public int Status206 { get; set; }
		[Column("data206")]
		public int Data206 { get; set; }
		[Column("st207")]
		public int Status207 { get; set; }
		[Column("data207")]
		public int Data207 { get; set; }
		[Column("st208")]
		public int Status208 { get; set; }
		[Column("data208")]
		public int Data208 { get; set; }
		[Column("st209")]
		public int Status209 { get; set; }
		[Column("data209")]
		public int Data209 { get; set; }
		[Column("st210")]
		public int Status210 { get; set; }
		[Column("data210")]
		public int Data210 { get; set; }
		[Column("st211")]
		public int Status211 { get; set; }
		[Column("data211")]
		public int Data211 { get; set; }
		[Column("st212")]
		public int Status212 { get; set; }
		[Column("data212")]
		public int Data212 { get; set; }
		[Column("st213")]
		public int Status213 { get; set; }
		[Column("data213")]
		public int Data213 { get; set; }
		[Column("st214")]
		public int Status214 { get; set; }
		[Column("data214")]
		public int Data214 { get; set; }
		[Column("st215")]
		public int Status215 { get; set; }
		[Column("data215")]
		public int Data215 { get; set; }
		[Column("st216")]
		public int Status216 { get; set; }
		[Column("data216")]
		public int Data216 { get; set; }
		[Column("st217")]
		public int Status217 { get; set; }
		[Column("data217")]
		public int Data217 { get; set; }
		[Column("st218")]
		public int Status218 { get; set; }
		[Column("data218")]
		public int Data218 { get; set; }
		[Column("st219")]
		public int Status219 { get; set; }
		[Column("data219")]
		public int Data219 { get; set; }
		[Column("st220")]
		public int Status220 { get; set; }
		[Column("data220")]
		public int Data220 { get; set; }
		[Column("st221")]
		public int Status221 { get; set; }
		[Column("data221")]
		public int Data221 { get; set; }
		[Column("st222")]
		public int Status222 { get; set; }
		[Column("data222")]
		public int Data222 { get; set; }
		[Column("st223")]
		public int Status223 { get; set; }
		[Column("data223")]
		public int Data223 { get; set; }
		[Column("st224")]
		public int Status224 { get; set; }
		[Column("data224")]
		public int Data224 { get; set; }
		[Column("st225")]
		public int Status225 { get; set; }
		[Column("data225")]
		public int Data225 { get; set; }
		[Column("st226")]
		public int Status226 { get; set; }
		[Column("data226")]
		public int Data226 { get; set; }
		[Column("st227")]
		public int Status227 { get; set; }
		[Column("data227")]
		public int Data227 { get; set; }
		[Column("st228")]
		public int Status228 { get; set; }
		[Column("data228")]
		public int Data228 { get; set; }
		[Column("st229")]
		public int Status229 { get; set; }
		[Column("data229")]
		public int Data229 { get; set; }
		[Column("st230")]
		public int Status230 { get; set; }
		[Column("data230")]
		public int Data230 { get; set; }
		[Column("st231")]
		public int Status231 { get; set; }
		[Column("data231")]
		public int Data231 { get; set; }
		[Column("st232")]
		public int Status232 { get; set; }
		[Column("data232")]
		public int Data232 { get; set; }
		[Column("st233")]
		public int Status233 { get; set; }
		[Column("data233")]
		public int Data233 { get; set; }
		[Column("st234")]
		public int Status234 { get; set; }
		[Column("data234")]
		public int Data234 { get; set; }
		[Column("st235")]
		public int Status235 { get; set; }
		[Column("data235")]
		public int Data235 { get; set; }
		[Column("st236")]
		public int Status236 { get; set; }
		[Column("data236")]
		public int Data236 { get; set; }
		[Column("st237")]
		public int Status237 { get; set; }
		[Column("data237")]
		public int Data237 { get; set; }
		[Column("st238")]
		public int Status238 { get; set; }
		[Column("data238")]
		public int Data238 { get; set; }
		[Column("st239")]
		public int Status239 { get; set; }
		[Column("data239")]
		public int Data239 { get; set; }
		[Column("st240")]
		public int Status240 { get; set; }
		[Column("data240")]
		public int Data240 { get; set; }
		[Column("st241")]
		public int Status241 { get; set; }
		[Column("data241")]
		public int Data241 { get; set; }
		[Column("st242")]
		public int Status242 { get; set; }
		[Column("data242")]
		public int Data242 { get; set; }
		[Column("st243")]
		public int Status243 { get; set; }
		[Column("data243")]
		public int Data243 { get; set; }
		[Column("st244")]
		public int Status244 { get; set; }
		[Column("data244")]
		public int Data244 { get; set; }
		[Column("st245")]
		public int Status245 { get; set; }
		[Column("data245")]
		public int Data245 { get; set; }
		[Column("st246")]
		public int Status246 { get; set; }
		[Column("data246")]
		public int Data246 { get; set; }
		[Column("st247")]
		public int Status247 { get; set; }
		[Column("data247")]
		public int Data247 { get; set; }
		[Column("st248")]
		public int Status248 { get; set; }
		[Column("data248")]
		public int Data248 { get; set; }
		[Column("st249")]
		public int Status249 { get; set; }
		[Column("data249")]
		public int Data249 { get; set; }
		[Column("st250")]
		public int Status250 { get; set; }
		[Column("data250")]
		public int Data250 { get; set; }
		[Column("st251")]
		public int Status251 { get; set; }
		[Column("data251")]
		public int Data251 { get; set; }
		[Column("st252")]
		public int Status252 { get; set; }
		[Column("data252")]
		public int Data252 { get; set; }
		[Column("st253")]
		public int Status253 { get; set; }
		[Column("data253")]
		public int Data253 { get; set; }
		[Column("st254")]
		public int Status254 { get; set; }
		[Column("data254")]
		public int Data254 { get; set; }
		[Column("st255")]
		public int Status255 { get; set; }
		[Column("data255")]
		public int Data255 { get; set; }
		[Column("st256")]
		public int Status256 { get; set; }
		[Column("data256")]
		public int Data256 { get; set; }
		[Column("st257")]
		public int Status257 { get; set; }
		[Column("data257")]
		public int Data257 { get; set; }
		[Column("st258")]
		public int Status258 { get; set; }
		[Column("data258")]
		public int Data258 { get; set; }
		[Column("st259")]
		public int Status259 { get; set; }
		[Column("data259")]
		public int Data259 { get; set; }
		[Column("st260")]
		public int Status260 { get; set; }
		[Column("data260")]
		public int Data260 { get; set; }
		[Column("st261")]
		public int Status261 { get; set; }
		[Column("data261")]
		public int Data261 { get; set; }
		[Column("st262")]
		public int Status262 { get; set; }
		[Column("data262")]
		public int Data262 { get; set; }
		[Column("st263")]
		public int Status263 { get; set; }
		[Column("data263")]
		public int Data263 { get; set; }
		[Column("st264")]
		public int Status264 { get; set; }
		[Column("data264")]
		public int Data264 { get; set; }
		[Column("st265")]
		public int Status265 { get; set; }
		[Column("data265")]
		public int Data265 { get; set; }
		[Column("st266")]
		public int Status266 { get; set; }
		[Column("data266")]
		public int Data266 { get; set; }
		[Column("st267")]
		public int Status267 { get; set; }
		[Column("data267")]
		public int Data267 { get; set; }
		[Column("st268")]
		public int Status268 { get; set; }
		[Column("data268")]
		public int Data268 { get; set; }
		[Column("st269")]
		public int Status269 { get; set; }
		[Column("data269")]
		public int Data269 { get; set; }
		[Column("st270")]
		public int Status270 { get; set; }
		[Column("data270")]
		public int Data270 { get; set; }
		[Column("r_statime_st1")]
		public int RainStartTimeStatus1 { get; set; }
		[Column("r_statime1")]
		public int RainStartTime1 { get; set; }
		[Column("r_statime_st2")]
		public int RainStartTimeStatus2 { get; set; }
		[Column("r_statime2")]
		public int RainStartTime2 { get; set; }
		[Column("r_statime_st3")]
		public int RainStartTimeStatus3 { get; set; }
		[Column("r_statime3")]
		public int RainStartTime3 { get; set; }
		[Column("r_statime_st4")]
		public int RainStartTimeStatus4 { get; set; }
		[Column("r_statime4")]
		public int RainStartTime4 { get; set; }
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


		[NotMapped]
		public int RecordType { get; set; } = 2;
	}
}
