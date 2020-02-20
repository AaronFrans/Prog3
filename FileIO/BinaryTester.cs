using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileIO
{
    class BinaryTester
    {
        public static void Writer()
        {
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);

                double d = 55.256;
                int i = 854;
                string s = "khglnJ";

                bw.Write(d);
                bw.Write(i);
                bw.Write(s);
            }
        }
        //blbla

        public static void Reader()
        {
            FileInfo f = new FileInfo("BinFile.dat");

            using(BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
        }

    }
}
