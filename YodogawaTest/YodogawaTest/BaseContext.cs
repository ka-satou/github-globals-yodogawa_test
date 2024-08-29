using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YodogawaTest.DB;

namespace YodogawaTest
{
	class BaseContext
	{
		/// <summary>
		/// データステータス
		/// </summary>
		public enum DataStatus
		{
			Missing,		// 欠測
			Normal,			// 正常
			Inspection,		// 点検
			Abnormal,		// 異常
			DataAbnormal,	// データ異常
			Invalid,		// 無効
		}

		/// <summary>
		/// データ変化種別
		/// </summary>
		public enum DataChange
		{
			Rise,			// 上昇
			Fall,			// 下降
			Horizon,		// 水平
		}

		/// <summary>
		/// 観測データ
		/// </summary>
		public class KansokuData
		{
			public string PointName { get; set; }
			public DataStatus ValueStatus { get; set; }
			public string ValueView { get; set; }
			public string ValueUpdate { get; set; }
			public DataChange ValueChange { get; set; }
		}

		/// <summary>
		/// 値情報
		/// </summary>
		public class ValueInfo
		{
			public int StationNo { get; set; }
			public int EquipNo { get ; set; }
			public int Point { get ; set; }
		}

		/// <summary>
		/// 値結果
		/// </summary>
		public class ValueResult
		{
			public DataStatus Status { get; set; }
			public string Value { get; set; }
		}

		/// <summary>
		/// カラム名
		/// </summary>
		public class CloumName
		{
			public string StatusCloum { get; set; }
			public string ValueCloum { get; set; }
		}


		/// <summary>
		/// 淀川大堰カラム情報
		/// </summary>
		private static Dictionary<int,CloumName> SekiMap { get; } = new Dictionary<int, CloumName>
		{
			{ 11, new CloumName{ StatusCloum = "Status1", ValueCloum = "Data1" }},
			{ 12, new CloumName{ StatusCloum = "Status2", ValueCloum = "Data2" }},
			{ 13, new CloumName{ StatusCloum = "Status3", ValueCloum = "Data3" }},
			{ 14, new CloumName{ StatusCloum = "Status4", ValueCloum = "Data4" }},
			{ 15, new CloumName{ StatusCloum = "Status5", ValueCloum = "Data5" }},
			{ 16, new CloumName{ StatusCloum = "Status6", ValueCloum = "Data6" }},
			{ 17, new CloumName{ StatusCloum = "Status7", ValueCloum = "Data7" }},
			{ 18, new CloumName{ StatusCloum = "Status8", ValueCloum = "Data8" }},
			{ 19, new CloumName{ StatusCloum = "Status9", ValueCloum = "Data9" }},
			{ 20, new CloumName{ StatusCloum = "Status10", ValueCloum = "Data10" }},
			{ 41, new CloumName{ StatusCloum = "Status27", ValueCloum = "Data27" }},
			{ 42, new CloumName{ StatusCloum = "Status28", ValueCloum = "Data28" }},
			{ 43, new CloumName{ StatusCloum = "Status29", ValueCloum = "Data29" }},
			{ 44, new CloumName{ StatusCloum = "Status30", ValueCloum = "Data30" }},
			{ 45, new CloumName{ StatusCloum = "Status31", ValueCloum = "Data31" }},
			{ 46, new CloumName{ StatusCloum = "Status32", ValueCloum = "Data32" }},
			{ 47, new CloumName{ StatusCloum = "Status33", ValueCloum = "Data33" }},
			{ 61, new CloumName{ StatusCloum = "Status37", ValueCloum = "Data37" }},
			{ 62, new CloumName{ StatusCloum = "Status38", ValueCloum = "Data38" }},
			{ 63, new CloumName{ StatusCloum = "Status39", ValueCloum = "Data39" }},
			{ 64, new CloumName{ StatusCloum = "Status40", ValueCloum = "Data40" }},
			{ 65, new CloumName{ StatusCloum = "Status41", ValueCloum = "Data41" }},
			{ 66, new CloumName{ StatusCloum = "Status42", ValueCloum = "Data42" }},
			{ 67, new CloumName{ StatusCloum = "Status43", ValueCloum = "Data43" }},
			{ 68, new CloumName{ StatusCloum = "Status44", ValueCloum = "Data44" }},
			{ 97, new CloumName{ StatusCloum = "Status73", ValueCloum = "Data73" }},
			{ 98, new CloumName{ StatusCloum = "Status74", ValueCloum = "Data74" }},
			{ 99, new CloumName{ StatusCloum = "Status75", ValueCloum = "Data75" }},
			{ 101, new CloumName{ StatusCloum = "Status76", ValueCloum = "Data75" }},
		};

