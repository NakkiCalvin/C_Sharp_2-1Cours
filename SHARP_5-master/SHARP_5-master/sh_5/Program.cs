using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace sh_5
{
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
        public void iAmPrinting(Items someobj)
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
        static void Main(string[] args)
        {
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
            Console.ReadKey();
        }
    }
}