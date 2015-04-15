/**  版本信息模板在安装目录下，可自行修改。
* TemplatePar.cs
*
* 功 能： N/A
* 类 名： TemplatePar
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/1/2015 1:03:03 AM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// TemplatePar:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TemplatePar
	{
		public TemplatePar()
		{}
		#region Model
		private int _tpid;
		private int? _tid;
		private int? _sortnum;
		private int? _bgwidth;
		private int? _bgheight;
		/// <summary>
		/// 
		/// </summary>
		public int TPID
		{
			set{ _tpid=value;}
			get{return _tpid;}
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
		public int? SortNum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BgWidth
		{
			set{ _bgwidth=value;}
			get{return _bgwidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BgHeight
		{
			set{ _bgheight=value;}
			get{return _bgheight;}
		}
		#endregion Model

	}
}

