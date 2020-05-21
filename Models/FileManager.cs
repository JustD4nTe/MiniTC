using System.IO;

namespace MiniTC.Models
{
    class FileManager : IFileManager
    {
        public bool Copy(string source, string fileName, string destination)
        {
            // just return when file is not selected
            if (fileName == null)
            {
                return true;
            }

            // when file is a directory
            if (fileName.Contains("<D>"))
            {
                // cut directory prefix from name
                fileName = fileName.Substring(3);

                var sourcePath = Path.Combine(source, fileName);
                var destPath = Path.Combine(destination, fileName);

                // to prevent inifnity loop of coping
                // not copy files from a parent folder to a child folder
                if (destPath.Contains(sourcePath))
                {
                    return false;
                }

                DirectoryCopy(sourcePath, destPath);
            }
            // copy single file
            else
            {
                var sourcePath = Path.Combine(source, fileName);
                var destPath = Path.Combine(destination, fileName);

                FileCopy(sourcePath, destPath);
            }

            return true;
        }

        private void FileCopy(string sourceFile, string destFile)
        => File.Copy(sourceFile, destFile, true);

        //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        private void DirectoryCopy(string sourceFile, string destFile)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceFile);
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destFile))
            {
                Directory.CreateDirectory(destFile);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destFile, file.Name);
                file.CopyTo(temppath, false);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If copying subdirectories, copy them and their contents to new location.
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destFile, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
        }
    }
}
