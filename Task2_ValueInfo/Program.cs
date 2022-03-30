using DriveManager;// используем проверку доступности из Task1
// код работает, но если доступ к файлу директории закрыт, то вес не узнать.
namespace Volume
{
    public class VolumeInfo
    {
        
        public static long GetDirSize(string path)
        {
            long size = 0;
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
                size += (new FileInfo(file)).Length;
            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
                size += GetDirSize(dir);
            return size;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу:");
            string path = Console.ReadLine();
            if (DirDeleter.IsAccesible(path) == true)
            {
                Console.WriteLine(GetDirSize(path) + " байт");
            }
            else
            {
                Main(args);
            }

        }
    }
}