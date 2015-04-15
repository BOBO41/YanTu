/**  版本信息模板在安装目录下，可自行修改。
* CMColumn.cs
*
* 功 能： N/A
* 类 名： CMColumn
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/4 11:23:30   N/A    初版
*
* 




*/

using System;

namespace WebSite.CM.Model
{
	/// <summary>
	/// CMColumn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMColumn
	{
		public CMColumn()
		{}
		#region Model
		private int _colid;
		private string _colname;
		private int? _parentid;
		private int? _level;
		private int? _status=1;
		private DateTime? _addtime;
		private string _seokey;
		private string _seodes;
		private int? _clickrate;
		/// <summary>
		/// 
		/// </summary>
		public int ColId
		{
			set{ _colid=value;}
			get{return _colid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ColName
		{
			set{ _colname=value;}
			get{return _colname;}
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
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
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
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoKey
		{
			set{ _seokey=value;}
			get{return _seokey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoDes
		{
			set{ _seodes=value;}
			get{return _seodes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClickRate
		{
			set{ _clickrate=value;}
			get{return _clickrate;}
		}
		#endregion Model

	}
}

