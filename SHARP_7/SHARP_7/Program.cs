using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sh_5
{

    /// <summary>
    /// СТРУКТУРА ПЕРЕЧИСЛЕНИЕ 
    /// </summary>
    partial class LOOk
    {
        int look1 = 12;
    }

    #region struct
    struct UserInfo
    {
        public string Name;
        public byte Age;

        public UserInfo(string Name, byte Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public void WriteUserInfo()
        {
            Console.WriteLine("Имя: {0}, возраст: {1}", Name, Age);
        }
    }
    #endregion
    #region enum
    enum UI : long { Name, Family, ShortName = 5, Age, Sex }
    #endregion
    public class Lampa
    {
        public string namepr;
        public int MassaPresenta;
        public Lampa()
        {
            this.namepr = "lampa nakalivaniya";
            this.MassaPresenta = 1900;
        }
        public Lampa(int a)
        {
            this.namepr = "lampa nakalivaniya";
            this.MassaPresenta += a;
        }
    }

    public class Container
    {
        public List<Lampa> byk;
        protected int msOfpr { get; set; }

        public List<Lampa> Add(Lampa p)
        {
            byk.Add(p);
            return byk;
        }

        public void Info()
        {
            foreach (Lampa pp in byk)
            {
                Console.WriteLine(pp.ToString());

            }
        }

        public void MasOfPresents()
        {
            foreach (Lampa pp in byk)
            {
                msOfpr += pp.MassaPresenta;
            }
            Console.WriteLine("Масса подарков — " + msOfpr + "кг");
        }



    }




    /// <summary>
    /// СТРУКТУРА ПЕРЕЧИСЛЕНИЕ 
    /// </summary>
    interface Itrade
    {
        void Show();
        void function();
    }
    abstract class Items
    {
        public int code1;
        public int code2;
        public int countitems;
        public virtual int Vich(int code1, int code2)
        {
            int ccd = code1 * 60 + code2;
            Console.WriteLine("{Уникальный код товара = {0}}", ccd);
            return ccd;

        }
        public abstract void function();
    }
    class KoncelarItems : Items, Itrade
    {
        public void Show()
        {
            Console.WriteLine("Название товара: {0}, уникальный код: {1}", this.nameofItem, codeitem);
        }
        public KoncelarItems(string name, int code)
        {
            this.code1 = 1;
            this.code2 = 53;
            this.countitems = 190;
            this.nameofItem = name;
            this.codeitem = code;
        }
        void Itrade.function()
        {
            Console.Write(" ");
        }
        public override void function()
        {

        }
        public string nameofItem;
        public int codeitem;
        public override string ToString()
        {
            return "Название товара: " + this.nameofItem + ";\nУникальный код: " + this.codeitem +
            "\nКолличество товаров на складе: " + base.countitems + "\n Хэш код -- " + base.code1 + "." + base.code2;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            KoncelarItems fil = (KoncelarItems)obj;
            if (this.nameofItem.CompareTo(fil.nameofItem) == 0)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 47;
            hash = string.IsNullOrEmpty(this.nameofItem) ? 0 : this.nameofItem.GetHashCode();
            hash = hash * 47 + this.codeitem.GetHashCode();
            return hash;
        }
        public override int Vich(int code1, int code2)
        {
            int ccd = code1 * 60 + code2;
            Console.WriteLine("уникальный код товара = {0}", ccd);
            Console.WriteLine("Override метод");
            return ccd;
        }
    }
    class Sweets : Items, Itrade
    {
        public void Show()
        {
            Console.WriteLine("Название товара: {0}, уникальный код {1}", this.name, this.ammount);
        }
        string name;
        int ammount;

        public Sweets(string name, int ammount) : base()
        {
            this.name = name;
            this.ammount = ammount;
        }
        public new int Vich(int code1, int code2)
        {
            int ccd = code1 * 60 + code2;
            Console.WriteLine("{Уникальный код товара = {0}}", ccd);
            Console.WriteLine("Скрытый метод");
            return ccd;
        }
        public override void function()
        {
            Console.WriteLine("Метод из базового класса Items перекрытый в классе Sweets");
        }
        void Itrade.function()
        {
            Console.WriteLine("Метод из базового класса Items перекрытый ЯВНО в классе Sweets");
        }
    }
    class Clock : KoncelarItems, Itrade
    {
        public new void Show()
        {
            Console.WriteLine("Название товара: {0}, уникальный код: {1}", base.nameofItem, base.codeitem);
            foreach (string str in Attachments)
            {
                Console.WriteLine("{0}, ", str);
            }
        }
        string[] Attachments;
        public Clock() : base("Часты", 13)
        {
            Console.WriteLine("Кол-во моделей часов на прилавке магазина:");
            int n = Convert.ToInt32(Console.ReadLine());
            Attachments = new string[n];
            Console.WriteLine("Введите название моделей: ");
            for (int i = 0; i < n; i++)
            {
                this.Attachments[i] = Console.ReadLine();
            }
            Console.WriteLine("Ввод завершен.");

        }
    }

    class Cake : Items, Itrade
    {
        public void Show()
        {
            //Console.WriteLine("Возрастное ограничение: ", this.ogranch);
            //Console.WriteLine("Имена персонажей");
            foreach (string str in namesofHero)
            {
                Console.WriteLine("{0}, ", str);
            }

        }
        public override void function()
        {
            Console.WriteLine("Метод из базового класса Items перекрытый в классе Cake");
        }
        //int ogranch;
        string[] namesofHero;
    }
    class Fluk : Produce
    {
        public void Show()
        {
            Console.WriteLine("Реклама продукта: {0}", this.product);
        }
        int dlit;
        string product;
        Fluk(int dlit, string product) : base("ЛОРД", "ВЕЙДЕР", 1001)
        {
            this.dlit = dlit;
            this.product = product;
        }
    }
    class Produce : Itrade
    {
        void Itrade.function()
        {
            Console.WriteLine("Переопределенный метод в классе Produce, м-да из интерфейса Itrade");
        }
        public void Show()
        {
            Console.WriteLine("{0} {1}, Год создания: {2}", this.firstName, this.secondName, this.yearofBirthday);
        }
        public Produce(string firstName, string secondName, int yearofBirthday)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.yearofBirthday = yearofBirthday;
        }
        string firstName;
        string secondName;
        int yearofBirthday;
    }
    sealed class Printer
    {
        public void iAmPrinting(Itrade someobj)
        {
            Console.WriteLine("Тип экземпляра, являющегося ссылкой на абстрактный класс: {0}", someobj.GetType());
        }
        public override string ToString()
        {
            return Convert.ToString("Класс с полиморфным методом");
        }
    }

    class Program
    {
        static int ExceptionExample(int f, int q)
        {
            if (f == 0)
            {
                Exception a = new Exception();
                a.HelpLink = "hz.by";
                a.Data.Add("Время", DateTime.Now);
                throw a;
            }
            return q / f;
        }

   

        static void Main(string[] args)
        {
            //int[] diagnoz = null;
            //Debug.Assert(diagnoz != null, "значения массива не могут быть null");

            try
            {
                int f = int.Parse(Console.ReadLine());
                int q = int.Parse(Console.ReadLine());
                ExceptionExample(f, q);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "\n\n");
                Console.Write(ex.TargetSite + "\n\n");
                Console.Write(ex.StackTrace + "\n\n");
                Console.Write(ex.HelpLink + "\n\n");
                if (ex.Data != null)
                {
                    Console.WriteLine("Свединия \n");
                    foreach (DictionaryEntry d in ex.Data)
                    {
                        Console.WriteLine("-> {0} {1}", d.Key, d.Value);
                        Console.WriteLine("\n\n");
                    }
                }
            }

            try
            {
                int zi = 300;
                if (zi > 255)
                {
                    throw new OverflowException();
                }

            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка доступного диапазаона\n");
                //throw;
            }
            finally
            {
                //Environment.Exit(0);
            }

            int ki = 0;
            int kj = 0;
            try
            {
                ki = int.Parse(Console.ReadLine());
                kj = int.Parse(Console.ReadLine());
            }
            catch (Exception ex) when (ex.GetType() != typeof(System.DivideByZeroException))
            {
                Console.WriteLine("Всё кроме формата");
            }

            //int c;
            //int f = 13;
            //int q = 1;
            //if (q == 1)
            //{
            //    throw new Exception("Zero devision");
            //}
            //else
            //{
            //    c = f / q;
            //}

            


            Items obj1 = new KoncelarItems("Бумага", 50);
            Console.Write(" {0}", obj1.Vich(obj1.code1, obj1.code2));
            Console.WriteLine();
            KoncelarItems obj2 = new KoncelarItems("Цветы", 52);

            obj2.Show();
            Itrade obj3 = new Clock();
            obj3.Show();

            Sweets obj4 = new Sweets("Грельяш", 1);
            obj4.Show();
            Produce obj5 = new Produce("Комунарка", " Завод сладких изделий", 1980);
            Object[] mass = { obj1, obj2, obj3, obj4, obj5 };
            Console.WriteLine("-------------------------------------------");
            foreach (Object i in mass)
            {
                Itrade obj = (Itrade)i;
                obj.Show();
            }
            Console.WriteLine("-------------------------------------------");
            Printer obz = new Printer();
            Itrade[] mdk = { (Itrade)obj1, obj2, obj3 };
            foreach (Itrade i in mdk)
            {
                obz.iAmPrinting(i);
            }

            //AA my = new BB();
            AA my = new CC();
            my.woll();

            A lol = new B();
            //lol.ZZZ();

            J o1 = new Z();
            J o2 = new K();
            o1 = o2;

            ////////////////// struct ////////////////// 
            UserInfo user1 = new UserInfo("Alexandr", 26);
            Console.Write("user1: ");
            user1.WriteUserInfo();
            UserInfo user2 = new UserInfo("Elena", 22);
            Console.Write("user2: ");
            user2.WriteUserInfo();

            // Показать главное отличие структур от классов
            user1 = user2;
            user2.Name = "Natalya";
            user2.Age = 25;
            Console.Write("\nuser1: ");
            user1.WriteUserInfo();
            Console.Write("user2: ");
            user2.WriteUserInfo();

            Console.ReadLine();
            ////////////////// struct ////////////////// 
            ////////////////// Enum ////////////////// 
            UI user;
            for (user = UI.Name; user <= UI.Sex; user++)
                Console.WriteLine("Элемент: \"{0}\", значение {1}", user, (int)user);
            ////////////////// Enum ////////////////// 
            Container b = new Container();
            b.byk = new List<Lampa>();
            Lampa swet1 = new Lampa();
            Lampa swet2 = new Lampa(10);
            Lampa swet3 = new Lampa(12);
            b.Add(swet1);
            b.Add(swet2);
            b.Add(swet3);
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            b.Info();

            b.MasOfPresents();

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------");
            Controller cont = new Controller();
            cont.Search(b.byk);
            cont.MassSorting(b.byk);
            foreach (Lampa p in b.byk)
            {
                Console.WriteLine(p.MassaPresenta + " " + p.namepr);
            }
            b.Info();

            Console.ReadKey();

            Container2 prr = new Container2();
            Control2 pis = new Control2(prr);
            pis.Install(new Lampa());


            
        }


    }
    class Container2 {
        private List<Lampa> po;

        public Container2()
        {
            po = new List<Lampa>();
        }
        public void Add(Lampa el) {
            po.Add(el);
        }
    }

    class Control2
    {
        private Container2 pr;
        public Control2(Container2 po)
        {
            this.pr = po;
        }
        public void Install(Lampa el) {
            pr.Add(el);
        }


    }


    public class Controller : Container
    {


        public void Search(List<Lampa> byk)
        {
            //int mass;
            //Console.WriteLine("Input the mass");
            //mass = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < byk.Count; i++)
            //foreach (Lampa pp in byk)
            {
                int max = byk[0].MassaPresenta;
                if (byk[i].MassaPresenta > max)
                {
                    Console.WriteLine("Найдено совпадение");
                    //Printer printer = new Printer();
                    //printer.iAmPrinting(pp);
                    Console.WriteLine(byk[i].MassaPresenta);
                }
                else
                {
                    Console.WriteLine(max);
                    break;
                }
            }

            return;
        }
        public List<Lampa> MassSorting(List<Lampa> byk)
        {


            for (int i = 0; i < byk.Count - 1; i++)
            {

                for (int j = i + 1; j < byk.Count; j++)
                {
                    if (byk[i].MassaPresenta > byk[j].MassaPresenta)
                    {
                        var temp = byk[i].MassaPresenta;
                        byk[i].MassaPresenta = byk[j].MassaPresenta;
                        byk[j].MassaPresenta = temp;
                    }
                }
            }

            return byk;
        }
    }


    public class A { public virtual void keks() { Console.WriteLine("GG"); } }
    public class B : A
    {
        //public override void keks() { Console.WriteLine("GG2"); }
        public void ZZZ() { }

    }

    public abstract class AA
    {
        public virtual void woll() { Console.WriteLine("a"); }
    }
    public class BB : AA { public override void woll() { base.woll(); Console.WriteLine("b"); } }
    class CC : BB { }



    class J { }

    class Z : J { }
    class K : J { }




}