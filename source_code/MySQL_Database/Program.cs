using MySql.Data.MySqlClient;

namespace Database_mysql
{
    public class MySQL_Database
    {
        private string id = "", password = "", Conn;
        //접속query
        public MySQL_Database(string id, string password)
        {
            this.id = id;
            this.password = password;
            Conn = String.Format("Server=localhost;Database=opentutorials;Uid={0};Pwd={1};", id, password);
        }
        public void Insert()
        {
            //삽입구문
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand msc =
                        new MySqlCommand("INSERT INTO topic(title,description,created,author,profile) " +
                        "VALUES('C#', 'C#으로 MySQL사용', NOW(), 'Jae', 'Student Developer')", conn);
                    if (msc.ExecuteNonQuery() == 1)
                        Console.WriteLine("Insert 성공");
                    else
                        Console.WriteLine("Insert 실패");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[경고] Insert 도중 에러가 발생됨.");
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// 삭제할 id 값을 입력해주세요.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                //삭제구문
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand msc = new MySqlCommand("DELETE FROM topic WHERE id=" + id, conn);
                    msc.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[경고] Delete 도중 에러가 발생됨.");
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine("Delete 성공");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter id : ");
            string? id = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string? password = Console.ReadLine();
            if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Enter id and password again");
            }
            else
            {

                MySQL_Database sql = new MySQL_Database(id, password);
                sql.Delete(1);
            }
        }
    }
}