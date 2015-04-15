/**  版本信息模板在安装目录下，可自行修改。
* OrgUsers.cs
*
* 功 能： N/A
* 类 名： OrgUsers
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
	/// OrgUsers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgUsers
	{
		public OrgUsers()
		{}
		#region Model
		private int _uid;
		private int? _emplid;
		private string _username;
		private string _userpwd;
		private DateTime? _addtime;
		private int? _type;
		private int? _status;
		private DateTime? _lastlogintime;
		/// <summary>
		/// 
		/// </summary>
		public int UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
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
		public string UserPwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
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
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
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
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		#endregion Model

	}
}

