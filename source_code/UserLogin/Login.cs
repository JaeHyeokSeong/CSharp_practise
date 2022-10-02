using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace UserLogin
{
    public class Login
    {
        // 나중에 아이디 비밀번호 지우기 
        const string strConn = "Server=localhost;Database=test_users;Uid=root;Pwd=비밀번호;";
        public Login()
        {

        }
        public string ReadStr(string message)
        {
            Console.Write(message);
            string? str = Console.ReadLine();
            if (str == null)
                str = ReadStr("[Warning] " + message);
            return str;
        }
        public int ReadInt(string message)
        {
            Console.Write(message);
            string? str = Console.ReadLine();
            int i = 0;
            if (!Int32.TryParse(str, out i))
                i = ReadInt("[Warning] " + message);
            return i;
        }
        private Hashtable ReadNewUser()
        {
            Hashtable userInfo = new Hashtable();
            userInfo.Add("emailAddress", ReadStr("Enter email Address> "));
            userInfo.Add("password", ReadStr("Enter password> "));
            userInfo.Add("name", ReadStr("Enter name> "));
            userInfo.Add("age", ReadInt("Enter age> "));
            userInfo.Add("mobileNumber", ReadInt("Enter mobile number> +61 ").ToString().Trim());
            return userInfo;
        }
        public void InsertNewUser()
        {
            using(MySqlConnection connection = new MySqlConnection(strConn))
            {
                try
                {
                    connection.Open();
                    Hashtable userInfo = ReadNewUser();
                    string insert_query = String.Format("INSERT INTO user(email_address,password,name,age,mobile_number) VALUES('{0}','{1}','{2}',{3},'+61 {4}')",
                        userInfo["emailAddress"], userInfo["password"], userInfo["name"], userInfo["age"], userInfo["mobileNumber"]);
                    MySqlCommand cmd = new MySqlCommand(insert_query, connection);
                    if(cmd.ExecuteNonQuery()==1)
                        Console.WriteLine("Success");
                    else
                        Console.WriteLine("Fail");
                } catch(Exception e)
                {
                    Console.WriteLine("[Warning] Error happened while adding a new user");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.HelpLink);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

