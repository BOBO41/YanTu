/**  版本信息模板在安装目录下，可自行修改。
* SYS_UserForConsultant.cs
*
* 功 能： N/A
* 类 名： SYS_UserForConsultant
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-08-08 18:27:10   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// SYS_UserForRole:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_UserForConsultant
	{
        public SYS_UserForConsultant()
		{}
		#region Model
		private int _con_id;
		private int? _adn_id;
		private int? _adn_conid;
		/// <summary>
		/// 
		/// </summary>
		public int Con_Id
		{
            set { _con_id = value; }
            get { return _con_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Adn_Id
		{
			set{ _adn_id=value;}
			get{return _adn_id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int? Adn_ConId
		{
            set { _adn_conid = value; }
            get { return _adn_conid; }
		}
		#endregion Model

	}
}

