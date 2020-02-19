using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileIO
{
    class StreamTester
    {
        public static void Write()
        {
            using (StreamWriter writer = File.CreateText(@"reminders.txt"))
            {
                writer.WriteLine("njlbnijagh");
                writer.WriteLine("lkganojpbg");
                writer.WriteLine("lnaigjbpiug");
                writer.WriteLine("aptgjpgunp9");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + " ");
                }
                writer.Write(writer.NewLine);
            }
        }

        public static void Reader()
        {
            using (StreamReader reader = File.OpenText(@"reminders.txt"))
            {
                string input = null;
                while ((input = reader.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }

    }
}
