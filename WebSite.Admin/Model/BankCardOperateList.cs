/**  版本信息模板在安装目录下，可自行修改。
* BankCardOperateList.cs
*
* 功 能： N/A
* 类 名： BankCardOperateList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-01-17 11:39:49   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// BankCardOperateList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BankCardOperateList
	{
		public BankCardOperateList()
		{}
		#region Model
		private int _id;
		private string _cardno;
		private int? _optype;
		private DateTime? _time;
		private int? _emplid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardNo
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OpType
		{
			set{ _optype=value;}
			get{return _optype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
		}
		#endregion Model

	}
}

