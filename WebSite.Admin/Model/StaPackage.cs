/**  版本信息模板在安装目录下，可自行修改。
* StaPackage.cs
*
* 功 能： N/A
* 类 名： StaPackage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/14/2015 8:38:28 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// StaPackage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StaPackage
	{
		public StaPackage()
		{}
		#region Model
		private int _spid;
		private int? _rpid;
		private int? _orgid;
		private string _sppath;
		private int? _status;
		private DateTime _createdate= DateTime.Now;
		private int? _pkgtype=0;
		/// <summary>
		/// 
		/// </summary>
		public int SPID
		{
			set{ _spid=value;}
			get{return _spid;}
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
		public int? OrgId
		{
			set{ _orgid=value;}
			get{return _orgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPPath
		{
			set{ _sppath=value;}
			get{return _sppath;}
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
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PkgType
		{
			set{ _pkgtype=value;}
			get{return _pkgtype;}
		}
		#endregion Model

	}
}

