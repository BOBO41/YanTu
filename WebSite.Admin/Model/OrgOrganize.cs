/**  版本信息模板在安装目录下，可自行修改。
* OrgOrganize.cs
*
* 功 能： N/A
* 类 名： OrgOrganize
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  12/24/2014 8:48:57 AM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// OrgOrganize:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgOrganize
	{
		public OrgOrganize()
		{}
		#region Model
		private long _orgid;
		private string _areaid;
		private string _orgname;
		private string _orgaddress;
		private string _orgphone;
		private string _enname;
		private string _orgfax;
		private int? _orgtype;
		private long? _orgparentid;
		private DateTime? _addtime;
		private int? _status;
		private DateTime? _enddate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public long OrgId
		{
			set{ _orgid=value;}
			get{return _orgid;}
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
		public string OrgName
		{
			set{ _orgname=value;}
			get{return _orgname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrgAddress
		{
			set{ _orgaddress=value;}
			get{return _orgaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrgPhone
		{
			set{ _orgphone=value;}
			get{return _orgphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EnName
		{
			set{ _enname=value;}
			get{return _enname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrgFax
		{
			set{ _orgfax=value;}
			get{return _orgfax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrgType
		{
			set{ _orgtype=value;}
			get{return _orgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? OrgParentId
		{
			set{ _orgparentid=value;}
			get{return _orgparentid;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		#endregion Model

	}
}

