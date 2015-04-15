/**  版本信息模板在安装目录下，可自行修改。
* TmpInfoList.cs
*
* 功 能： N/A
* 类 名： TmpInfoList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/15/2015 4:25:57 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// TmpInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TmpInfoList
	{
		public TmpInfoList()
		{}
		#region Model
		private int _tilid;
		private int? _iid;
		private int? _tiid;
		/// <summary>
		/// 
		/// </summary>
		public int TILID
		{
			set{ _tilid=value;}
			get{return _tilid;}
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
		public int? TIID
		{
			set{ _tiid=value;}
			get{return _tiid;}
		}
		#endregion Model

	}
}

