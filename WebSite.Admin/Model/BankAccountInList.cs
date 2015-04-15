/**  版本信息模板在安装目录下，可自行修改。
* BankAccountInList.cs
*
* 功 能： N/A
* 类 名： BankAccountInList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/23 14:17:19   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// BankAccountInList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BankAccountInList
	{
		public BankAccountInList()
		{}
		#region Model
		private int _inid;
		private string _accountno;
		private decimal? _inmoney;
		private int? _type;
		private string _memo;
		private DateTime? _time;
		private int? _status;
		private int? _emplid;
		private int? _empid;
		private DateTime? _audittime;
		/// <summary>
		/// 
		/// </summary>
		public int InId
		{
			set{ _inid=value;}
			get{return _inid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountNo
		{
			set{ _accountno=value;}
			get{return _accountno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InMoney
		{
			set{ _inmoney=value;}
			get{return _inmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Time
		{
			set{ _time=value;}
			get{return _time;}
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
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmpId
		{
			set{ _empid=value;}
			get{return _empid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AuditTime
		{
			set{ _audittime=value;}
			get{return _audittime;}
		}
		#endregion Model

	}
}

