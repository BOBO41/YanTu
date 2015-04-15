/**  版本信息模板在安装目录下，可自行修改。
* SWCompany.cs
*
* 功 能： N/A
* 类 名： SWCompany
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/22 17:12:55   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// SWCompany:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SWCompany
	{
		public SWCompany()
		{}
		#region Model
		private int? _sworgid;
		private int? _corgid;
		/// <summary>
		/// 
		/// </summary>
		public int? SWOrgId
		{
			set{ _sworgid=value;}
			get{return _sworgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? COrgId
		{
			set{ _corgid=value;}
			get{return _corgid;}
		}
		#endregion Model

	}
}

