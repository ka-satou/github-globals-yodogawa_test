using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YodogawaTest.DB;

namespace YodogawaTest
{
	public class BaseContext
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
		/// 更新データ
		/// </summary>
		public class UpdateData
		{
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
		/// データ変化管理クラス
		/// </summary>
		public class DataChangeMng
		{
			public int StationNo { get; set; }
			public int EquipNo { get ; set; }
			public DataChange ValueChange { get; set; }
			public int CurValue { get ; set; }
			public int ChangeValue { get ; set; }
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
			{ 49, new CloumName{ StatusCloum = "Status35", ValueCloum = "Data35" }},
			{ 61, new CloumName{ StatusCloum = "Status37", ValueCloum = "Data37" }},
			{ 62, new CloumName{ StatusCloum = "Status38", ValueCloum = "Data38" }},
			{ 63, new CloumName{ StatusCloum = "Status39", ValueCloum = "Data39" }},
			{ 64, new CloumName{ StatusCloum = "Status40", ValueCloum = "Data40" }},
			{ 65, new CloumName{ StatusCloum = "Status41", ValueCloum = "Data41" }},
			{ 66, new CloumName{ StatusCloum = "Status42", ValueCloum = "Data42" }},
			{ 67, new CloumName{ StatusCloum = "Status43", ValueCloum = "Data43" }},
			{ 68, new CloumName{ StatusCloum = "Status44", ValueCloum = "Data44" }},
			{ 97, new CloumName{ StatusCloum = "Status76", ValueCloum = "Data76" }},
			{ 98, new CloumName{ StatusCloum = "Status77", ValueCloum = "Data77" }},
			{ 99, new CloumName{ StatusCloum = "Status78", ValueCloum = "Data78" }},
			{ 101, new CloumName{ StatusCloum = "Status79", ValueCloum = "Data79" }},
		};


		/// <summary>
		/// 毛馬閘門カラム情報
		/// </summary>
		private static Dictionary<int,CloumName> KemaKoumonMap { get; } = new Dictionary<int, CloumName>
		{
			{ 41, new CloumName{ StatusCloum = "Status27", ValueCloum = "Data27" }},
			{ 42, new CloumName{ StatusCloum = "Status28", ValueCloum = "Data28" }},
			{ 43, new CloumName{ StatusCloum = "Status29", ValueCloum = "Data29" }},
		};

		/// <summary>
		/// 毛馬水門カラム情報
		/// </summary>
		private static Dictionary<int,CloumName> KemaSuimonMap { get; } = new Dictionary<int, CloumName>
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
			{ 64, new CloumName{ StatusCloum = "Status43", ValueCloum = "Data43" }},
		};

		/// <summary>
		/// 毛馬閘門ゲートカラム情報
		/// </summary>
		private static Dictionary<int,CloumName> KemaKoumonGateMap { get; } = new Dictionary<int, CloumName>
		{
			{ 11, new CloumName{ StatusCloum = "Status1", ValueCloum = "Data1" }},
			{ 12, new CloumName{ StatusCloum = "Status2", ValueCloum = "Data2" }},
			{ 13, new CloumName{ StatusCloum = "Status3", ValueCloum = "Data3" }},
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
			{ 44, new CloumName{ StatusCloum = "Status30", ValueCloum = "Data30" }},
			{ 45, new CloumName{ StatusCloum = "Status31", ValueCloum = "Data31" }},
			{ 46, new CloumName{ StatusCloum = "Status32", ValueCloum = "Data32" }},
			{ 47, new CloumName{ StatusCloum = "Status33", ValueCloum = "Data33" }},
			{ 48, new CloumName{ StatusCloum = "Status34", ValueCloum = "Data34" }},
			{ 49, new CloumName{ StatusCloum = "Status35", ValueCloum = "Data35" }},
			{ 50, new CloumName{ StatusCloum = "Status36", ValueCloum = "Data36" }},
			{ 61, new CloumName{ StatusCloum = "Status40", ValueCloum = "Data40" }},
			{ 62, new CloumName{ StatusCloum = "Status41", ValueCloum = "Data41" }},
			{ 63, new CloumName{ StatusCloum = "Status42", ValueCloum = "Data42" }},
			{ 64, new CloumName{ StatusCloum = "Status43", ValueCloum = "Data43" }},
		};

