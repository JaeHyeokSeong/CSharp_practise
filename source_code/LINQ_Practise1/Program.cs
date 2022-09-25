namespace LINQ_Practise1;

public class Program
{
    public static void Main(string[] args)
    {
        string userName = "", password = "";
        bool loginStatus = false;
        Console.WriteLine("Please enter username and password");
        Console.Write("Username: ");
        userName = Console.ReadLine();
        Console.Write("Password: ");
        password = Console.ReadLine();

        StreamReader sr = new StreamReader("login.txt");
        string? line = sr.ReadLine();
        string[] userInfo;
        while(line != null)
        {
            userInfo = line.Split(',');
            string readUsername = userInfo[0].Trim();
            string readPassword = userInfo[1].Trim();
            if(userName == readUsername && password == readPassword)
            {
                loginStatus = true;
                break;
            }
            line = sr.ReadLine();
        }
        sr.Close();

        if (loginStatus)
        {
            Console.WriteLine("\nLogin Success");
        }
        else
        {
            Console.WriteLine("\nLogin Fail");
        }
    }
}