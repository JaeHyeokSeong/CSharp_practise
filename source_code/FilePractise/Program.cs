namespace FilePractise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter: ");
            string text = Console.ReadLine();


            StreamWriter sw = File.AppendText("login.txt");
            sw.WriteLine(text);
            sw.Close();
        }
    }
}