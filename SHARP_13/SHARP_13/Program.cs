using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;


namespace FIles
{
    class Program
    {
        public static DateTime now = DateTime.Now;
        static void Main(string[] args)
        {
            #region
        
           
            string buf = "";
            ABELog lolek = new ABELog();
            lolek.EventIO += ABELog.OnEvent;
            Console.WriteLine("Введите строка для записи");
            lolek.Write(Console.ReadLine());
            Console.WriteLine("Построчныый вывод из файла: " + lolek.path);
            lolek.Read(lolek.path);
            Console.WriteLine("Введите строку для поиска");
            buf = Console.ReadLine();
            Console.WriteLine("Поиск по строке");
            lolek.Search(buf);
            ///////////////////////////////////////////////////////////
            ABEDiskInfo info = new ABEDiskInfo();
            info.InfoOfDrivers();
            //////////////////////////
            ABEFileInfo fileInfo = new ABEFileInfo();
            fileInfo.InfoOfFiles(lolek.path);
        
            #endregion

            ABEFileManager manager = new ABEFileManager();

            manager.ListOfFiles();
            manager.Task2();

            manager.Task3(@"C:\", "txt");

            manager.Task4();

            manager.Zip();
        }

        class ABELog
        {
            public delegate void del(string m, string path);

            public event del EventIO;




            public string path = @"C:\abelogfile.txt";

            public void Write(string s)
            {
                string buf = "";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(s);
                    sw.Close();
                }

                Type type = typeof(ABELog);

                foreach (MethodInfo m in type.GetMethods())
                {
                    if (m.Name == "Write")
                    {
                        buf = m.Name;
                    }
                }

                EventIO(buf, path);
            }


            public void Read(string path)
            {
                string buf = "";

                Type type = typeof(ABELog);

                foreach (MethodInfo m in type.GetMethods())
                {
                    if (m.Name == "Read")
                    {
                        buf = m.Name;
                    }
                }

                EventIO(buf, path);
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }


                    sr.Close();

                }
            }


            public void Search(string search)
            {

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == search)
                        {

                            Console.WriteLine("Найдено совпадение " + line);
                            sr.ReadLine();
                            Console.WriteLine(sr.ReadLine());

                        }
                    }


                    sr.Close();

                }

            }

            public static void OnEvent(string m, string path)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {

                    sw.WriteLine("Пользователь вызвал метод: " + m);
                    sw.WriteLine("Время: " + now);
                }
            }

        }


        class ABEDiskInfo
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            public void InfoOfDrivers()
            {
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine("Название: {0}", drive.Name);
                    Console.WriteLine("Тип: {0}", drive.DriveType);
                    if (drive.IsReady)
                    {
                        Console.WriteLine("Объем диска: {0}", drive.TotalSize);
                        Console.WriteLine("Свободное пространство: {0}", drive.TotalFreeSpace);
                        Console.WriteLine("Метка: {0}", drive.VolumeLabel);
                    }
                    Console.WriteLine();
                }
            }

        }


        class ABEFileInfo
        {
            public void InfoOfFiles(string path)
            {

                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine("Имя файла: {0}", fileInf.Name);
                    Console.WriteLine("Путь : {0}", path);
                    Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                    Console.WriteLine("Размер: {0}", fileInf.Length);
                }
            }
        }

        class ABEFileManager
        {




            public void ListOfFiles()
            {
                string dirName = "C:\\";
                string[] dirs = Directory.GetDirectories(dirName);
                string[] files = Directory.GetFiles(dirName);
                if (Directory.Exists(dirName))
                {
                    Console.WriteLine("Подкаталоги:");

                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Файлы:");

                    foreach (string s in files)
                    {
                        Console.WriteLine(s);
                    }
                }



            }

            public void Task2()
            {
                string dirName = "C:\\";
                string[] dirs = Directory.GetDirectories(dirName);
                string[] files = Directory.GetFiles(dirName);
                DirectoryInfo directory = new DirectoryInfo("C:\\ABEInspect");
                directory.Create();

                string path = @"C:\ABEInspect\abedirinfo.txt";

                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Подкаталоги:");

                    foreach (string s in dirs)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Файлы:");

                    foreach (string s in files)
                    {
                        sw.WriteLine(s);
                    }

                    Console.WriteLine("Зaписано");

                }

                string newPath = @"C:\ABEInspect\NEWabedirinfo.txt"; ;
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);
                }
                File.Delete(@"C:\ABEInspect\abedirinfo.txt");


            }

            public void Task3(string dirName, string txt)
            {
                DirectoryInfo directory = new DirectoryInfo("C:\\ABEFiles");
                directory.Create();

                string[] files = Directory.GetFiles(dirName, "*." + txt);

                foreach (var s in files)
                {

                    FileInfo fileInf = new FileInfo(s);

                    if (fileInf.ToString() == s)
                    {
                        Console.WriteLine(s);

                        fileInf.CopyTo(@"C:\ABEFiles\" + fileInf.Name, true);

                    }
                }

                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\ABEInspect");
                dirInfo.Delete(true);
                Directory.Move(@"C:\ABEFiles", @"C:\ABEInspect\");



            }
            string startPath = @"C:\ABEInspect";
            string zipPath = @"C:\ABEInspect\result.zip";
            string extractPath = @"C:\ABEInspect\result";
            public void Task4()
            {

                try
                {

                    ZipFile.CreateFromDirectory(startPath, zipPath);


                }
                catch (Exception)
                {

                    Console.WriteLine("Архивация прошла успешно");
                }


            }

            public void Zip()
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                Console.WriteLine("Разархивация прошла успешно");
            }
            /*Создать класс XXXFileManager.
             * Набор методов определите самостоятельно.
             * С его помощью выполнить следующие действия:
             * a.Прочитать список файлов и папокзаданногодиска.
             * Создать директорийXXXInspect,создать текстовый 
             * файл xxxdirinfo.txtв нем и сохранить туда эту 
             * информацию.Создать копию файла и переименовать его.
             * Удалить первоначальныйфайл.b.Создать еще один директорийXXXFiles.
             * Скопироватьв неговсе файлы с заданным
             * расширением
             * из заданного пользователем директория. Переместить XXXFiles в
    XXXInspect.c.Сделайте архив из файлов директорияXXXFiles.
    Разархивируйте его в другой директорий.*/
        }
    }
}