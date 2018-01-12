using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate void Hello();
    public delegate void Action<T>(T obj);
    class Program
    {
        public static void Main(string[] args)
        {
            Hello hello = () => Console.WriteLine("Сработал делегат без параметров!\n");
            hello();
            Console.WriteLine("------------------------------------------------------------------------------\n\n");
            User Buiko = new User("Programmer1", 0);
            User Pozhar = new User("Programmer2", 0);
            // Добавляем обработчики события
            Buiko.DUpgrade += Show_Message;
            Buiko.DWork += Show_Message;
            Pozhar.DUpgrade += Show_Message;
            Pozhar.DWork += Show_Message;
            Console.WriteLine("Upgrade первого программиста\n");
            Buiko.Upgrade();
            Console.WriteLine("Попробуем еще раз сделать Upgrade\n");
            Buiko.Upgrade();
            Console.WriteLine("Выполняет работу\n");
            Buiko.Work();
            Console.WriteLine("Попробуем еще раз\n");
            Buiko.Work();
            Console.WriteLine("------------------------------------------------------------------------------\n\n");
            Console.WriteLine("Второй программист Upgrade\n");
            Pozhar.Upgrade();
            Console.WriteLine("Повторим Апгрейд \n");
            Pozhar.Upgrade();
            Console.WriteLine("Пусть выполнит работу \n");
            Pozhar.Work();
            Console.WriteLine("Еще раз\n");
            Pozhar.Work();
            Console.WriteLine("------------------------------------------------------------------------------\n\n");
            Console.WriteLine("Теперь методы работы со строкой");
            Action<string> op;
            op = AddSymbols;
            Console.Write("Вот наша строка: ");
            string stroka = "я  ем людей, ето  вкусно";
            Console.WriteLine(stroka);
            Console.Write("Добавим символов: ");
            op(stroka);
            Console.Write("Удалим лишние пробелы и знаки: ");
            op = RemoveProbelsAndZnaki;
            op(stroka);
            Console.Write("Изменим регистр первой буквы: ");
            op = CapsLock;
            op(stroka);
            Console.ReadLine();
        }
        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
        public static void RemoveProbelsAndZnaki(string str)
        {
            var words = str.Split(new[] { ',', '.', ' ', ';', ':', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(string.Join(" ", words));
        }
        public static void CapsLock(string str)
        {
            Console.WriteLine(str.ToUpper());
        }
        public static void AddSymbols(string str)
        {
            str = str.Insert(1, "*");
            str = str.Insert(5, "*");
            str = str.Insert(10, "*");
            str = str.Insert(15, "*");
            str = str.Insert(20, "*");
            Console.WriteLine(str);
        }
    }

}
class User
{
    // Объявляем делегат
    public delegate void UserStatus(string message);

    public event UserStatus DUpgrade;

    public event UserStatus DWork;
    string version = DateTime.Now.ToString();
    public int _current_version;
    public string _name;
    public User(string name, int current_version)
    {
        current_version = _current_version;
        name = _name;
    }
    int upgrade = 0;
    public void Upgrade()
    {
        if (upgrade == 0)
        {
            if (DUpgrade != null)
                DUpgrade($"Программист был обновлен до версии {version}\n");
            upgrade++;
        }
        else
        {
            if (DUpgrade != null)
                DUpgrade("Программист уже обновлен!\n");
        }
    }
    int work = 0;
    public void Work()
    {
        if (work == 0)
        {
            if (DWork != null)
                DWork("Программист работает\n");
            work++;
        }
        else
        {
            if (DWork != null)
                DWork("Программист уже работает!\n");
        }
    }

}