using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace SHARP_15
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcRunTime();
            DomainInfo();
            Threading();
            ThreadAim();
            Timer();
            Console.ReadKey();
        }

        public static void ProcRunTime()
        {
            Process[] proc = Process.GetProcesses();

            foreach (Process item in proc)
            {
                Console.WriteLine("Procces: {0}, {1}, {2}\n",item.ProcessName, item.Id, item.BasePriority );
            }
        }

        public static void DomainInfo()
        {
            AppDomain newD = AppDomain.CreateDomain("Domain2");
            newD.Load("Serializing");
            Console.WriteLine("Домен2: {0}", newD.FriendlyName);

            Assembly[] assemblies1 = newD.GetAssemblies();
            foreach (Assembly asm in assemblies1)
            Console.WriteLine("Сборка: " + asm.GetName().Name);
            Console.WriteLine();

            AppDomain.Unload(newD);

            AppDomain currentD = AppDomain.CurrentDomain;
            AppDomainSetup current2 = currentD.SetupInformation;
            Console.WriteLine($"Текущий домен: {currentD}, {current2}");

            Assembly[] assemblies2 = currentD.GetAssemblies();
            foreach (Assembly asm in assemblies2)
            Console.WriteLine("Сборка: " + asm.GetName().Name);
            Console.WriteLine();
        }

        public static void Threading()
        {
              Random rnd = new Random();
              int[] mas = new int[12];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(0, 100);
                Console.Write(mas[i] + " ");
                File.AppendAllText("File.txt", $"{mas[i]} "); //string.Join(" ", mas[i])
                Console.WriteLine("Имя: {0} \nПриоритет: {1}, \nЖивой?: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.Priority, Thread.CurrentThread.IsAlive);
                Thread.Sleep(1000);
            }
        }

        public static void ThreadAim()
        {
            MyThread mt = new MyThread();
            mt.Thread1();
            Thread backgroundThread = new Thread(new ThreadStart(mt.Thread2));
            backgroundThread.Start();
        }

        public class MyThread
        {
            Random randomizer = new Random();
            int[] shrek = new int[30];
            public void Thread1()
            {
                Console.WriteLine("Current thread #1 priority: " + Thread.CurrentThread.Priority);
                for (int i = 0; i < shrek.Length; i++)
                {
                    shrek[i] = randomizer.Next(0, 100);
                    if (shrek[i] % 2 == 0)
                    {
                        Console.Write("Fisrt thread: " + shrek[i] + "\n");
                        Thread.Sleep(1000);
                    }
                    if (i == 5)
                    {
                        Thread g = new Thread(Thread2);
                        g.Start();
                        Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                        Console.WriteLine("Current thread #1 priority: " + Thread.CurrentThread.Priority);
                    }
                    if (i == 15)
                    {
                        Thread.CurrentThread.Priority = ThreadPriority.Highest;
                        Console.WriteLine("Current thread #1 priority: " + Thread.CurrentThread.Priority);
                    }

                }
                Console.WriteLine();
            }
            public void Thread2()
            {
                Console.WriteLine("Current thread #2 priority: " + Thread.CurrentThread.Priority);

                for (int i = 0; i < shrek.Length; i++)
                {
                    if (shrek[i] % 2 == 1)
                    {
                        Console.Write("Second thread: " + shrek[i] + "\n");
                        Thread.Sleep(200);
                    }
                    if (i == 5)
                    {
                        Thread.CurrentThread.Priority = ThreadPriority.Highest;
                        Console.WriteLine("Current thread #2 priority: " + Thread.CurrentThread.Priority);
                    }
                    if (i == 25)
                    {
                        Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                        Console.WriteLine("Current thread #2 priority: " + Thread.CurrentThread.Priority);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Timer()
        {
            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 5000);
            void Count(object obj)
            {
                int x = (int)obj;
                for (int i = 1; i < 9; i++, x++)
                {
                    Console.WriteLine("{0}", x * i);
                }
            }
        }
    }
}
