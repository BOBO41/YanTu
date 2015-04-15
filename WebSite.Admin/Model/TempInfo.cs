/**  版本信息模板在安装目录下，可自行修改。
* TempInfo.cs
*
* 功 能： N/A
* 类 名： TempInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/4/2015 6:02:05 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// TempInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TempInfo
	{
		public TempInfo()
		{}
		#region Model
		private int _tiid;
		private int? _itid;
		private int? _tid;
		private string _attid;
		private int? _tipage;
		private int? _parentid;
		/// <summary>
		/// 
		/// </summary>
		public int TIID
		{
			set{ _tiid=value;}
			get{return _tiid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ITID
		{
			set{ _itid=value;}
			get{return _itid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttID
		{
			set{ _attid=value;}
			get{return _attid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TIPage
		{
			set{ _tipage=value;}
			get{return _tipage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

