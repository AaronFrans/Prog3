using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace FileIO
{
    class ZipTester
    {
      public static void CreateZip(string filename, IEnumerable<string> files)
        {
            var zip = ZipFile.Open(filename, ZipArchiveMode.Create);
            foreach(var file in files)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);

            }
            zip.Dispose();
              
        }
    }
}
