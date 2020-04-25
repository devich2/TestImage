using ImageMagick;
using System;
using System.Diagnostics;
using System.IO;

namespace TestImage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ResizePerfTest...\n");
            Performance.ResizePerfTest();
            Console.WriteLine("\nDone.\n");

            Console.WriteLine("CompressPerfTest...\n");
            Performance.CompressTypePerfTest();
            Console.WriteLine("\nDone.\n");

            Console.ReadLine();
        }
    }
}
