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
		/// s_no/e_noペアキー
		/// </summary>
		public class SNoENoKey
		{
			public int StationNo { get; set; }
			public int EquipNo { get ; set; }

			public SNoENoKey(int StationNo, int EquipNo)
			{
				this.StationNo = StationNo;
				this.EquipNo = EquipNo;
			}

			public override int GetHashCode()
			{
				return StationNo.GetHashCode() ^ EquipNo.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				var other = obj as SNoENoKey;
				if (other == null) return false;
				return (StationNo == other.StationNo) && (EquipNo == other.EquipNo);
			}
		}

		/// <summary>
		/// カラム名マップ
		/// </summary>
		private static Dictionary<SNoENoKey, CloumName> CloumMap { get; set; } = new Dictionary<SNoENoKey, CloumName>();

		/// <summary>
		/// データ増減変化マップ
		/// </summary>
		private static Dictionary<SNoENoKey, DataChangeMng> ChangeDataMap { get; set; } = new Dictionary<SNoENoKey, DataChangeMng>();

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

				// カラム名マップ作成
				foreach(KeisokuDataInfoEntity entity in keisokuList)
				{
					SNoENoKey key = new SNoENoKey(entity.StationNo, entity.EquipNo);
					string strDataNo = entity.DataNo.ToString();
					CloumName cloum = new CloumName{ StatusCloum = "Status" + strDataNo, ValueCloum = "Data" + strDataNo };
					CloumMap.Add(key, cloum);
				}
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

			CloumName cloum = GetCloumName(valueInfo.StationNo, valueInfo.EquipNo);

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
					SNoENoKey key = new SNoENoKey(valueInfo.StationNo, valueInfo.EquipNo);
					if(ChangeDataMap.ContainsKey(key))
					{
						changeMng = ChangeDataMap[key];
						changeMng.CurValue = value;
						result = changeMng.ValueChange;
						ChangeDataMap[key] = changeMng;
					}
					else
					{
						changeMng = new DataChangeMng();
						changeMng.StationNo = valueInfo.StationNo;
						changeMng.EquipNo = valueInfo.EquipNo;
						changeMng.ValueChange = DataChange.Horizon;
						changeMng.CurValue = value;
						changeMng.ChangeValue = ((value / 100) > 0)? (value / 100) : 1;
						ChangeDataMap[key] = changeMng;
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
			Dictionary<int, RecentDataEntity> recentUpdateList = new Dictionary<int, RecentDataEntity>();
			Dictionary<int, RecentRiverDataEntity> recentRiverUpdateList = new Dictionary<int, RecentRiverDataEntity>();

			List<RecentDataEntity> recents = null;
			List<RecentRiverDataEntity> recentRivers = null;
			RecentDataEntity selRecent = null;
			RecentRiverDataEntity selRecentRiver = null;

			recents = DBInterface.FindRecentDataListBy(recentList);
			recentRivers = DBInterface.FindRecentRiverDataListBy(recentRiverList);

			foreach (KeyValuePair<SNoENoKey, DataChangeMng> kvp in ChangeDataMap)
			{
				SNoENoKey key = kvp.Key;
				int station = key.StationNo;
				int equip = key.EquipNo;
				DataChangeMng dataChange = kvp.Value;

				if(station <= 7)
				{
					if (!recentUpdateList.ContainsKey(station))
					{
						selRecent = recents.Where(x => x.StationNo == station).FirstOrDefault();
					}
					else
					{
						selRecent = recentUpdateList[station];
					}
				}
				else
				{
					if (!recentRiverUpdateList.ContainsKey(station))
					{
						selRecentRiver = recentRivers.Where(x => x.StationNo == station).FirstOrDefault();
					}
					else
					{
						selRecentRiver = recentRiverUpdateList[station];
					}
				}
				CloumName cloum = GetCloumName(station, equip);
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
							recentUpdateList[station] = selRecent;
						}
						else
						{
							SetPropertyValue<RecentRiverDataEntity>(selRecentRiver, cloum.ValueCloum, changeValue);
							recentRiverUpdateList[station] = selRecentRiver;

						}
					}
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
				CloumName cloum = GetCloumName(valueInfo.StationNo, valueInfo.EquipNo);

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
				SNoENoKey key = new SNoENoKey(valueInfo.StationNo, valueInfo.EquipNo);
				if(ChangeDataMap.ContainsKey(key))
				{
					DataChangeMng changeMng = ChangeDataMap[key];
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
		/// カラム名取得
		/// </summary>
		/// <param name="StationNo"></param>
		/// <param name="EquipNo"></param>
		/// <returns></returns>
		private static CloumName GetCloumName(int StationNo, int EquipNo)
		{
			SNoENoKey key = new SNoENoKey(StationNo, EquipNo);
			CloumName cloum = CloumMap[key];
			return cloum;
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

			CloumName cloum = GetCloumName(valueInfo.StationNo, valueInfo.EquipNo);

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
