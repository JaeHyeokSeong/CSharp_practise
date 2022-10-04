using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace UserLogin
{
    public class Login
    {
        // 나중에 아이디 비밀번호 지우기
        string password = "";
        string strConn;
        public Login()
        {
            strConn = "Server=localhost;Database=test_users;Uid=root;Pwd=" + password + ";";
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
        public void TryLogin()
        {
            // 로그인 구현 하기
            using (MySqlConnection connection = new MySqlConnection(strConn))
            {
                string emailAddress = ReadStr("Enter email address> ");
                string password = ReadStr("Enter password> ");
                try
                {
                    string select_query = "SELECT email_address, password FROM user";
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(select_query, connection);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if ((string)rdr["email_address"] == emailAddress && (string)rdr["password"] == password)
                        {
                            Console.WriteLine("Login Success");
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[Warning] Error happened while login");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.HelpLink);
                }
                finally
                {
                    connection.Close();
                }
                Console.WriteLine("Login Fail");
            }
        }
        public void FindPassword()
        {
            // 이메일 아이디 그리고 휴대폰 번호 입력하도록 하기
            // 만약 두개가 모두 일치하다면 입력되어져있는 이메일 주소로 5자리 숫자를 보낸후 입력하다고 유도하기
            string emailAddress = ReadStr("Enter email address> ");
            int mobileNumber = ReadInt("Enter mobile number> +61 ");
            // MySQL 서버에서 이메일 그리고 전화번호 읽은 후 일치하면 true 아니면 false
            using (MySqlConnection connection = new MySqlConnection(strConn))
            {
                try
                {
                    connection.Open();
                    string select_query = "SELECT email_address, mobile_number FROM user";
                    MySqlCommand cmd = new MySqlCommand(select_query, connection);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (emailAddress == (string)rdr["email_address"] && String.Format("+61 {0}",mobileNumber) == (string)rdr["mobile_number"])
                        {
                            Console.WriteLine("[Information] Confirmed");
                            return;
                        }
                    }
                    Console.WriteLine("[Warning] Please enter email address and mobile number again");
                } catch (Exception e)
                {
                    Console.WriteLine("[Warning in Login class] Error happened while finding a password");
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

