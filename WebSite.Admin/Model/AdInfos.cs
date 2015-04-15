/**  版本信息模板在安装目录下，可自行修改。
* AdInfos.cs
*
* 功 能： N/A
* 类 名： AdInfos
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/6/2015 1:13:46 AM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// AdInfos:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AdInfos
	{
		public AdInfos()
		{}
		#region Model
		private int _aiid;
		private int? _iid;
		private int? _inf_iid;
		/// <summary>
		/// 
		/// </summary>
		public int AIID
		{
			set{ _aiid=value;}
			get{return _aiid;}
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
		public int? Inf_IID
		{
			set{ _inf_iid=value;}
			get{return _inf_iid;}
		}
		#endregion Model

	}
}

