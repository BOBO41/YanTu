/**  版本信息模板在安装目录下，可自行修改。
* UserAccount.cs
*
* 功 能： N/A
* 类 名： UserAccount
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-10 10:07:43   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// UserAccount:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserAccount
	{
		public UserAccount()
		{}
		#region Model
		private long _uid;
		private string _realname;
		private int? _sex;
		private string _email;
		private string _password;
		private int? _status=0;
		private DateTime? _createdate= DateTime.Now;
		private string _openid;
		private string _mobile;
		private int? _age;
		private string _addr;
		private string _descri;
		private decimal? _integral=0M;
		/// <summary>
		/// 
		/// </summary>
		public long UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
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
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OpenId
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descri
		{
			set{ _descri=value;}
			get{return _descri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		#endregion Model

	}
}

