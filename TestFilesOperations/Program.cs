using System;
using System.Collections.Generic;

namespace TestFilesOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter directory full path :");
            var path = Console.ReadLine();

            FileOperation fileOperation = new FileOperation();
            ShowFileInfo(fileOperation.ListAllFileInfoInDirectory(path));

            Console.ReadLine();
        }

        static void ShowFileInfo(List<DirectoryFileInfo> fileInfos)
        {
            var prevousFilePath = string.Empty;

            foreach (var fileInfo in fileInfos)
            {
                if (prevousFilePath != fileInfo.DirectoryPath)
                {
                    Console.WriteLine(fileInfo.DirectoryPath);
                }

                var filedetail = fileInfo.FileCount != 0 ?
                 fileInfo.FileExtention + " - " + fileInfo.FileCount :
                 fileInfo.FileExtention;
                prevousFilePath = fileInfo.DirectoryPath;
                Console.WriteLine(filedetail);
            }
        }
    }
}
