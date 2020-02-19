using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileIO
{
    class DirectoryInfoTest
    {


        public static void ShowWindowsDirectoryInfo()
        {
            //Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"c:\Windows");
            Console.WriteLine("**** Directory Info ****");
            Console.WriteLine("FullName: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************");
        }

        public static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\Windows\Web\Wallpaper");
            //Get  all files with a *.jpg extension
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            //How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);

            //Now print out info for each file
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("************************");
                Console.WriteLine("FullName: {0}", f.Name);
                Console.WriteLine("Lenght: {0}", f.Length);
                Console.WriteLine("Creation: {0}", f.CreationTime);
                Console.WriteLine("Attributes: {0}", f.Attributes);
                Console.WriteLine("************************");

            }

        }

        public static void biggestCsFile()
        {
            DirectoryInfo dir = new DirectoryInfo(@"f:\School\Hogent");
            //Get  all files with a *.jpg extension
            List<FileInfo> csFiles = new List<FileInfo>(dir.GetFiles("*.cs", SearchOption.AllDirectories));
            //How many were found?
            Console.WriteLine("Found {0} *.cs files\n", csFiles.Count);




            csFiles.Sort((a, b) => (b.Length.CompareTo(a.Length)));

            int maxcount = 10;

            for (int i = 0; i < maxcount; i++)
            {
                if (csFiles[i].Length == csFiles[i + 1].Length)
                    maxcount++;

                Console.WriteLine("**** Biggest cs file ****");
                Console.WriteLine("FullName: {0}", csFiles[i].Name);
                Console.WriteLine("Lenght: {0}", csFiles[i].Length);
                Console.WriteLine("Creation: {0}", csFiles[i].CreationTime);
                Console.WriteLine("Attributes: {0}", csFiles[i].Attributes);
                Console.WriteLine("************************");
            }


            //Console.WriteLine("**** Biggest cs file ****");
            //Console.WriteLine("FullName: {0}", csFiles[index].Name);
            //Console.WriteLine("Lenght: {0}", csFiles[index].Length);
            //Console.WriteLine("Creation: {0}", csFiles[index].CreationTime);
            //Console.WriteLine("Attributes: {0}", csFiles[index].Attributes);
            //Console.WriteLine("************************");

        }


        public static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"F:\School");
            dir.CreateSubdirectory("myFolder");
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFOlder2\Data");
            Console.WriteLine("New Folder is: {0}", myDataFolder);
        }

    }
}

