using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp_Vector_2
{
    class Program
    {

        // Не менее трех конструкторов (с параметрами  и без, а также с параметрами по умолчанию
        // статический конструктор (конструктор типа)
        // определите закрытый конструктор; предложите варианты его вызова
        // поле - только для чтения (например, для каждого экземпляра сделайте поле только для чтения ID - равно некоторому уникальному номеру (хэшу) вычисляемому автоматически на основе инициализаторов объекта); 
        // поле- константу

        // свойства (get, set) – для всех поле класса (поля класса должны быть закрытыми) Для одного из свойств ограните доступ по set
        //  в одном из методов класса для работы с аргументами используйте ref - и out-параметры

        // создайте в классе статическое поле, хранящее количество созданных объектов (инкрементируется в конструкторе) и статический метод вывода информации о классе

        // сделайте касс partial 

        //переопределяете методы класса Object: Equals, для сравнения объектов,  
        // GetHashCode; для алгоритма вычисления хэша руководствуйтесь стандартными рекомендациями, ToString – вывода строки – информации об объекте



        static void Main(string[] args)
        {
            Console.WriteLine($"j = {Vector.j} k = {Vector.k} l = {Vector.l}"); // статический конструктор запрещает создание объекта
            //Vector vec = new Vector(); // конструктор по умолчанию
            //Console.WriteLine("x = {0,2} y = {1,2} z = {2,2} readonly = {3,2}", vec.x, vec.y, vec.z);
            Vector vec2 = new Vector(3, 2);
            Console.WriteLine("x = {0,2} y = {1,2} z = {2,2} readonly = {3,2}", vec2.x, vec2.y, vec2.z, vec2.rd);
            Vector vec3 = new Vector(2, 3, 5);
            Console.WriteLine($"x = {vec3.x} y = {vec3.y} z = {vec3.z} readonly = {vec3.rd}");
            Vector acc = new Vector();
            Console.WriteLine($"Аксессор = {acc.c}");
            acc.c = 228;
            Console.WriteLine($"Аксессор = {acc.c}");


            int p = 1, o = 2;
            int k = Vector.Eeasy(ref p, ref o);
            Console.WriteLine(k);

            Console.WriteLine(Vector.RefCount);

            Console.WriteLine(Vector.Getinfo());

            /////////////////// partial test
            Vector vpar = new Vector { book = new Vector.Book { Title = "Nakki", Author = "me" } };
            Console.WriteLine("{0} {1}", vpar.book.Title, vpar.book.Author);
            ///////////////////

            persone pn = new persone("Nakki_C#");
            persone pn1 = pn;
            persone pn2 = new persone(pn1.ToString());
            Console.WriteLine("\t\t {0}", pn1.ToString());

            Console.WriteLine("sravnenie pn i pn1 = {0}", pn.Equals(pn1));
            Console.WriteLine("sravnenie pn i pn1 = {0}", pn1.Equals(pn2));

            Console.WriteLine("person1a and person1b: {0}", ((object)pn).Equals((object)pn1));
            Console.WriteLine("person1a and person2: {0}", ((object)pn1).Equals((object)pn2));
            Console.WriteLine("hashCode = {0}", pn.GetHashCode());


            double u2 = 6, p2 = 8, co = 45;
            double ggg = Vector.Scal(u2, p2, co);
            Console.WriteLine(ggg);


            double u3 = 6, p3 = 8;
            double ggg2 = Vector.ScalS(u3, p3);
            Console.WriteLine(ggg2);

            double u4 = 6, p4 = 8;
            double ggg3 = Vector.ScalV(u4, p4);
            Console.WriteLine(ggg3);

            const double u5 = 6, p5 = 8;
            double ggg4 = Vector.ScalU(u5, p5);
            Console.WriteLine(ggg4);

            Vector[] Vovan = new Vector[3];
            for (int i = 0; i < 3; i++)
            {
                Vovan[i] = new Vector();
                Console.Write(Vovan[i].x + " ");
            }
            Console.WriteLine();

            Vector vector1 = new Vector(30); // создаем экземпляры класса вектор
            Vector vector2 = new Vector(10);

            vector1.MTV();
            Console.WriteLine(); // наполняем векторы значениями
            vector2.MTV2();

            Console.WriteLine();
            Vector[] Vovan2 = new Vector[2];  // создаем массив объектов


            //int[,][,,][] arr22 = new int[3, 3][,,][]; 


            Vovan2[0] = vector1;
            Vovan2[1] = vector2;
            Vovan2[0].GetIn();
            Vovan2[1].GetIn();
            Console.WriteLine();
            Vovan2[0].Absv();
            Vovan2[1].Absv();
            Console.WriteLine();


            Console.WriteLine("Write to check the Vector in Object");


            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Поиск введенного вектора по двум массивам...");
            for (int i = 0; i < Vovan2.Length; i++)
            {
                Console.WriteLine("Vector {0}", i);
                Vovan2[i].Search(ref a);
            }
            




            int max;
            vector1.GetMax(out max);
            Console.WriteLine("Maximalnoe znachenie vector1: " + max);
            vector2.GetMax(out max);
            Console.WriteLine("Maximalnoe znachenie vector2: " + max);

            double[] ver = vector1.Sc();

            for (int i = 0; i < ver.Length; i++)
            {
                Console.Write(ver[i] + " ");
            }

            double[] ver2 = vector2.Sc();

            for (int i = 0; i < ver.Length; i++)
            {
                Console.Write(ver[i] + " ");
            }
        }
    }

    class Vector
    {
        public int x, y, z;
        public static int j, k, l;
        public readonly int rd;
        public const int g = 1000;
        private int size;
        private int[] arr;

        public static ulong RefCount { get; private set; }



        //private Vector() { }


        static Vector() //статический конструктор
        {
            j = 3;
            k = 2;
            l = j + k;
            RefCount++;
        }

        public Vector() // конструктор по умолчанию
        {
            x = 1;
            y = 1;
            z = j + k;
            RefCount++;

        }

        public Vector(int size)
        {
            arr = new int[size];
            this.size = size;


        }


        public Vector(int a, int b) // конструктор с параметрами
        {
            x = a;
            y = b;
            z = a + b;
            rd = x + y + z;
            RefCount++;
        }

        public Vector(int a, int b, int c) // конструктор с параметрами
        {
            x = a;
            y = b;
            z = c;
            rd = x + y + z;
            RefCount++;
        }

        public int c
        {
            get
            {
                return j;
            }
            set
            {
                j = value;
            }
        }

        public static int Eeasy(ref int x, ref int y)
        {
            x += 1;
            y *= 2;
            int z = x * y;
            return z;
        }


        private static string about = "Данная програма создана by NakkiCalvin";
        public static string Getinfo()
        {
            return about;
        }


        public partial class Book
        {
            public string Title { get; set; }
        }
        public partial class Book
        {
            public string Author { get; set; }
        }

        public Book book;
        /// <summary>
        /// ///////////////////
        /// </summary>

        public void Absv()
        {
            int[] outArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                outArr[i] += (arr[i] * arr[i]);
            }
            Console.Write("\nМодуль векторов -->  ");
            foreach (int a in outArr)
            {
                Console.Write(a + " ");
            }
        }



        public static double Scal(double u, double p, double co)
        {
            double S = Math.Cos(co) * Math.Abs(u) * Math.Abs(p);

            return S;
        }

        public static double ScalS(double u, double p)
        {
            double S = Math.Abs(u) + Math.Abs(p);

            return S;
        }



        public static double ScalV(double u, double p)
        {
            double S = Math.Abs(p) - Math.Abs(u);

            return S;
        }

        public static double ScalU(double u, double p)
        {
            double S = Math.Abs(p) * Math.Abs(u);

            return S;
        }

        public static int size1;
        public void MTV()
        {
            Console.WriteLine("Vector 1: ");
            size1 = arr.Length;
            for (int i = 0; i < size1; i++)
            {
                arr[i] += i;
                Console.Write(arr[i] + " ");
            }

        }

        public static int size2;
        public void MTV2()
        {
            Console.WriteLine("Vector 2: ");
            size2 = arr.Length;
            for (int i = 0; i < size2; i++)
            {
                arr[i] += 10;
                Console.Write(arr[i] + " ");
            }

        }


        public void Search(ref int a)
        {
            foreach (int i in arr)
            {
                if (i == a)
                {
                    Console.WriteLine(a + " - Такой вектор существует");
                    return;
                }
              
            }
            Console.WriteLine("В данном масиве нет такого вектора");
        }

        public double[] Sc()
        {
            double[] s = new double[arr.Length];
            Console.WriteLine("\nСкалярное произведение: ");
            for (int i = 0; i < arr.Length; i++)
            {
                s[i] = Math.Abs(arr[i]) * Math.Abs(arr[i]);
            }
            return s;
        }



        public void GetMax(out int value)
        {
            value = 0;
            foreach (int el in arr)
            {
                if (el > value)
                {
                    value = el;
                }
                
            }
        }

        public void GetIn()
        {
            Console.WriteLine("\nВывод вектора на экран ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");

            }
        }
    }

    class persone
    {
        private string Pname;

        public persone(string name)
        {
            this.Pname = name;
        }

        public override string ToString()
        {
            return this.Pname;
        }

    }









}
