using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestFilesOperations
{
    public class FileOperation
    {
        public List<DirectoryFileInfo> ListAllFileInfoInDirectory(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var fileDirectory = directoryInfo.EnumerateDirectories("*",SearchOption.AllDirectories);

            var fileInfos = from fileinfo in directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories)
                                     group fileinfo by new
                                     {
                                         fileinfo.DirectoryName,
                                         fileinfo.Extension
                                     } into files
                                     select new
                                     {
                                         files.Key.DirectoryName,
                                         files.Key.Extension,
                                         extCount = files.Count()
                                     };

            var directoryFileInfos = (from directory in fileDirectory
                         join file in fileInfos on directory.FullName equals file.DirectoryName into joinFileList
                         from fileinfo in joinFileList.DefaultIfEmpty()
                         select new DirectoryFileInfo()
                         {
                             DirectoryPath = directory.FullName,
                             FileExtention = fileinfo == null ? "no files found": fileinfo.Extension,
                             FileCount = fileinfo == null ? 0 : fileinfo.extCount
                   
                         }).OrderBy(p => p.DirectoryPath).ToList();
          
            return directoryFileInfos;
        }
    }
}