		private static Dictionary<int,CloumName> River1Map { get; } = new Dictionary<int, CloumName>
		{
			{ 41, new CloumName{ StatusCloum = "Status201", ValueCloum = "Data201" }},
			{ 42, new CloumName{ StatusCloum = "Status202", ValueCloum = "Data202" }},
			{ 43, new CloumName{ StatusCloum = "Status203", ValueCloum = "Data203" }},
			{ 44, new CloumName{ StatusCloum = "Status204", ValueCloum = "Data204" }},
			{ 45, new CloumName{ StatusCloum = "Status205", ValueCloum = "Data205" }},
			{ 46, new CloumName{ StatusCloum = "Status206", ValueCloum = "Data206" }},
			{ 47, new CloumName{ StatusCloum = "Status207", ValueCloum = "Data207" }},
			{ 48, new CloumName{ StatusCloum = "Status208", ValueCloum = "Data208" }},
			{ 49, new CloumName{ StatusCloum = "Status209", ValueCloum = "Data209" }},
			{ 50, new CloumName{ StatusCloum = "Status210", ValueCloum = "Data210" }},
			{ 51, new CloumName{ StatusCloum = "Status211", ValueCloum = "Data211" }},
			{ 52, new CloumName{ StatusCloum = "Status212", ValueCloum = "Data212" }},
			{ 53, new CloumName{ StatusCloum = "Status213", ValueCloum = "Data213" }},
			{ 54, new CloumName{ StatusCloum = "Status214", ValueCloum = "Data214" }},
			{ 58, new CloumName{ StatusCloum = "Status218", ValueCloum = "Data218" }},
			{ 61, new CloumName{ StatusCloum = "Status219", ValueCloum = "Data219" }},
			{ 62, new CloumName{ StatusCloum = "Status220", ValueCloum = "Data220" }},
			{ 64, new CloumName{ StatusCloum = "Status222", ValueCloum = "Data222" }},
			{ 65, new CloumName{ StatusCloum = "Status223", ValueCloum = "Data223" }},
			{ 66, new CloumName{ StatusCloum = "Status224", ValueCloum = "Data224" }},
			{ 69, new CloumName{ StatusCloum = "Status227", ValueCloum = "Data227" }},
			{ 71, new CloumName{ StatusCloum = "Status229", ValueCloum = "Data229" }},
		};

		private static Dictionary<int,CloumName> River2Map { get; } = new Dictionary<int, CloumName>
		{
			{ 41, new CloumName{ StatusCloum = "Status201", ValueCloum = "Data201" }},
			{ 42, new CloumName{ StatusCloum = "Status202", ValueCloum = "Data202" }},
			{ 43, new CloumName{ StatusCloum = "Status203", ValueCloum = "Data203" }},
			{ 46, new CloumName{ StatusCloum = "Status206", ValueCloum = "Data206" }},
			{ 48, new CloumName{ StatusCloum = "Status208", ValueCloum = "Data208" }},
			{ 49, new CloumName{ StatusCloum = "Status209", ValueCloum = "Data209" }},
			{ 50, new CloumName{ StatusCloum = "Status210", ValueCloum = "Data210" }},
		};

		private static Dictionary<int,CloumName> River3Map { get; } = new Dictionary<int, CloumName>
		{
			{ 41, new CloumName{ StatusCloum = "Status201", ValueCloum = "Data201" }},
			{ 42, new CloumName{ StatusCloum = "Status202", ValueCloum = "Data202" }},
			{ 62, new CloumName{ StatusCloum = "Status220", ValueCloum = "Data220" }},
			{ 63, new CloumName{ StatusCloum = "Status221", ValueCloum = "Data221" }},
			{ 64, new CloumName{ StatusCloum = "Status222", ValueCloum = "Data222" }},
			{ 65, new CloumName{ StatusCloum = "Status223", ValueCloum = "Data223" }},
			{ 149, new CloumName{ StatusCloum = "Status236", ValueCloum = "Data236" }},
			{ 165, new CloumName{ StatusCloum = "Status240", ValueCloum = "Data240" }},
		};

