/**  版本信息模板在安装目录下，可自行修改。
* OrgEmployees.cs
*
* 功 能： N/A
* 类 名： OrgEmployees
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-30 19:03:04   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// OrgEmployees:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgEmployees
	{
		public OrgEmployees()
		{}
		#region Model
		private int _emplid;
		private long? _orgid;
		private string _emplname;
		private string _sex;
		private DateTime? _birthday;
		private string _homeaddress;
		private string _phone;
		private int? _status;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
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
		public string EmplName
		{
			set{ _emplname=value;}
			get{return _emplname;}
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
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
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
		public DateTime? Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

