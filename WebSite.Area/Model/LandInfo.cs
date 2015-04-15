/**  版本信息模板在安装目录下，可自行修改。
* LandInfo.cs
*
* 功 能： N/A
* 类 名： LandInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/11 16:13:30   N/A    初版
*
* 




*/

using System;

namespace WebSite.Area.Model
{
	/// <summary>
	/// LandInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LandInfo
	{
		public LandInfo()
		{}
		#region Model
		private int _lid;
		private string _areaid;
		private string _lname;
		private string _larea;
		private string _lmemo;
		private int? _parentid;
		private string _langitude;
		private string _dimension;
		/// <summary>
		/// 
		/// </summary>
		public int LId
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaId
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LName
		{
			set{ _lname=value;}
			get{return _lname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LArea
		{
			set{ _larea=value;}
			get{return _larea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMemo
		{
			set{ _lmemo=value;}
			get{return _lmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string langitude
		{
			set{ _langitude=value;}
			get{return _langitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dimension
		{
			set{ _dimension=value;}
			get{return _dimension;}
		}
		#endregion Model

	}
}

