using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace OtusHW.File
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string text = "adfsdaf";
            var path1 = Path.Combine("c:\\TestDir1");
            var path2 = Path.Combine("c:\\TestDir2");

            var directory1 = new DirectoryInfo(path1);
            directory1.Create();
            var directory2 = new DirectoryInfo(path2);
            directory2.Create();

            for (int i = 1; i <= 10; i++)
            {
                using (FileStream fstream1 = new FileStream($"{path1}\\file{i}.txt", FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(fstream1.Name + "\t" + DateTime.Now);
                    await fstream1.WriteAsync(buffer, 0, buffer.Length);
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                using (FileStream fstream2 = new FileStream($"{path2}\\file{i}.txt", FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(fstream2.Name + "\t" + DateTime.Now);
                    await fstream2.WriteAsync(buffer, 0, buffer.Length);

                }
            }
            for(int i = 1;i <= 10; i++)
            {
                using(FileStream fileStream = new FileStream($"{path1}\\file{i}.txt", FileMode.Open))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fileStream.Length];
                    // считываем данные
                    await fileStream.ReadAsync(buffer, 0, buffer.Length);
                    string TextFromFile = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"Текст файла file{i}.txt: {TextFromFile} + дополнение");
                }
            }
            Console.WriteLine();

            for(int i = 1;i <= 10; i++)
            {
                using(FileStream fileStream = new FileStream($"{path2}\\file{i}.txt", FileMode.Open))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fileStream.Length];
                    // считываем данные
                    await fileStream.ReadAsync(buffer, 0, buffer.Length);
                    string TextFromFile = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"Текст файла file{i}.txt: {TextFromFile} + дополнение");
                }
            }
        }
    }
}