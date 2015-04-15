/**  版本信息模板在安装目录下，可自行修改。
* OrgCustomerAddress.cs
*
* 功 能： N/A
* 类 名： OrgCustomerAddress
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-01-18 14:49:01   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// OrgCustomerAddress:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgCustomerAddress
	{
		public OrgCustomerAddress()
		{}
		#region Model
		private int _caid;
		private int? _cid;
		private string _province;
		private string _city;
		private string _county;
		private string _address;
		private string _recivename;
		private string _recivephone;
		private int? _isdefault;
		private DateTime? _addtime;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int CAId
		{
			set{ _caid=value;}
			get{return _caid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CId
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string County
		{
			set{ _county=value;}
			get{return _county;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReciveName
		{
			set{ _recivename=value;}
			get{return _recivename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecivePhone
		{
			set{ _recivephone=value;}
			get{return _recivephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

