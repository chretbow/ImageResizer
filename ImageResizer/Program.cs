using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");
            string destination2Path = Path.Combine(Environment.CurrentDirectory, "output2");

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);
            imageProcess.Clean(destination2Path);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 4.0);
            sw.Stop();

            Console.WriteLine($"修改前花費時間: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            await imageProcess.ResizeImagesAsync(sourcePath, destination2Path, 4.0);
            sw.Stop();

            Console.WriteLine($"修改後花費時間: {sw.ElapsedMilliseconds} ms");
            Console.Read();
        }
    }
}
