using System;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
namespace UserLogin
{
    public class Database
    {
        private string databaseName = "";
        private string strConn = "";
        private string query = "";
        public string Query
        {
            set { query = value; }
        }
        public string StrConn
        {
            set { strConn = value; }
        }
        public Database(string databaseName, string password)
        {
            this.databaseName = databaseName;
            strConn = String.Format("Server=localhost;Database={0};Uid=root;Pwd={1};", databaseName, password);
        }
        /// <summary>
        /// query 기반으로 데이터를 읽은 후, MySqlDataReader 객체를 리턴한다.
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader? Select()
        {
            MySqlDataReader? rdr = null;
            using (MySqlConnection connection = new MySqlConnection(strConn))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    rdr = cmd.ExecuteReader();
                    
                } catch(Exception e)
                {
                    Console.WriteLine("[Warning in Database class] Error happened while reading data in {0} database", databaseName);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.HelpLink);
                }
                finally
                {
                    connection.Close();
                }
            }
            return rdr;
        }
    }
}

