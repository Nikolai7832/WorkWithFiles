namespace DriveManager
{
    public class DirDeleter
    {
        public static bool IsAccesible(DirectoryInfo dir)
        {
            if (!dir.Exists)
            {
                Console.WriteLine("Такой директори не сущетсвует");
                return false;
            }
            try
            {
                dir.GetFiles();
                dir.GetDirectories();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Доступ к директории отсутсвует");
                return false;
            }
        }
        public static bool IsAccesible(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                Console.WriteLine("Такой директори не сущетсвует");
                return false;
            }
            else
            {
                try
                {
                    void Trying(string path)
                    {
                        
                        string[] dirs = Directory.GetDirectories(path);
                        foreach (string d in dirs)
                        {
                            string[] files = Directory.GetFiles(path);
                            foreach (string f in files)
                            { }
                            Trying(d);
                        }
                    }
                    string[] files = Directory.GetFiles(path);
                    foreach (string f in files)
                    { }
                    Trying(path);
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Доступ к директории отсутсвует");
                    return false;
                }
            }
        }
        public static int GetCatalogs(DirectoryInfo dir)
        {
            int i = 0;
            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (DirectoryInfo d in dirs)
            {
                Console.WriteLine(d);
                i++;
            }
            FileInfo[] files = dir.GetFiles();


            foreach (FileInfo s in files)
            {
                Console.WriteLine(s);
                i++;
            }
            return i;
        }

        public static void DelCatalogs(DirectoryInfo dir)

        {
            TimeSpan access;
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                access = DateTime.Now - d.LastAccessTime;
                if (access >= TimeSpan.FromMinutes(30))
                {
                    Console.Write($"Удаляем { d.FullName}...");
                    bool Accesible()
                    {
                        try
                        {
                            d.Delete(true);
                            return true;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(" нет доступа");
                            return false;
                        }
                    }
                    if (Accesible() == true)
                    {
                        d.Delete(true);
                    }

                }
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo d in files)
            {


                access = DateTime.Now - d.LastAccessTime;
                if (access >= TimeSpan.FromMinutes(30))
                {
                    Console.WriteLine();
                    Console.Write($"Удаляем { d.FullName}...");
                    bool Accesible()
                    {
                        try
                        {
                            d.Delete();
                            return true;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.Write(" нет доступа");
                            return false;
                        }
                        catch (Exception)
                        {
                            Console.Write(" нет доступа");
                            return false;
                        }
                    }
                    if (Accesible() == true)
                    {
                        d.Delete();
                    }

                }
            }
        }


        public static void Deleter()
        {
            Console.WriteLine("Введите путь к папке:");
            string path = Console.ReadLine();
            DirectoryInfo MyDir = new DirectoryInfo(@path);
            IsAccesible(MyDir);
            if (IsAccesible(MyDir) == false)
            {
                Deleter();
            }
            else
            {
                DelCatalogs(MyDir);
            }
        }
        static void Main(string[] args)
        {
            Deleter();
        }
    }
}
