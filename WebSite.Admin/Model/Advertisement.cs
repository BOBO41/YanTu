/**  版本信息模板在安装目录下，可自行修改。
* Advertisement.cs
*
* 功 能： N/A
* 类 名： Advertisement
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/10/2015 5:11:08 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// Advertisement:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Advertisement
	{
		public Advertisement()
		{}
		#region Model
		private int _aid;
		private string _aname;
		private string _aurl;
		private string _aimg;
		private int? _status;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AName
		{
			set{ _aname=value;}
			get{return _aname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AUrl
		{
			set{ _aurl=value;}
			get{return _aurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AImg
		{
			set{ _aimg=value;}
			get{return _aimg;}
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
		#endregion Model

	}
}

