/**  版本信息模板在安装目录下，可自行修改。
* CMArticle.cs
*
* 功 能： N/A
* 类 名： CMArticle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/5 9:44:03   N/A    初版
*
* 




*/

using System;

namespace WebSite.CM.Model
{
	/// <summary>
	/// CMArticle:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMArticle
	{
		public CMArticle()
		{}
		#region Model
		private int _aid;
		private int? _colid;
		private int? _atid;
		private string _title;
		private string _description;
		private string _author;
		private string _source;
		private string _content;
		private int? _hits;
		private int? _status=0;
		private int? _istop;
		private int? _issplendid;
		private int? _pemplid;
		private int? _cemplid;
		private DateTime? _addtime;
		private DateTime? _checktime;
		private string _seotitle;
		private string _seokeyword;
		private string _seodes;
		private int? _atttype;
		private long? _orgid;
		private int? _displaytime;
		/// <summary>
		/// 
		/// </summary>
		public int AId
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ColId
		{
			set{ _colid=value;}
			get{return _colid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ATId
		{
			set{ _atid=value;}
			get{return _atid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Hits
		{
			set{ _hits=value;}
			get{return _hits;}
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
		public int? IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsSplendid
		{
			set{ _issplendid=value;}
			get{return _issplendid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PEmplId
		{
			set{ _pemplid=value;}
			get{return _pemplid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CEmplId
		{
			set{ _cemplid=value;}
			get{return _cemplid;}
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
		public DateTime? CheckTime
		{
			set{ _checktime=value;}
			get{return _checktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoKeyword
		{
			set{ _seokeyword=value;}
			get{return _seokeyword;}
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
		public int? AttType
		{
			set{ _atttype=value;}
			get{return _atttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? OrgId
		{
			set{ _orgid=value;}
			get{return _orgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DisplayTime
		{
			set{ _displaytime=value;}
			get{return _displaytime;}
		}
		#endregion Model

	}
}

