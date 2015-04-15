/**  版本信息模板在安装目录下，可自行修改。
* FactroyInfo.cs
*
* 功 能： N/A
* 类 名： FactroyInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-11 09:58:18   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// FactroyInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FactroyInfo
	{
		public FactroyInfo()
		{}
		#region Model
		private int _fiid;
		private string _facname;
		private string _contact;
		private string _concell;
		private string _conaddr;
		private int? _status=0;
		private DateTime? _createdate= DateTime.Now;
		private string _area;
		private string _business;
		private string _qualificationlevel;
		private int? _factype;
		private int? _s_city;
		private int? _s_district;
		private int? _s_province;
		private bool _istop= false;
		private string _latlng;
		private string _password;
		private int? _sharecount=0;
		/// <summary>
		/// 
		/// </summary>
		public int FIID
		{
			set{ _fiid=value;}
			get{return _fiid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FacName
		{
			set{ _facname=value;}
			get{return _facname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConCell
		{
			set{ _concell=value;}
			get{return _concell;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConAddr
		{
			set{ _conaddr=value;}
			get{return _conaddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Business
		{
			set{ _business=value;}
			get{return _business;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QualificationLevel
		{
			set{ _qualificationlevel=value;}
			get{return _qualificationlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FacType
		{
			set{ _factype=value;}
			get{return _factype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? S_City
		{
			set{ _s_city=value;}
			get{return _s_city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? S_District
		{
			set{ _s_district=value;}
			get{return _s_district;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? S_Province
		{
			set{ _s_province=value;}
			get{return _s_province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string latlng
		{
			set{ _latlng=value;}
			get{return _latlng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShareCount
		{
			set{ _sharecount=value;}
			get{return _sharecount;}
		}
		#endregion Model

	}
}

