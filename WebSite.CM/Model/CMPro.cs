/**  版本信息模板在安装目录下，可自行修改。
* CMPro.cs
*
* 功 能： N/A
* 类 名： CMPro
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/8 17:36:01   N/A    初版
*
* 




*/

using System;

namespace WebSite.CM.Model
{
	/// <summary>
	/// CMPro:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMPro
	{
		public CMPro()
		{}
		#region Model
		private int? _aid;
		private int? _pid;
		/// <summary>
		/// 
		/// </summary>
		public int? AId
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		#endregion Model

	}
}

