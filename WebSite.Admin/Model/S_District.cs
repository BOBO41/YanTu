/**  版本信息模板在安装目录下，可自行修改。
* S_District.cs
*
* 功 能： N/A
* 类 名： S_District
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-09-27 09:51:44   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// S_District:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_District
	{
		public S_District()
		{}
		#region Model
		private long _districtid;
		private string _districtname;
		private long? _cityid;
		private DateTime? _datecreated;
		private DateTime? _dateupdated;
		/// <summary>
		/// 
		/// </summary>
		public long DistrictID
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DistrictName
		{
			set{ _districtname=value;}
			get{return _districtname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateCreated
		{
			set{ _datecreated=value;}
			get{return _datecreated;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateUpdated
		{
			set{ _dateupdated=value;}
			get{return _dateupdated;}
		}
		#endregion Model

	}
}

