namespace Inheritance
{
    
    public abstract class A
    {
        int a;
        public A(int a)
        {
            this.a = a;
        }
        public static void print()
        {
            Console.WriteLine("hello world");
        }
    }
    public class B : A
    {
        public B(int a) : base(a)
        {

        }
        public new void print()
        {
            Console.WriteLine("HELLO WORLD");
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("hello world");
        }
    }
}