		/// <summary>
		/// 毛馬水門カラム情報
		/// </summary>
		private static Dictionary<int,CloumName> KemaMap { get; } = new Dictionary<int, CloumName>
		{
			{ 11, new CloumName{ StatusCloum = "Status1", ValueCloum = "Data1" }},
			{ 12, new CloumName{ StatusCloum = "Status2", ValueCloum = "Data2" }},
			{ 13, new CloumName{ StatusCloum = "Status3", ValueCloum = "Data3" }},
			{ 14, new CloumName{ StatusCloum = "Status4", ValueCloum = "Data4" }},
			{ 15, new CloumName{ StatusCloum = "Status5", ValueCloum = "Data5" }},
			{ 16, new CloumName{ StatusCloum = "Status6", ValueCloum = "Data6" }},
			{ 41, new CloumName{ StatusCloum = "Status27", ValueCloum = "Data27" }},
			{ 42, new CloumName{ StatusCloum = "Status28", ValueCloum = "Data28" }},
			{ 43, new CloumName{ StatusCloum = "Status29", ValueCloum = "Data29" }},
			{ 44, new CloumName{ StatusCloum = "Status30", ValueCloum = "Data30" }},
			{ 45, new CloumName{ StatusCloum = "Status31", ValueCloum = "Data31" }},
			{ 46, new CloumName{ StatusCloum = "Status32", ValueCloum = "Data32" }},
			{ 61, new CloumName{ StatusCloum = "Status37", ValueCloum = "Data37" }},
			{ 62, new CloumName{ StatusCloum = "Status38", ValueCloum = "Data38" }},
			{ 63, new CloumName{ StatusCloum = "Status39", ValueCloum = "Data39" }},
			{ 64, new CloumName{ StatusCloum = "Status40", ValueCloum = "Data40" }},
		};

		/// <summary>
		/// 一津屋樋門カラム情報
		/// </summary>
		private static Dictionary<int,CloumName> HitotuyaMap { get; } = new Dictionary<int, CloumName>
		{
			{ 11, new CloumName{ StatusCloum = "Status1", ValueCloum = "Data1" }},
			{ 12, new CloumName{ StatusCloum = "Status2", ValueCloum = "Data2" }},
			{ 13, new CloumName{ StatusCloum = "Status3", ValueCloum = "Data3" }},
			{ 14, new CloumName{ StatusCloum = "Status4", ValueCloum = "Data4" }},
			{ 15, new CloumName{ StatusCloum = "Status5", ValueCloum = "Data5" }},
			{ 16, new CloumName{ StatusCloum = "Status6", ValueCloum = "Data6" }},
			{ 41, new CloumName{ StatusCloum = "Status27", ValueCloum = "Data27" }},
			{ 42, new CloumName{ StatusCloum = "Status28", ValueCloum = "Data28" }},
			{ 43, new CloumName{ StatusCloum = "Status29", ValueCloum = "Data29" }},
			{ 61, new CloumName{ StatusCloum = "Status37", ValueCloum = "Data37" }},
			{ 62, new CloumName{ StatusCloum = "Status38", ValueCloum = "Data38" }},
			{ 63, new CloumName{ StatusCloum = "Status39", ValueCloum = "Data39" }},
			{ 64, new CloumName{ StatusCloum = "Status40", ValueCloum = "Data40" }},
		};

		/// <summary>
		/// カラム情報マップ
		/// </summary>
		private static Dictionary<int, Dictionary<int,CloumName>> PropertyMap { get; } = new Dictionary<int, Dictionary<int, CloumName>>
		{
			{ 1, SekiMap },
			{ 3, KemaMap },
			{ 5, HitotuyaMap },
		};

