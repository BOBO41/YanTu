/**  版本信息模板在安装目录下，可自行修改。
* UserPointDetail.cs
*
* 功 能： N/A
* 类 名： UserPointDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/7 15:54:36   N/A    初版
*
* 




*/

using System;

namespace WebSite.CM.Model
{
	/// <summary>
	/// UserPointDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserPointDetail
	{
		public UserPointDetail()
		{}
		#region Model
		private int _pdid;
		private int? _uid;
		private string _point;
		private DateTime? _datetime;
		private int? _flagtype;
		private decimal? _price;
		private int? _rdid;
		/// <summary>
		/// 
		/// </summary>
		public int PDID
		{
			set{ _pdid=value;}
			get{return _pdid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Point
		{
			set{ _point=value;}
			get{return _point;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Datetime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FlagType
		{
			set{ _flagtype=value;}
			get{return _flagtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RDID
		{
			set{ _rdid=value;}
			get{return _rdid;}
		}
		#endregion Model

	}
}

