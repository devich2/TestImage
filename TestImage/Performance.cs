using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestImage
{
    public static class Performance
    {
        private static string outDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\";
        private static string fileName = "lilia269.png";
        private static string fullPath = outDir + fileName;
        private static string resizedPath = outDir + "R" + fileName;
        public static void ResizePerfTest()
        {
            using (new OperationTimer("Resizing image.....")) // Make sure this gets GC'd
            {
                using (var image = new MagickImage(fullPath))
                {
                    var size = new MagickGeometry(600, 400);
                    size.IgnoreAspectRatio = true;
                    image.Resize(size);
                    image.Write(resizedPath);
                }
            }     
        }

        public static void CompressTypePerfTest()
        {
            using (new OperationTimer("Compressing image.....")) // Make sure this gets GC'd
            {
                var imageFile = new FileInfo(resizedPath);
                var optimizer = new ImageOptimizer();
                Console.WriteLine("Bytes before compressing: ", imageFile.Length);
                optimizer.Compress(imageFile);
                imageFile.Refresh();
                Console.WriteLine("Bytes after compressing: ", imageFile.Length);
            }
        }
    }
}
