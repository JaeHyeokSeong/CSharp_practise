namespace PredicateDelegate
{
    // Predicate delegate는 입력 parameter의 개수는 무조건 1개인 경우이고 리턴 값은 항상 bool 입니다.
    public class Program
    {
        public static void IsAdult(Predicate<int> predicate, int i)
        {
            if (predicate(i))
            {
                Console.WriteLine("age : {0}, Adult", i);
            }
            else
            {
                Console.WriteLine("age : {0}, Student", i);
            }
        }
        public static void Main(string[] args)
        {
            IsAdult(i => i > 19, 12);
        }
    }

}
