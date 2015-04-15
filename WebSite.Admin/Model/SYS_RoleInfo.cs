/**  版本信息模板在安装目录下，可自行修改。
* SYS_RoleInfo.cs
*
* 功 能： N/A
* 类 名： SYS_RoleInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-07-27 12:23:09   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// SYS_RoleInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_RoleInfo
	{
		public SYS_RoleInfo()
		{}
		#region Model
		private int _role_id;
		private string _role_name;
		private string _role_memo;
		private int? _role_status;
		private int? _role_issuper;
		private string _role_securityid;
		/// <summary>
		/// 
		/// </summary>
		public int Role_Id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Role_Name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Role_Memo
		{
			set{ _role_memo=value;}
			get{return _role_memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Role_Status
		{
			set{ _role_status=value;}
			get{return _role_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Role_IsSuper
		{
			set{ _role_issuper=value;}
			get{return _role_issuper;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Role_SecurityID
		{
			set{ _role_securityid=value;}
			get{return _role_securityid;}
		}
		#endregion Model

	}
}

