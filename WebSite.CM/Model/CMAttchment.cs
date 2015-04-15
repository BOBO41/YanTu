/**  版本信息模板在安装目录下，可自行修改。
* ProductBrand.cs
*
* 功 能： N/A
* 类 名： ProductBrand
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/27 9:27:28   N/A    初版
*
* 




*/

using System;

namespace WebSite.CM.Model
{
	/// <summary>
	/// CMAttchment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMAttchment
	{
		public CMAttchment()
		{}
		#region Model
		private int _attid;
		private int? _aid;
		private int? _type;
		private string _attname;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int AttId
		{
			set{ _attid=value;}
			get{return _attid;}
		}
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
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttName
		{
			set{ _attname=value;}
			get{return _attname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

