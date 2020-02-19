using System;
using System.IO;
using System.IO.Compression;


namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("**** Fun with Directory(Info) ****");
            //DirectoryInfoTest.ShowWindowsDirectoryInfo();
            //Console.ReadLine();
            //DirectoryInfoTest.DisplayImageFiles();
            //Console.ReadLine();
            //DirectoryInfoTest.ModifyAppDirectory();
            //Console.ReadLine();
            //DirectoryInfoTest.biggestCsFile();
            //Console.ReadLine();

            //FileInfoTester.MakeFile();
            //FileInfoTester.OpenFile();

            //StreamTester.Write();
            //StreamTester.Reader();

            string path = @"D:\.NET\Tutorial\Data\DirFileOefening";
            string extractpath = @"D:\.NET\Tutorial\Data\DirFileOefening\extract";
            string zippath = @"D:\.NET\Tutorial\Data\DirFileOefening\DirFileOefening.zip";

            ZipTester.CreateZip(zippath, Directory.EnumerateFiles(path, "*.csv"));
            File.Copy(zippath, Path.Combine(path, "CopyOfZip.zip"));
            ZipFile.ExtractToDirectory(zippath, extractpath);

        }
    }
}
