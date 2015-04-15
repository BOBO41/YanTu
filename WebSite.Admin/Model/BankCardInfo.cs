/**  版本信息模板在安装目录下，可自行修改。
* BankCardInfo.cs
*
* 功 能： N/A
* 类 名： BankCardInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/28 11:23:14   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// BankCardInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BankCardInfo
	{
		public BankCardInfo()
		{}
		#region Model
		private string _cardno;
		private int? _status;
		private DateTime? _opentime;
		private DateTime? _closetime;
		private int? _cardtype;
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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
		public DateTime? CloseTime
		{
			set{ _closetime=value;}
			get{return _closetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
		}
		#endregion Model

	}
}

