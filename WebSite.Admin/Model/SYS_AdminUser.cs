/**  版本信息模板在安装目录下，可自行修改。
* SYS_AdminUser.cs
*
* 功 能： N/A
* 类 名： SYS_AdminUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-08-22 09:30:14   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// SYS_AdminUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_AdminUser
	{
		public SYS_AdminUser()
		{}
		#region Model
		private int _adn_id;
		private int? _dpt_id;
		private string _adn_username;
		private string _adn_password;
		private string _adn_mobile;
		private DateTime? _adn_addtime= DateTime.Now;
		private int? _adn_flag=1;
		private string _adn_realname;
		private string _adn_securityid;
		private int? _adn_isworker;
		private string _adn_selfcard;
		private string _openid;
		private int? _adn_isconsultant;
		private string _wx_fakeid;
		private string _wx_nickname;
		private string _wx_remarkname;
		private string _wx_username;
		private string _wx_signature;
		private string _wx_country;
		private string _wx_province;
		private string _wx_city;
		private int? _wx_sex;
		private int? _wx_groupid;
		private string _wx_groupname;
		private string _wx_userimage;
		private int? _wx_status=0;
		private long? _wx_msgid;
		private DateTime? _wx_msgcreatedatetime;
		private string _wx_msgcontent;
		/// <summary>
		/// 
		/// </summary>
		public int Adn_Id
		{
			set{ _adn_id=value;}
			get{return _adn_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Dpt_Id
		{
			set{ _dpt_id=value;}
			get{return _dpt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Adn_UserName
		{
			set{ _adn_username=value;}
			get{return _adn_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Adn_Password
		{
			set{ _adn_password=value;}
			get{return _adn_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Adn_Mobile
		{
			set{ _adn_mobile=value;}
			get{return _adn_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Adn_AddTime
		{
			set{ _adn_addtime=value;}
			get{return _adn_addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Adn_Flag
		{
			set{ _adn_flag=value;}
			get{return _adn_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Adn_RealName
		{
			set{ _adn_realname=value;}
			get{return _adn_realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Adn_SecurityID
		{
			set{ _adn_securityid=value;}
			get{return _adn_securityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Adn_IsWorker
		{
			set{ _adn_isworker=value;}
			get{return _adn_isworker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Adn_SelfCard
		{
			set{ _adn_selfcard=value;}
			get{return _adn_selfcard;}
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
		public int? Adn_IsConsultant
		{
			set{ _adn_isconsultant=value;}
			get{return _adn_isconsultant;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_FakeId
		{
			set{ _wx_fakeid=value;}
			get{return _wx_fakeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_NickName
		{
			set{ _wx_nickname=value;}
			get{return _wx_nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_ReMarkName
		{
			set{ _wx_remarkname=value;}
			get{return _wx_remarkname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_Username
		{
			set{ _wx_username=value;}
			get{return _wx_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_Signature
		{
			set{ _wx_signature=value;}
			get{return _wx_signature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_Country
		{
			set{ _wx_country=value;}
			get{return _wx_country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_Province
		{
			set{ _wx_province=value;}
			get{return _wx_province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_City
		{
			set{ _wx_city=value;}
			get{return _wx_city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Wx_Sex
		{
			set{ _wx_sex=value;}
			get{return _wx_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Wx_GroupID
		{
			set{ _wx_groupid=value;}
			get{return _wx_groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_GroupName
		{
			set{ _wx_groupname=value;}
			get{return _wx_groupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_UserImage
		{
			set{ _wx_userimage=value;}
			get{return _wx_userimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Wx_Status
		{
			set{ _wx_status=value;}
			get{return _wx_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? Wx_MsgId
		{
			set{ _wx_msgid=value;}
			get{return _wx_msgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Wx_MsgCreateDateTime
		{
			set{ _wx_msgcreatedatetime=value;}
			get{return _wx_msgcreatedatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wx_MsgContent
		{
			set{ _wx_msgcontent=value;}
			get{return _wx_msgcontent;}
		}
		#endregion Model

	}
}