		private static Dictionary<int,CloumName> River4Map { get; } = new Dictionary<int, CloumName>
		{
			{ 61, new CloumName{ StatusCloum = "Status219", ValueCloum = "Data219" }},
			{ 62, new CloumName{ StatusCloum = "Status220", ValueCloum = "Data220" }},
			{ 63, new CloumName{ StatusCloum = "Status221", ValueCloum = "Data221" }},
			{ 64, new CloumName{ StatusCloum = "Status222", ValueCloum = "Data222" }},
			{ 65, new CloumName{ StatusCloum = "Status223", ValueCloum = "Data223" }},
			{ 66, new CloumName{ StatusCloum = "Status224", ValueCloum = "Data224" }},
			{ 67, new CloumName{ StatusCloum = "Status225", ValueCloum = "Data225" }},
			{ 68, new CloumName{ StatusCloum = "Status226", ValueCloum = "Data226" }},
			{ 69, new CloumName{ StatusCloum = "Status227", ValueCloum = "Data227" }},
			{ 70, new CloumName{ StatusCloum = "Status228", ValueCloum = "Data228" }},
			{ 71, new CloumName{ StatusCloum = "Status229", ValueCloum = "Data229" }},
			{ 149, new CloumName{ StatusCloum = "Status236", ValueCloum = "Data236" }},
			{ 150, new CloumName{ StatusCloum = "Status244", ValueCloum = "Data244" }},
			{ 151, new CloumName{ StatusCloum = "Status252", ValueCloum = "Data252" }},
			{ 152, new CloumName{ StatusCloum = "Status260", ValueCloum = "Data260" }},
			{ 165, new CloumName{ StatusCloum = "Status240", ValueCloum = "Data240" }},
			{ 166, new CloumName{ StatusCloum = "Status248", ValueCloum = "Data248" }},
			{ 167, new CloumName{ StatusCloum = "Status256", ValueCloum = "Data256" }},
			{ 168, new CloumName{ StatusCloum = "Status264", ValueCloum = "Data264" }},
		};

		private static Dictionary<int,CloumName> River5Map { get; } = new Dictionary<int, CloumName>
		{
			{ 41, new CloumName{ StatusCloum = "Status201", ValueCloum = "Data201" }},
			{ 61, new CloumName{ StatusCloum = "Status219", ValueCloum = "Data219" }},
		};

		/// <summary>
		/// カラム情報マップ
		/// </summary>
		public static Dictionary<int, Dictionary<int,CloumName>> PropertyMap { get; } = new Dictionary<int, Dictionary<int, CloumName>>
		{
			{ 1, SekiMap },
			{ 2, KemaKoumonMap },
			{ 3, KemaSuimonMap },
			{ 4, KemaKoumonGateMap },
			{ 5, HitotuyaMap },
			{ 8, River1Map },
			{ 9, River2Map },
			{ 10, River3Map },
			{ 11, River4Map },
			{ 12, River5Map },
		};

		private static Dictionary<int, DataChangeMng> SekiChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		public static Dictionary<int, DataChangeMng> KemaKoumonChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		private static Dictionary<int, DataChangeMng> KemaSuimonChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		public static Dictionary<int, DataChangeMng> KemaKoumonGateChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		private static Dictionary<int, DataChangeMng> HitotuyaChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		private static Dictionary<int, DataChangeMng> River1ChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		private static Dictionary<int, DataChangeMng> River2ChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		private static Dictionary<int, DataChangeMng> River3ChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		private static Dictionary<int, DataChangeMng> River4ChangeData { get; set; } = new Dictionary<int, DataChangeMng>();
		private static Dictionary<int, DataChangeMng> River5ChangeData { get; set; } = new Dictionary<int, DataChangeMng>();


