/**  版本信息模板在安装目录下，可自行修改。
* RootPackage.cs
*
* 功 能： N/A
* 类 名： RootPackage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  3/6/2015 3:20:33 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.

*│　                                                                　│
*│　                                        　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// RootPackage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RootPackage
	{
		public RootPackage()
		{}
		#region Model
		private int _rpid;
		private int? _orpid=0;
		private int? _status=0;
		private string _rpname;
		private DateTime? _createdate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int RPID
		{
			set{ _rpid=value;}
			get{return _rpid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ORPID
		{
			set{ _orpid=value;}
			get{return _orpid;}
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
		public string RPName
		{
			set{ _rpname=value;}
			get{return _rpname;}
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

