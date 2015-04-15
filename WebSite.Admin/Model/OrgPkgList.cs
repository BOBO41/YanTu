/**  版本信息模板在安装目录下，可自行修改。
* OrgPkgList.cs
*
* 功 能： N/A
* 类 名： OrgPkgList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/18/2015 7:15:59 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// OrgPkgList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgPkgList
	{
		public OrgPkgList()
		{}
		#region Model
		private int _sspid;
		private int? _spid;
		private int? _orgid;
		private int? _ospid;
		private int? _status;
		private DateTime? _createdate= DateTime.Now;
		private int? _rpid;
		/// <summary>
		/// 
		/// </summary>
		public int SSPID
		{
			set{ _sspid=value;}
			get{return _sspid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SPID
		{
			set{ _spid=value;}
			get{return _spid;}
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
		public int? OSPID
		{
			set{ _ospid=value;}
			get{return _ospid;}
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
		public int? RPID
		{
			set{ _rpid=value;}
			get{return _rpid;}
		}
		#endregion Model

	}
}

