/**  版本信息模板在安装目录下，可自行修改。
* AttaList.cs
*
* 功 能： N/A
* 类 名： AttaList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  3/31/2015 11:58:10 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.

*│　                                                                　│
*│　                                        　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// AttaList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AttaList
	{
		public AttaList()
		{}
		#region Model
		private int _alid;
		private string _attid;
		private int? _iid;
		private string _ad_iid;
		/// <summary>
		/// 
		/// </summary>
		public int ALID
		{
			set{ _alid=value;}
			get{return _alid;}
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
		public int? IID
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AD_IID
		{
			set{ _ad_iid=value;}
			get{return _ad_iid;}
		}
		#endregion Model

	}
}