		public static Dictionary<int, Dictionary<int, DataChangeMng>> ChangeDataMap { get; } = new Dictionary<int, Dictionary<int, DataChangeMng>>
		{
			{ 1, SekiChangeData },
			{ 2, KemaKoumonChangeData },
			{ 3, KemaSuimonChangeData },
			{ 4, KemaKoumonGateChangeData },
			{ 5, HitotuyaChangeData },
			{ 8, River1ChangeData },
			{ 9, River2ChangeData },
			{ 10, River3ChangeData },
			{ 11, River4ChangeData },
			{ 12, River5ChangeData },
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
//				kansokuData.ValueChange = DataChange.Horizon;
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
						kansokuData.ValueChange = SetChangeDataMng<RecentDataEntity>(valueInfo, selRecents[0]);
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
						kansokuData.ValueChange = SetChangeDataMng<RecentRiverDataEntity>(valueInfo, selRecentRivers[0]);
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
			else if (valueInfo.Point == 1)
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

		/// <summary>
		/// プロパティへの値の設定
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <param name="columnName"></param>
		/// <param name="value"></param>
		public static void SetPropertyValue<T>(T data, string columnName, object value)
		{
			// プロパティ情報の取得
			if (typeof(T).GetProperty(columnName) is PropertyInfo propertyInfo)
			{
				// インスタンスの値を取得
				propertyInfo.SetValue(data, value);
			}
		}

		/// <summary>
		/// データ変化管理設定
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="valueInfo"></param>
		/// <param name="dataEntity"></param>
		/// <returns></returns>
		public DataChange SetChangeDataMng<T>(ValueInfo valueInfo, T dataEntity)
		{
			DataStatus Status = DataStatus.Invalid;
			DataChange result = DataChange.Horizon;
			DataChangeMng changeMng = null;

			Dictionary<int,CloumName> propMap = PropertyMap[valueInfo.StationNo];
			CloumName cloum = propMap[valueInfo.EquipNo];

			if(typeof(T).GetProperty(cloum.StatusCloum) is PropertyInfo propertyInfoStatus)
			{
				int status = (int)propertyInfoStatus.GetValue(dataEntity);
				Status = (DataStatus)status;
			}
			if(Status == DataStatus.Normal)
			{
				if(typeof(T).GetProperty(cloum.ValueCloum) is PropertyInfo propertyInfoValue)
				{
					int value = (int)propertyInfoValue.GetValue(dataEntity);
					Dictionary<int, DataChangeMng> changeData = ChangeDataMap[valueInfo.StationNo];
					if(changeData.ContainsKey(valueInfo.EquipNo))
					{
						changeMng = changeData[valueInfo.EquipNo];
						changeMng.CurValue = value;
						result = changeMng.ValueChange;
						changeData[valueInfo.EquipNo] = changeMng;
					}
					else
					{
						changeMng = new DataChangeMng();
						changeMng.StationNo = valueInfo.StationNo;
						changeMng.EquipNo = valueInfo.EquipNo;
						changeMng.ValueChange = DataChange.Horizon;
						changeMng.CurValue = value;
						changeMng.ChangeValue = ((value / 100) > 0)? (value / 100) : 1;
						changeData[valueInfo.EquipNo] = changeMng;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// データ変化更新
		/// </summary>
		public static void UpdateChangeData()
		{
			List<int> recentList = new List<int>(){1,2,3,4,5};
			List<int> recentRiverList = new List<int>(){8,9,10,11,12};

			List<RecentDataEntity> recents = null;
			List<RecentRiverDataEntity> recentRivers = null;
			RecentDataEntity selRecent = null;
			RecentRiverDataEntity selRecentRiver = null;

			recents = DBInterface.FindRecentDataListBy(recentList);
			recentRivers = DBInterface.FindRecentRiverDataListBy(recentRiverList);

			foreach (KeyValuePair<int, Dictionary<int, DataChangeMng>> kvp0 in ChangeDataMap)
			{
				int station = kvp0.Key;
				Dictionary<int, DataChangeMng> dataChangeMap = kvp0.Value;
				if(dataChangeMap.Count > 0)
				{
					if(station <= 7)
					{
						selRecent = recents.Where(x => x.StationNo == station).FirstOrDefault();
					}
					else
					{
						selRecentRiver = recentRivers.Where(x => x.StationNo == station).FirstOrDefault();
					}
					foreach (KeyValuePair<int, DataChangeMng> kvp1 in dataChangeMap)
					{
						int equip = kvp1.Key;
						DataChangeMng dataChange = kvp1.Value;
						Dictionary<int,CloumName> propMap = PropertyMap[station];
						CloumName cloum = propMap[equip];
						DataStatus valueStatus = DataStatus.Invalid;
						if(station <= 7)
						{
							if(typeof(RecentDataEntity).GetProperty(cloum.StatusCloum) is PropertyInfo propertyInfoStatus)
							{
								int status = (int)propertyInfoStatus.GetValue(selRecent);
								valueStatus = (DataStatus)status;
							}
						}
						else
						{
							if(typeof(RecentRiverDataEntity).GetProperty(cloum.StatusCloum) is PropertyInfo propertyInfoStatus)
							{
								int status = (int)propertyInfoStatus.GetValue(selRecentRiver);
								valueStatus = (DataStatus)status;
							}
						}
						if(valueStatus == DataStatus.Normal)
						{
							int changeValue = 0;
							if (dataChange.ValueChange == DataChange.Rise)
							{
								changeValue = dataChange.CurValue + dataChange.ChangeValue;
								 dataChange.CurValue = changeValue;
							}
							else if(dataChange.ValueChange == DataChange.Fall)
							{
								if(dataChange.CurValue >= dataChange.ChangeValue)
								{
									changeValue = dataChange.CurValue - dataChange.ChangeValue;
									dataChange.CurValue = changeValue;
								}
								else if(dataChange.CurValue >= 1)
								{
									dataChange.ChangeValue = 1;
									changeValue = dataChange.CurValue - dataChange.ChangeValue;
									dataChange.CurValue = changeValue;
								}
							}
							if((dataChange.ValueChange == DataChange.Rise) || (dataChange.ValueChange == DataChange.Fall))
							{
								if(station <= 7)
								{
									SetPropertyValue<RecentDataEntity>(selRecent, cloum.ValueCloum, changeValue);
								}
								else
								{
									SetPropertyValue<RecentRiverDataEntity>(selRecentRiver, cloum.ValueCloum, changeValue);
								}
							}
						}
					}
					if(station <= 7)
					{
						DBInterface.UpdateRecentDataListBy(station, selRecent);
					}
					else
					{
						DBInterface.UpdateRecentRiverDataListBy(station, selRecentRiver);
					}
				}
			}
		}

		/// <summary>
		/// 計測データリスト更新
		/// </summary>
		/// <param name="valueInfos"></param>
		/// <param name="updates"></param>
		public void UpdateKansokuDataList(List<ValueInfo> valueInfos, List<UpdateData> updates)
		{
			List<int> recentList = new List<int>(){1,2,3,4,5};
			List<int> recentRiverList = new List<int>(){8,9,10,11,12};
			Dictionary<int, RecentDataEntity> recentUpdateList = new Dictionary<int, RecentDataEntity>();
			Dictionary<int, RecentRiverDataEntity> recentRiverUpdateList = new Dictionary<int, RecentRiverDataEntity>();

			List<RecentDataEntity> recents = null;
			List<RecentRiverDataEntity> recentRivers = null;
			RecentDataEntity selRecent = null;
			RecentRiverDataEntity selRecentRiver = null;

			recents = DBInterface.FindRecentDataListBy(recentList);
			recentRivers = DBInterface.FindRecentRiverDataListBy(recentRiverList);

			foreach (var item in valueInfos.Zip(updates, (valueInfo, update) => new { valueInfo, update }))
			{
				ValueInfo valueInfo = item.valueInfo;
				UpdateData update = item.update;

				KeisokuDataInfoEntity keisokuInfo
					= keisokuList.Where(k => k.StationNo == valueInfo.StationNo && k.EquipNo == valueInfo.EquipNo).FirstOrDefault();
				valueInfo.Point = keisokuInfo.DecimalPoint;

				// データ値更新
				Dictionary<int,CloumName> propMap = PropertyMap[valueInfo.StationNo];
				CloumName cloum = propMap[valueInfo.EquipNo];

				if(valueInfo.StationNo <= 7)
				{
					if(!recentUpdateList.ContainsKey(valueInfo.StationNo))
					{
						selRecent = recents.Where(x => x.StationNo == valueInfo.StationNo).FirstOrDefault();
					}
					else
					{
						selRecent = recentUpdateList[valueInfo.StationNo];
					}
					UpdateValue<RecentDataEntity>(valueInfo, cloum, selRecent, update, recentUpdateList);
				}
				else
				{
					if(!recentRiverUpdateList.ContainsKey(valueInfo.StationNo))
					{
						selRecentRiver = recentRivers.Where(x => x.StationNo == valueInfo.StationNo).FirstOrDefault();
					}
					else
					{
						selRecentRiver = recentRiverUpdateList[valueInfo.StationNo];
					}
					UpdateValue<RecentRiverDataEntity>(valueInfo, cloum, selRecentRiver, update, recentRiverUpdateList);
				}

				// データチェンジモード更新
				Dictionary<int, DataChangeMng> changeMap = ChangeDataMap[valueInfo.StationNo];
				if (changeMap.ContainsKey(valueInfo.EquipNo))
				{
					DataChangeMng changeMng = changeMap[valueInfo.EquipNo];
					changeMng.ValueChange = update.ValueChange;
				}
			}
			// DBデータ更新
			foreach (KeyValuePair<int, RecentDataEntity> kvp in recentUpdateList)
			{
				int stationNo = kvp.Key;
				RecentDataEntity dataEntity = kvp.Value;
				DBInterface.UpdateRecentDataListBy(stationNo, dataEntity);
			}
			foreach (KeyValuePair<int, RecentRiverDataEntity> kvp in recentRiverUpdateList)
			{
				int stationNo = kvp.Key;
				RecentRiverDataEntity dataEntity = kvp.Value;
				DBInterface.UpdateRecentRiverDataListBy(stationNo, dataEntity);
			}
		}

		/// <summary>
		/// データ状態/データ値更新
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="valueInfo"></param>
		/// <param name="cloum"></param>
		/// <param name="data"></param>
		/// <param name="update"></param>
		/// <param name="updateList"></param>
		private void UpdateValue<T>(ValueInfo valueInfo, CloumName cloum,T data,UpdateData update,Dictionary<int,T> updateList)
		{
			if(typeof(T).GetProperty(cloum.StatusCloum) is PropertyInfo propertyInfoStatus)
			{
				int status = (int)propertyInfoStatus.GetValue(data);
				if((DataStatus)status != update.ValueStatus)
				{
					SetPropertyValue<T>(data, cloum.StatusCloum, update.ValueStatus);
					updateList[valueInfo.StationNo] = data;
				}
			}
			if(typeof(T).GetProperty(cloum.ValueCloum) is PropertyInfo propertyInfoValue)
			{
				int value = (int)propertyInfoValue.GetValue(data);
				int updateValue = GetNumValue(valueInfo, update.ValueUpdate);
				if(value != updateValue)
				{
					SetPropertyValue<T>(data, cloum.ValueCloum, updateValue);
					updateList[valueInfo.StationNo] = data;
				}
			}
		}

		/// <summary>
		/// データ数値取得
		/// </summary>
		/// <param name="valueInfo"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		int GetNumValue(ValueInfo valueInfo, string value)
		{
			int result = 0;
			if (valueInfo.Point == 2)
			{
				double data = double.Parse(value);
				data = data * 100;
				result = (int)data;
			}
			else if (valueInfo.Point == 1)
			{
				double data = double.Parse(value);
				data = data * 10;
				result = (int)data;
			}
			else
			{
				result = int.Parse(value);
			}
			return result;
		}
	}
}