		/// <summary>
		/// 計測情報リスト
		/// </summary>
		private static List<KeisokuDataInfoEntity> keisokuList { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public BaseContext()
		{
			if(keisokuList == null)
			{
				 keisokuList = DBInterface.FindKeisokuDataInfoAll();
			}
		}

		/// <summary>
		/// 計測データリスト生成
		/// </summary>
		/// <param name="valueInfos"></param>
		/// <returns></returns>
		public List<KansokuData> CreateKansokuDataList(List<ValueInfo> valueInfos)
		{
			List<KansokuData> kansokuDatas = new List<KansokuData>();
			List<int> stationList = new List<int>();
			List<RecentDataEntity> recents = null;
			List<RecentRiverDataEntity> recentRivers = null;
			List<RecentDataEntity> selRecents = null;
			List<RecentRiverDataEntity> selRecentRivers = null;


			foreach(ValueInfo valueInfo in valueInfos)
			{
				if(stationList.IndexOf(valueInfo.StationNo) == -1)
				{
					stationList.Add(valueInfo.StationNo);
				}
			}
			stationList.Sort();
			List<int> recentList = stationList.Where(x => x <= 7).ToList();
			List<int> recentRiverList = stationList.Where(x => x >= 8).ToList();
			if(recentList.Count > 0)
			{
				recents = DBInterface.FindRecentDataListBy(recentList);
			}
			if(recentRiverList.Count > 0)
			{
				recentRivers = DBInterface.FindRecentRiverDataListBy(recentRiverList);
			}

			foreach(ValueInfo valueInfo in valueInfos)
			{
				KansokuData kansokuData = new KansokuData();
				kansokuData.ValueChange = DataChange.Horizon;
				KeisokuDataInfoEntity keisokuInfo
					= keisokuList.Where(k => k.StationNo == valueInfo.StationNo && k.EquipNo == valueInfo.EquipNo).FirstOrDefault();
				kansokuData.PointName = keisokuInfo.Name;
				valueInfo.Point = keisokuInfo.DecimalPoint;
				if(valueInfo.StationNo <= 7)
				{
					selRecents = recents.Where(x => x.StationNo == valueInfo.StationNo).ToList();
					if(selRecents.Count == 1)
					{
						ValueResult result = GetValue<RecentDataEntity>(selRecents[0],valueInfo);
						kansokuData.ValueStatus = result.Status;
						kansokuData.ValueView = result.Value;
						kansokuData.ValueUpdate = result.Value;
					}
				}
				else
				{
					selRecentRivers = recentRivers.Where(x => x.StationNo == valueInfo.StationNo).ToList();
					if(selRecentRivers.Count == 1)
					{
						ValueResult result = GetValue<RecentRiverDataEntity>(selRecentRivers[0],valueInfo);
						kansokuData.ValueStatus = result.Status;
						kansokuData.ValueView = result.Value;
						kansokuData.ValueUpdate = result.Value;
					}
				}
				kansokuDatas.Add(kansokuData);
			}

			return kansokuDatas;
		}


		/// <summary>
		/// データ取得
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dataEntity"></param>
		/// <param name="valueInfo"></param>
		/// <returns></returns>
		public ValueResult GetValue<T>(T dataEntity, ValueInfo valueInfo)
		{
			ValueResult result = new ValueResult();

			Dictionary<int,CloumName> propMap = PropertyMap[valueInfo.StationNo];
			CloumName cloum = propMap[valueInfo.EquipNo];

			if(typeof(T).GetProperty(cloum.StatusCloum) is PropertyInfo propertyInfoStatus)
			{
				int status = (int)propertyInfoStatus.GetValue(dataEntity);
				result.Status = (DataStatus)status;
			}

			if(typeof(T).GetProperty(cloum.ValueCloum) is PropertyInfo propertyInfoValue)
			{
				int value = (int)propertyInfoValue.GetValue(dataEntity);
				result.Value = GetStringValue(valueInfo,value);
			}

			return result;
		}

		/// <summary>
		/// データ文字列取得
		/// </summary>
		/// <param name="valueInfo"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		string GetStringValue(ValueInfo valueInfo, int value)
		{
			string result = "";
			if (valueInfo.Point == 2)
			{
				double data = (double)value;
				data = data / 100;
				result = data.ToString("0.00");
			}
			if (valueInfo.Point == 1)
			{
				double data = (double)value;
				data = data / 10;
				result = data.ToString("0.0");
			}
			else
			{
				result = value.ToString("0");
			}
			return result;
		}
	}
}
