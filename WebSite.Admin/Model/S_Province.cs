/**  版本信息模板在安装目录下，可自行修改。
* S_Province.cs
*
* 功 能： N/A
* 类 名： S_Province
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
	/// S_Province:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_Province
	{
		public S_Province()
		{}
		#region Model
		private long _provinceid;
		private string _provincename;
		private DateTime? _datecreated;
		private DateTime? _dateupdated;
		/// <summary>
		/// 
		/// </summary>
		public long ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
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

