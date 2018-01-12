using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Collections;

namespace Рефлексия
{
    class Program
    {

        static void Main(string[] args)
        {
            Student s1 = new Student();
            Reflector reflector = new Reflector();
            reflector.AllInfo(s1);
            reflector.Method(s1);
            reflector.Fields(s1);
            reflector.Interface(s1);
            string s = Console.ReadLine();
            reflector.Task5(s, "value");

            reflector.Task6(s1, "OnUp");
        }
    }

    public class Reflector
    {
        string text = "";
        public void AllInfo(object m)
        {
            Type t = m.GetType();
            Console.WriteLine("Вся информация о классе ");
            string path = @"C:\text.txt";
            foreach (MemberInfo mi in t.GetMembers())
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);

                text = text + mi.DeclaringType + " " + mi.MemberType + " " + mi.Name + '\n';

            }

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write(text);
            }

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                text = sr.ReadToEnd();
            }
            Console.WriteLine("\n");




        }

        public void Method(object im)
        {
            Type t = im.GetType();

            foreach (MethodInfo m in t.GetMethods())
            {
                Console.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");
                // Вывести параметры методов
                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
                    if (i + 1 < p.Length) Console.Write(", ");
                }
                Console.Write(")\n");
            }

            Console.WriteLine("\n");
        }


        public void Fields(object im)
        {
            Type t = im.GetType();
            Console.WriteLine("ПОля и свойства");
            foreach (MemberInfo mi in t.GetFields())
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            }

            foreach (MemberInfo mi in t.GetProperties())
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            }
            Console.WriteLine("\n");
        }


        public void Interface(object im)
        {
            Type t = im.GetType();
            Console.WriteLine("Интерфейсы");
            foreach (MemberInfo mi in t.GetInterfaces())
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            }
            Console.WriteLine("\n");
        }


        public void Task5(string im, object par)
        {
            Type t = Type.GetType("Рефлексия." + im);

            foreach (MethodInfo m in t.GetMethods())
            {
                ParameterInfo[] p = m.GetParameters();

                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].Name == par.ToString())
                    {
                        Console.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");
                        // Вывести параметры методов


                        for (int j = 0; j < p.Length; j++)
                        {
                            Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
                            if (i + 1 < p.Length) Console.Write(", ");
                        }
                        Console.Write(")\n");
                    }
                }
            }

            Console.WriteLine("\n");

        }


        public void Task6(object im, string par)
        {
            string path = @"C:\text2.txt";
            string buf = "";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                buf = sr.ReadToEnd();
            }
            int p;
            p = Convert.ToInt32(buf);
            Console.WriteLine(buf);
            Type t = im.GetType();

            // создаем экземпляр класса Program
            object obj = Activator.CreateInstance(t);

            // получаем метод GetResult
            MethodInfo method = t.GetMethod(par);

            // вызываем метод, передаем ему значения для параметров и получаем результат
            method.Invoke(obj, new object[] { p });

        }
    }

    public class Student : IList
    {
        public int m = 500;

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void OnUp(int m)
        {

            Console.WriteLine("Current money: " + m);
        }

        public void OnDown()
        {
            Console.WriteLine($"Student Down (money {m}");
            m = m - 100;
            Console.WriteLine("Current money: " + m);

        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Tokar
    {
        public int m = 1500;
        public void OnUp()
        {

            Console.WriteLine("Tokar UP");
            m = m + 100;
            Console.WriteLine("Current money: " + m);
        }

        public void OnDown()
        {
            Console.WriteLine("Tokar Down");
            m = m - 100;
            Console.WriteLine("Current money: " + m);

        }
    }
}