using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    interface IOperations<T>
    {
        void Add(T item);
        void Del(int index);
        void Print();
    }

    class PO : IEquatable<PO>
    {
        private string name;
        private string functions;
        private float cost;

        public PO(string name, string functions, float cost)
        {
            this.name = name;
            this.functions = functions;
            this.cost = cost;
        }

        public override string ToString()
        {
            return String.Format("Software\n" +
                                 "Name: {0}\n" +
                                 "Functions: {1}\n" +
                                 "Cost: {2}", name, functions, cost);
        }

        public bool Equals(PO el)
        {
            if (name == el.name && functions == el.functions && cost == el.cost)
                return true;
            else
                return false;
        }
    }

    class Array<T> : IOperations<T> where T : IEquatable<T>
    {
        private List<T> list;

        public int Size
        {
            get { return list.Count; }
        }

        public Array()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Del(int index)
        {
            list.RemoveAt(index);
        }

        public void Print()
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Array<int> arrayInt = new Array<int>();
                arrayInt.Add(5);
                arrayInt.Add(10);
                arrayInt.Add(7);
                arrayInt.Print();

                Array<double> arrayDouble = new Array<double>();
                arrayDouble.Add(2.28);
                arrayDouble.Add(1.488);
                arrayDouble.Add(1.337);
                arrayDouble.Print();

                Array<PO> arrayPO = new Array<PO>();
                arrayPO.Add(new PO("Word", "text processing", 20.5f));
                arrayPO.Add(new PO("Saper", "play", 0.1f));
                arrayPO.Add(new PO("Windows", "OS", 200));
                arrayPO.Print();

                arrayInt = null;
                arrayInt.Add(2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception\n" + e);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}