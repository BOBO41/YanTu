/**  版本信息模板在安装目录下，可自行修改。
* Logs.cs
*
* 功 能： N/A
* 类 名： Logs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-03-03 10:11:54   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// Logs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Logs
	{
		public Logs()
		{}
		#region Model
		private long _lid;
		private long? _llid;
		private string _ovalue;
		private string _nvalue;
		private string _fname;
		/// <summary>
		/// 
		/// </summary>
		public long LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? LLID
		{
			set{ _llid=value;}
			get{return _llid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OValue
		{
			set{ _ovalue=value;}
			get{return _ovalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NValue
		{
			set{ _nvalue=value;}
			get{return _nvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FName
		{
			set{ _fname=value;}
			get{return _fname;}
		}
		#endregion Model

	}
}

