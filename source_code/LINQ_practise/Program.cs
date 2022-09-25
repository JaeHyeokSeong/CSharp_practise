namespace LINQ_practise;

public class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5};
        var result = numbers.Where(n => n % 2 == 0).Sum(); // 식 람다 
        // => 를 발음할때 보통 goes to 라고 합니다.
        // n => n % 2 == 0 이러한 형태를 람다식, 즉 이름이 없는 함수라고 합니다.
        // 더 자세한 내용은 구글링 해보기
        Console.WriteLine(result); // 6

        // method1
        var selectResult = numbers.Select(x => x); // 식 람다 
        foreach(int num in selectResult)
        {
            Console.Write(num + " "); // 1, 2, 3, 4, 5
        }
        Console.WriteLine();

        // method2
        var selectResult1 = numbers.Select(x => { return x; }); // 문 람다 
        // linq 식 람다에다가 문 람다를 적는 것도 가능하다. 예를 들어서, return x; 같은 거
        foreach (int num in selectResult1)
        {
            Console.Write(num + " "); // 1, 2, 3, 4, 5
        }
        Console.WriteLine();

        // method3
        var selectResult2 = numbers.Select(x => { return x * x; }); // 문 람다 
        // linq 식 람다에다가 문 람다를 적는 것도 가능하다. 예를 들어서, return x * x; 같은 거
        foreach (int num in selectResult2)
        {
            Console.Write(num + " "); // 1, 4, 9, 16, 25
        }
        Console.WriteLine(); 

        // 짝수에서 최댓값을 linq 를 사용해서 구해보기
        var v1 = numbers.Where(x => x % 2 == 0).Max();
        Console.WriteLine(v1); // 4

        // 2의 배수 그리고 3의 배수 합을 구해보기 linq를 사용해서
        var v2 = numbers.Where(x => x % 2 == 0 || x % 3 == 0).Sum();
        Console.WriteLine(v2); // 9

        // 리스트 안에 있는 값들을 linq를 사용해서 오름차순으로 정렬해보기 
        List<string> techs = new List<string>();
        techs.Add("C#");
        techs.Add("ASP.NET");
        techs.Add("Blazor");
        var sortedTechs = techs.OrderBy(x => x); // 가져와서 가져온거를 비교하기 
        foreach(string str in sortedTechs)
        {
            Console.Write(str + " "); // ASP.NET Blazor C#
        }
        Console.WriteLine();

        // 리스트 안에 있는 값들을 linq를 사용해서 내림차순으로 정렬해보기
        var descendingOrderTechs = techs.OrderByDescending(x => x);
        foreach(string str in descendingOrderTechs)
        {
            Console.Write(str + " "); // C# Blazor ASP.NET
        }
        Console.WriteLine();

        // Numbers 에서 짝수만 합하기  
        var Numbers = Enumerable.Range(1, 100);
        var evenNumberSum = Numbers.Where(x => x % 2 == 0).Sum();
        Console.WriteLine(evenNumberSum); // 2550

        // 짝수를 descending 을 한 후에 결과갑들 중에서 5개만 가져오기
        var descedningResult = Numbers.Where(n => n % 2 == 0).OrderByDescending(n => n).Take(5);
        foreach(int number in descedningResult)
        {
            Console.Write(number + " "); // 100 98 96 94 92
        }
        Console.WriteLine();

        // 짝수를 descending 을 한 후에 결과갑들 중에서 3개 skip 하고 5개만 가져오기
        descedningResult = Numbers.Where(x => x % 2 == 0).OrderByDescending(x => x).Skip(3).Take(5);
        foreach(int number in descedningResult)
        {
            Console.Write(number + " "); // 94 92 90 88 86
        }
        Console.WriteLine();


        // 아래의 방법처럼 쿼리구문으로도 할 수 있다, 반면에 위에 했던 방법들은 메서드 구문 혹은 메서드 syntax 라고 합니다.
        var q = from n in Numbers
                where n % 2 == 0
                select n;

        foreach (int n in q)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();

        // var n1 = Numbers.Where(n => n % 2 == 0);
        var n1 = Numbers.Where(n => n % 2 == 0).Select(n => n);
        foreach(int a in n1)
        {
            Console.Write(a + " ");
        }
        Console.WriteLine();
    }
}