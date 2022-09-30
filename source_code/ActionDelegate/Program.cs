namespace ActionDelegate
{
    public class Program
    {
        // Action Delegate 는 Func 랑 유사하다, 다만 하나의 차이점이라면
        // 리턴 타입이 없다는 것이다.
        public static void Square(Action<int> square, int i)
        {
            square(i);
        }
        public static void Main(string[] args)
        {
            Square(i => Console.WriteLine(i * i), 5);
        }
    }
}