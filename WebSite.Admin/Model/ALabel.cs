/**  版本信息模板在安装目录下，可自行修改。
* ALabel.cs
*
* 功 能： N/A
* 类 名： ALabel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  12/19/2014 11:58:43 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// ALabel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ALabel
	{
		public ALabel()
		{}
		#region Model
		private int _alid;
		private string _lname;
		private DateTime? _createdate= DateTime.Now;
		private int? _status=0;
		private int? _creater;
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
		public string LName
		{
			set{ _lname=value;}
			get{return _lname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
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
		public int? Creater
		{
			set{ _creater=value;}
			get{return _creater;}
		}
		#endregion Model

	}
}

