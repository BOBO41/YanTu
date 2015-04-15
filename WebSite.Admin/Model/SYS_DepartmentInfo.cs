/**  版本信息模板在安装目录下，可自行修改。
* SYS_DepartmentInfo.cs
*
* 功 能： N/A
* 类 名： SYS_DepartmentInfo
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
	/// SYS_DepartmentInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_DepartmentInfo
	{
		public SYS_DepartmentInfo()
		{}
		#region Model
		private int _dpt_id;
		private string _dpt_name;
		private int? _dpt_parentid;
		private int? _dpt_level;
		private string _dpt_securityid;
		/// <summary>
		/// 
		/// </summary>
		public int Dpt_Id
		{
			set{ _dpt_id=value;}
			get{return _dpt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dpt_Name
		{
			set{ _dpt_name=value;}
			get{return _dpt_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Dpt_ParentId
		{
			set{ _dpt_parentid=value;}
			get{return _dpt_parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Dpt_Level
		{
			set{ _dpt_level=value;}
			get{return _dpt_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dpt_SecurityID
		{
			set{ _dpt_securityid=value;}
			get{return _dpt_securityid;}
		}
		#endregion Model

	}
}

