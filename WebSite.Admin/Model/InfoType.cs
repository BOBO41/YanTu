/**  版本信息模板在安装目录下，可自行修改。
* InfoType.cs
*
* 功 能： N/A
* 类 名： InfoType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  12/21/2014 10:56:43 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// InfoType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InfoType
	{
		public InfoType()
		{}
		#region Model
		private int _itid;
		private string _iname;
		private int? _spid;
		private string _attaid;
		private int? _sortnum;
		private int? _status=0;
		/// <summary>
		/// 
		/// </summary>
		public int ITID
		{
			set{ _itid=value;}
			get{return _itid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IName
		{
			set{ _iname=value;}
			get{return _iname;}
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
		public string AttaID
		{
			set{ _attaid=value;}
			get{return _attaid;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

