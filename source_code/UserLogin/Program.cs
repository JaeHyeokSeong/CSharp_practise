namespace UserLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Login login = new Login();
            string message = "Enter 1 (login), 2 (new user), 3 (clear), -1 (exit) => ";
            int choice = login.ReadInt(message);
            do
            {
                if (choice == 1)
                    login.TryLogin();
                else if (choice == 2)
                    login.InsertNewUser();
                else if (choice == 3)
                    Console.Clear();
                choice = login.ReadInt(message);
            } while (choice != -1);
        }
    }
}