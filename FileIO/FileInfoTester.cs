using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileIO
{
    class FileInfoTester
    {
        public static void MakeFile()
        {
            //make a new file on drive
            FileInfo f = new FileInfo(@"F:\School");
            
            FileStream fs = f.Create();
            fs.Close();

        }

        public static void OpenFile()
        {
            FileInfo f2 = new FileInfo(@"F:\School\Test2.dat");
            using(FileStream fs2 = f2.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None))
            {

            }

        }
    }
}
