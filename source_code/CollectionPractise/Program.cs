using System.Collections;

namespace CollectionPractise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Collection

            // Stack 설명
            // Last in First out (LIFO)
            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Peek());

            // Queue (head, tail)
            // First in, First out (FIFO)
            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(100);
            //queue.Enqueue(200);
            //Console.WriteLine("Add");
            //foreach(int v in queue)
            //{
            //    Console.WriteLine(v);
            //}
            //Console.WriteLine("Remove");
            //Console.WriteLine(queue.Dequeue());
            //Console.WriteLine(queue.Dequeue());

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("hello");
            //arrayList.Add("I'm Jae");
            //arrayList.Add(20);
            //arrayList.Insert(1, "world");

            //foreach(var v in arrayList)
            //{
            //    Console.WriteLine(v);
            //}

            Hashtable hashtable = new Hashtable();
            hashtable.Add("name", "철수");
            hashtable.Add("age", 20);
            hashtable.Add("gender", "남자");
            hashtable.Add("nationality", "한국");

            foreach(object key in hashtable.Keys)
            {
                Console.WriteLine("Value : {0}", hashtable[key]);
            }

            // key 값 존재 여부 확인 하는 방법
            Console.WriteLine("name key exist? {0}", hashtable.ContainsKey("name"));
            Console.WriteLine("address key exist? {0}", hashtable.ContainsKey("address"));

            // value 존재 여부 확인 하는 방법
            Console.WriteLine("철수 value exist? {0}", hashtable.ContainsValue("철수"));
            Console.WriteLine("여자 value exist? {0}", hashtable.ContainsValue("여자"));
        }
    }
}