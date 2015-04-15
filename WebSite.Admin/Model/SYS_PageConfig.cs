/**  版本信息模板在安装目录下，可自行修改。
* SYS_PageConfig.cs
*
* 功 能： N/A
* 类 名： SYS_PageConfig
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
	/// SYS_PageConfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_PageConfig
	{
		public SYS_PageConfig()
		{}
		#region Model
		private int _pc_id;
		private string _pc_name;
		private string _pc_memo;
		private string _pc_hrefurl;
		private int? _pc_havechild;
		private int? _pc_parentid;
		private int? _pc_state=1;
		/// <summary>
		/// 
		/// </summary>
		public int PC_Id
		{
			set{ _pc_id=value;}
			get{return _pc_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PC_Name
		{
			set{ _pc_name=value;}
			get{return _pc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PC_Memo
		{
			set{ _pc_memo=value;}
			get{return _pc_memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PC_HrefUrl
		{
			set{ _pc_hrefurl=value;}
			get{return _pc_hrefurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PC_HaveChild
		{
			set{ _pc_havechild=value;}
			get{return _pc_havechild;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PC_ParentId
		{
			set{ _pc_parentid=value;}
			get{return _pc_parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PC_State
		{
			set{ _pc_state=value;}
			get{return _pc_state;}
		}
		#endregion Model

	}
}

