/**  版本信息模板在安装目录下，可自行修改。
* InfoLabel.cs
*
* 功 能： N/A
* 类 名： InfoLabel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/2/2015 2:24:43 AM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// InfoLabel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InfoLabel
	{
		public InfoLabel()
		{}
		#region Model
		private int _ilid;
		private int? _iid;
		private int? _alid;
		/// <summary>
		/// 
		/// </summary>
		public int ILID
		{
			set{ _ilid=value;}
			get{return _ilid;}
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
		public int? ALID
		{
			set{ _alid=value;}
			get{return _alid;}
		}
		#endregion Model

	}
}

