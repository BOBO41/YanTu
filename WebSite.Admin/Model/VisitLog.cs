/**  版本信息模板在安装目录下，可自行修改。
* VisitLog.cs
*
* 功 能： N/A
* 类 名： VisitLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  4/9/2015 9:47:30 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.

*│　                                                                　│
*│　                                        　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// VisitLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VisitLog
	{
		public VisitLog()
		{}
		#region Model
		private int _vlid;
		private int? _iid;
		private DateTime? _visitdate;
		private long? _staydate;
		private int? _rpid;
		private long? _orgid;
		private long? _staid;
		private DateTime? _createdate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int VLID
		{
			set{ _vlid=value;}
			get{return _vlid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IID
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? VisitDate
		{
			set{ _visitdate=value;}
			get{return _visitdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? StayDate
		{
			set{ _staydate=value;}
			get{return _staydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RPID
		{
			set{ _rpid=value;}
			get{return _rpid;}
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
		public long? StaId
		{
			set{ _staid=value;}
			get{return _staid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

