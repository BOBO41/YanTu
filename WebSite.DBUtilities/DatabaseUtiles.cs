using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.DBUtilities
{
    public class DatabaseUtiles
    {
        static private Database m_db;
        static private object m_db_lock = new object();
        static public Database DB
        {
            get
            {
                lock (m_db_lock)
                {
                    // = DatabaseFactory.CreateDatabase()
                    if (m_db == null)
                        m_db = DatabaseFactory.CreateDatabase();
                    return m_db;
                }
            }
        }

        static private Hashtable m_dbs ;
        static private object m_dbs_lock = new object();
        static public Database GetDB(string ConnectionName)
        {
            lock (m_dbs_lock)
            {
                if (m_dbs == null)
                    m_dbs = new Hashtable();
                if (!m_dbs.Contains(ConnectionName))
                    m_dbs.Add(ConnectionName, DatabaseFactory.CreateDatabase(ConnectionName));
                return (Database)m_dbs[ConnectionName];
            }
        }
    }
}