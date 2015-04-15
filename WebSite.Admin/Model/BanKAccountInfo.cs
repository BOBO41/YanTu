/**  版本信息模板在安装目录下，可自行修改。
* BanKAccountInfo.cs
*
* 功 能： N/A
* 类 名： BanKAccountInfo
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
	/// BanKAccountInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BanKAccountInfo
	{
		public BanKAccountInfo()
		{}
		#region Model
		private string _accountno;
		private int? _cid;
		private string _cardno;
		private int? _emplid;
		private decimal? _intotal;
		private decimal? _outtotal;
		private decimal? _currenttotal;
		private string _accountpwd;
		private DateTime? _opentime;
		private int? _status;
		private int? _empid;
		private DateTime? _audittime;
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
		public int? CId
		{
			set{ _cid=value;}
			get{return _cid;}
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
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InTotal
		{
			set{ _intotal=value;}
			get{return _intotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OutTotal
		{
			set{ _outtotal=value;}
			get{return _outtotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CurrentTotal
		{
			set{ _currenttotal=value;}
			get{return _currenttotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountPwd
		{
			set{ _accountpwd=value;}
			get{return _accountpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OpenTime
		{
			set{ _opentime=value;}
			get{return _opentime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
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

