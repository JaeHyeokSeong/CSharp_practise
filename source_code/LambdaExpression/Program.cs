namespace LambdaExpression
{
    public class LambdaExpression
    {
        // [1] 대리자 선언 
        delegate void Lambda();
        public LambdaExpression()
        {
            // [2] 대리자 개체에 람다식 선언 : goes to 연산자   
            // 람다: 이름 없는 함수, 무명 함수(anonymous function)
            Lambda lambda = () => Console.WriteLine("hi");
            lambda += () => Console.WriteLine("hello!");

            // [3] 대리자 개체 호출 
            lambda();
        }
    }
    public class LambdaExpressionArgs
    {
        // [1] argument 값 그리고 리턴 값이 있는 대리자 선언 
        delegate int LambdaArgs(int i);
        public LambdaExpressionArgs()
        {
            LambdaArgs square = i => i * i;
            Console.WriteLine(square(2));
        }
    }
    public class LanbdaExpressionTypeDeclare
    {
        delegate bool Lambda(string str, int len);
        public LanbdaExpressionTypeDeclare()
        {
            Lambda isLong = (str, i) => str.Length > i;
            Console.WriteLine(isLong("안녕하세요.", 5));
            Console.WriteLine(isLong("반가워요.", 10));
        }
    }
    public class LambdaExpressionMultiLine
    {
        delegate void Hi();
        public LambdaExpressionMultiLine()
        {
            Hi hi = () =>
            {
                Console.WriteLine("안녕하세요");
                Console.WriteLine("반값습니다");
            };
            hi();
        }
    }
    public class LambdaExpressionWithFunc
    {
        public LambdaExpressionWithFunc()
        {
            // Func 를 사용하면 따로 대리자를 정의할 필요없이 간편하게 사용할 수 있다.
            // Func 는 항상 리턴 타입이 있다 그리고 parameter 에는 최대 16개까지 들어올수있다
            // 만약 16개를 넘어서면 에러가 발생함.
            Func<int, int> square = (i) => i * i;
            Console.WriteLine(square(10));
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // LambdaExpression lambdaExpression = new LambdaExpression();
            //LambdaExpressionArgs lambdaExpressionArgs = new LambdaExpressionArgs();
            //LanbdaExpressionTypeDeclare lanbdaExpressionTypeDeclare = new LanbdaExpressionTypeDeclare();
            //LambdaExpressionMultiLine lambdaExpressionMultiLine = new LambdaExpressionMultiLine();
            LambdaExpressionWithFunc lambdaExpressionWithFunc = new LambdaExpressionWithFunc();
        }
    }
}