/**  版本信息模板在安装目录下，可自行修改。
* SYS_UserForRole.cs
*
* 功 能： N/A
* 类 名： SYS_UserForRole
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-07-27 12:23:10   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// SYS_UserForRole:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_UserForRole
	{
		public SYS_UserForRole()
		{}
		#region Model
		private int _ufr_id;
		private int? _adn_id;
		private int? _role_id;
		/// <summary>
		/// 
		/// </summary>
		public int UFR_Id
		{
			set{ _ufr_id=value;}
			get{return _ufr_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Adn_Id
		{
			set{ _adn_id=value;}
			get{return _adn_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Role_Id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		#endregion Model

	}
}

