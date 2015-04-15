/**  版本信息模板在安装目录下，可自行修改。
* OrgCustomer.cs
*
* 功 能： N/A
* 类 名： OrgCustomer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-01-16 16:50:22   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// OrgCustomer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgCustomer
	{
		public OrgCustomer()
		{}
		#region Model
		private int _cid;
		private long? _orgid;
		private string _name;
		private string _sex;
		private DateTime? _birthday;
		private string _homeaddress;
		private string _selfcard;
		private DateTime? _addtime;
		private int? _status;
		private int? _uid;
		private string _username;
		private string _password;
		private string _mobile;
		/// <summary>
		/// 
		/// </summary>
		public int CId
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? OrgId
		{
			set{ _orgid=value;}
			get{return _orgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomeAddress
		{
			set{ _homeaddress=value;}
			get{return _homeaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SelfCard
		{
			set{ _selfcard=value;}
			get{return _selfcard;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		#endregion Model

	}
}

