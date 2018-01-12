using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Преметивные типы в C# 
         SByte bte = 8;
         Int32 i32 = 5;
         Int64 i64 = 5;
         Int16 i16 = 5;
         Byte ubt = 192;
         UInt16 ui16 = 16;
         UInt32 ui32 = 1651513;
         UInt64 ui64 = 1657856875;
         Char ch = 'a';
         Boolean bol = true;
         Single sng = 12.4f;
         Double db = 12.55;
         Decimal dcm = 111.1m;
         String str = "gaga";
         Object obj = new Object();


            // Явное присваивание
            i32 = 5;
            bte = (SByte)ubt;
            Int32 ii32 = (Int32)i64;
            Byte btta = (Byte)ch;
            Char ch1 = (Char)ui16;
            // Не явное присваивание
            dcm = ui16;
            i32 = i16;
            i64 = i32;
            Single s = i32;
            Single s2 = ch;
            Double B = ubt;

            // Упаковка и распаковка значимых типов
            Object l = i16;
            UInt32 z = (UInt32)(Int16)l;
            Object lol = ubt;
            Char c1 = (Char)(Byte)lol;

            // Неявное типизированная переменая
            var aa = new[] { 2, 3, 4, 5 };
            var aa1 = 1;
            var aa2 = new List<int>(new int[]{ 1, 2, 4 });
            Console.WriteLine(aa.GetType());
            Console.WriteLine(aa1.GetType());
            Console.WriteLine(aa2.GetType());

            // Nullabe 
            int? n1 = null;
            int? n2 = 2;
            // если левый операнд не нуль, то он его выводит
            int y = n1 ?? 1;
            int x = n2 ?? 3;
            Console.WriteLine(y + "\t" + x);

            Nullable<Int64> z1 = 50000;
            if (z1.HasValue) // проверет если данный операнд индифецирован то выводит значение
            {
                Console.WriteLine(z1.Value); 
            }

            string st = "hello";
            string st2 = "hello";
            string st3 = "Bob";
            int stn = String.Compare(st, st2);
            int cmp = st.CompareTo(st2); // второй способ
           

            // сравнить строки
            if (stn == 0 || cmp == 0)
            {
                Console.WriteLine("Строки равны");
            }
            else
            {
                Console.WriteLine("Строки не равны");
            }
            /* выполнить сцепление(конкатенацию), копирование, выделение подстроки, разделение строки на слова,
            вставка подстроки в заданную позицию, удаление заданной подстроки
             */
            Console.WriteLine();
            Console.WriteLine(st + st2 + st3);

            st = String.Copy(st3);
            Console.WriteLine(st);

            st = "privet mir. hah aaaa . agasdg";
            Console.WriteLine(st.Substring(6, 5));

            Console.WriteLine(String.Join(" ", st.Split('.')));

            char[] delims = ".:".ToCharArray();
            string stdel = "privet.mir:hah:aaaa.agasdg";
            string[] words = stdel.Split(delims);
            foreach (string name in words)
                Console.WriteLine(name);

            Console.WriteLine(st.Insert(6, " LIKE A BOSS"));

            Console.WriteLine(st.Remove(6, 4));

            // создайте пустую строку и null строку и что нибудь выполнить
            String empty = "";
            String nullst = null;
            empty = empty.Insert(0, "BOB");
            Console.WriteLine(empty);
            try
            {
                nullst = nullst.Insert(0, "BOB");
                Console.WriteLine(nullst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
            // задание d
            StringBuilder stb = new StringBuilder("kjasdgjaipjg;oiaaksdjg");
            stb.Remove(3, 4);
            stb.Append("KEKS");
            stb.Insert(0, "LOL");
            Console.WriteLine(stb);

            // Массивы

            const int sz = 3;
            int[,] mass = new int[sz, sz] { { 3, 7, 6 }, { 4, 2, 3 }, { 7, 2, 1 } };
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    Console.Write(mass[i, j] + " ");
                }
                Console.WriteLine();
            }
            
            ///////

            String[] strArr = { "lol", "kek", "zzz" };

            foreach (String g in strArr)
            {
                Console.WriteLine(g);
            }

            Console.WriteLine($"\tДлинна массива = {strArr.Length}");
            
            
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("наше значение: ");
            strArr[num - 1] = Console.ReadLine();

            Console.WriteLine();
            foreach (String g in strArr)
            {
                Console.WriteLine(g);
            }
            ///////
            
            double[][] mas2 = new double[3][];
            mas2[0] = new double[1];
            mas2[1] = new double[2];
            mas2[2] = new double[3];
            Console.WriteLine("Введите массив: ");
            for (int i = 0; i < mas2.Length; i++)
            {
                Console.WriteLine($"Введите {mas2[i].Length} числа: ");
                int j = 0;
                foreach (String g in Console.ReadLine().Split(' '))
                {
                    mas2[i][j] = Convert.ToDouble(g);
                    j++;
                }
            }

            Console.WriteLine("\nВведенный массив: ");
            foreach (double[] arr in mas2)
            {
                foreach (double value in arr)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
           ////////////
            var varIntg = new int[5];
            var varStrr = "строка";


            ////////////////////////////////////



            var MyTuple = (ammount: 10, st: "Hi", chr: 'z', st2: "eeee", ulng: (ulong)1337);

            Console.WriteLine(MyTuple);
            Console.WriteLine(MyTuple.ammount + " " + MyTuple.chr + " " + MyTuple.st2);

            (int count, string stroka1, char chr, string stroka2, ulong ulngint) = MyTuple;
            Console.WriteLine(count + " " + stroka1 + " " + chr + " " + stroka2 + " " + ulngint);

            
            (int first, string second, char third, string four, ulong five) tuple2 = (123, "sdfsg", 'x', "four", 123);
            int cmpTuple = MyTuple.CompareTo(tuple2);


            
            if (cmpTuple == 0)
            {
                Console.WriteLine("Картежи одинаковые");
            }
            else {
                Console.WriteLine("Картежи разные");
            }

            //////////////////////

            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            (int, int, int, char) CortageF(int[] arr, string strin)
            {
                int min = arr[0];
                int max = arr[0];
                int sum = arr[0];
                char c = strin[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                    }
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                    sum += arr[i];
                }

                return (max, min, sum, c);
            }

            
            Console.WriteLine(CortageF(array, "Slim Shady"));
        }
    }
}
