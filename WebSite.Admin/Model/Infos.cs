/**  版本信息模板在安装目录下，可自行修改。
* Infos.cs
*
* 功 能： N/A
* 类 名： Infos
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  3/31/2015 11:58:11 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.

*│　                                                                　│
*│　                                        　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// Infos:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Infos
	{
		public Infos()
		{}
		#region Model
		private int _iid;
		private string _iname;
		private string _picattid;
		private int? _itype;
		private int? _tiid;
		private int? _lid;
		private int? _sortnum;
		private int? _status=0;
		private DateTime? _createdate= DateTime.Now;
		private string _context;
		private string _conposition;
		private string _concolor;
		private string _consize;
		private string _xposition;
		private string _yposition;
		private string _videoattid;
		private int? _ntype;
		private int? _hottype;
		private string _adtime;
		private string _adpic;
		private string _adlink;
		/// <summary>
		/// 
		/// </summary>
		public int IID
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IName
		{
			set{ _iname=value;}
			get{return _iname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicAttID
		{
			set{ _picattid=value;}
			get{return _picattid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IType
		{
			set{ _itype=value;}
			get{return _itype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TIID
		{
			set{ _tiid=value;}
			get{return _tiid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SortNum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
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
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Context
		{
			set{ _context=value;}
			get{return _context;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConPosition
		{
			set{ _conposition=value;}
			get{return _conposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConColor
		{
			set{ _concolor=value;}
			get{return _concolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConSize
		{
			set{ _consize=value;}
			get{return _consize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XPosition
		{
			set{ _xposition=value;}
			get{return _xposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YPosition
		{
			set{ _yposition=value;}
			get{return _yposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoAttID
		{
			set{ _videoattid=value;}
			get{return _videoattid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NType
		{
			set{ _ntype=value;}
			get{return _ntype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? HotType
		{
			set{ _hottype=value;}
			get{return _hottype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ADTime
		{
			set{ _adtime=value;}
			get{return _adtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ADPic
		{
			set{ _adpic=value;}
			get{return _adpic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ADLink
		{
			set{ _adlink=value;}
			get{return _adlink;}
		}
		#endregion Model

	}
}

