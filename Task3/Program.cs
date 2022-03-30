using DriveManager;
using Volume; // Будем брать классы и методы из Task1 и Task2


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке:");
            string path = Console.ReadLine();
            DirDeleter.IsAccesible(path);
            if (DirDeleter.IsAccesible(path) == true)
            {

                DirectoryInfo dir = new DirectoryInfo(path);
                var VolBefore = VolumeInfo.GetDirSize(path);
                var DirBefore = DirDeleter.GetCatalogs(dir);
                DirDeleter.DelCatalogs(dir);
                Console.WriteLine
                    ($"Вес до очитски: {VolBefore} байт " +
                    $"\nОсвобождено: {VolBefore - VolumeInfo.GetDirSize(path)} байт " +
                    $"\nУдалено: {DirBefore - DirDeleter.GetCatalogs(dir)} файлов и папок" +
                    $"\nТекущий вес папки:{VolumeInfo.GetDirSize(path)} байт");
            }

        }
    }
}
