using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIP4
{
    class Owner
    {
        private readonly int id;
        private readonly string name;
        private readonly string company;

        public Owner(int id, string name, string company)
        {
            this.id = id;
            this.name = name;
            this.company = company;
        }
    }

    class List
    {
        class Date
        {
            string date;
            public Date(string date)
            {
                this.date = date;
            }
        }

        private readonly Date date = new Date("10.10.2017");
        private readonly Owner owner = new Owner(1337, "Vovan", "BSTU");
        private static Random rand = new Random(DateTime.Now.Millisecond);

        private int[] MyList;
        private int size;

        public List(int size = 10)
        {
            MyList = new int[size];
            this.size = size;
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public void ResizeArr(int size)
        {
            System.Array.Resize(ref MyList, size);
            this.size = size;
        }

        public void RandomInitializing()
        {
            for (int i = 0; i < MyList.Length; i++)
                MyList[i] = rand.Next(-1, 5);
        }

        public void Print()
        {
            for (int i = 0; i < MyList.Length; i++)
                Console.Write("{0, 5}", MyList[i]);
            Console.WriteLine();
        }

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= MyList.Length)
                {
                    Console.WriteLine("Incorrect index. Return zero");
                    return 0;
                }
                return MyList[i];
            }
            set
            {
                if (i < 0 || i >= MyList.Length)
                {
                    Console.WriteLine("Incorrect index. Nothing installed");
                }
                else
                    MyList[i] = value;
            }
        }

        public static List operator +(List a, List b)
        {
            List result = new List(a.size + b.size);
            int l = 0;
            for (int i = 0; i < a.size; i++)
            {
                l++;
                result[i] = a[i];
            }
            for (int i = 0; i < b.size; i++)
            {
                result[i + l] = b[i];
            }
            return result;
        }
        public static List operator --(List c)
        {
            List result = new List(c.size);
            for (int i = 0; i < c.size - 1; i++)
            {
                result[i] = c[i + 1];
            }
            result.ResizeArr(result.Size - 1);
            return result;
        }

        private static bool NullList(List arr)
        {
            for (int i = 0; i < arr.size; i++)
            {
                if (arr[i] == 0)
                    return true;
            }
            return false;
        }

        public static bool operator true(List arr)
        {
            return NullList(arr);
        }

        public static bool operator false(List arr)
        {
            return !NullList(arr);
        }

        public static explicit operator int(List arr)
        {
            return arr.size;
        }

        private static bool IsEquals(List arr1, List arr2)
        {
            if (arr1.size != arr2.size)
                return false;

            for (int i = 0; i < arr1.size; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;
        }

        public static bool operator ==(List arr1, List arr2)
        {
            return IsEquals(arr1, arr2);
        }

        public static bool operator !=(List arr1, List arr2)
        {
            return !IsEquals(arr1, arr2);
        }


    }

    static class MyMath
    {
        public static int Max(List arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Size; i++)
            {
                int el = arr[i];
                if (el > max)
                    max = el;
            }

            return max;
        }

        public static int Min(List arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Size; i++)
            {
                int el = arr[i];
                if (el < min)
                    min = el;
            }

            return min;
        }

        public static int Sum(List arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Size; i++)
                sum += arr[i];

            return sum;
        }

        public static void DelElemList(this List arr, ref int a)
        {
            int k = 0;
            for (int i = 0; i < arr.Size; i++)
            {
                if (arr[i] == a)
                    k++;
                else
                    arr[i - k] = arr[i];
            }

            arr.ResizeArr(arr.Size - k);
        }

        public static char HasInt(this string s)
        {
            char w = ' ';
            char[] array_of_chars = s.ToCharArray();
            for (int i = array_of_chars.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(array_of_chars[i]))
                {
                    //Console.WriteLine(array_of_chars[i]);
                    w = array_of_chars[i];
                    break;
                }
                else if (i == 0)
                {
                    Console.WriteLine("no digits in the string");
                }
            }
            return w; 
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            List arr1 = new List();
            arr1.RandomInitializing();
            arr1.Print();

            List arr2 = new List(11);
            arr2.RandomInitializing();
            arr2.Print();

            List arr = arr1 + arr2;
            arr.Print();

            List arr3 = --arr;
            arr3.Print();

            Console.Write("true   если список пуст: ");
            if (arr)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            Console.WriteLine("Первый список равен второму? " + (arr1 == arr2));

            Console.Write("Удаление заданного элемента из списка: ");
            int a = Convert.ToInt32(Console.ReadLine());
            arr.DelElemList(ref a);
            arr.Print();


            string s = "Pr44ivet hah51aha Agg5gg!";

            Console.WriteLine("string {0} contains {1}", s, s.HasInt());

            Console.WriteLine("Size: " + (int)arr);

            
        }
    }
}