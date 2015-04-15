/**  版本信息模板在安装目录下，可自行修改。
* Templates.cs
*
* 功 能： N/A
* 类 名： Templates
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/17/2015 4:40:02 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// Templates:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Templates
	{
		public Templates()
		{}
		#region Model
		private int _tid;
		private string _tname;
		private int? _ttype;
		private string _tlink;
		private int? _status=0;
		private string _timg;
		/// <summary>
		/// 
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TType
		{
			set{ _ttype=value;}
			get{return _ttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TLink
		{
			set{ _tlink=value;}
			get{return _tlink;}
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
		public string TImg
		{
			set{ _timg=value;}
			get{return _timg;}
		}
		#endregion Model

	}
}

