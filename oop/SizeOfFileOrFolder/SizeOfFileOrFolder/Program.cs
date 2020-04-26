using System;
using System.IO;

namespace SizeOfFileOrFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            long getSizeOfFile(FileInfo fileInfo)
                => fileInfo.Length;

            long getSizeOfDir(DirectoryInfo dirInfo)
            {
                long sizeInBytes = 0;

                FileInfo[] files = dirInfo.GetFiles();

                foreach (FileInfo file in files)
                    sizeInBytes += getSizeOfFile(file);

                DirectoryInfo[] directories = dirInfo.GetDirectories();

                foreach (DirectoryInfo directory in directories)
                    sizeInBytes += getSizeOfDir(directory);

                return sizeInBytes;
            }

            bool itsADirectory(string path)
            {
                FileAttributes fileAttr = File.GetAttributes(path);

                return fileAttr.HasFlag(FileAttributes.Directory);
            }

            try
            {
                string path;

                Console.WriteLine("Get the size of a file/directory by providing the path to it:");
                path = Console.ReadLine();

                bool itsADir = itsADirectory(@path);

                long size = itsADir
                    ? getSizeOfDir(new DirectoryInfo(@path))
                    : getSizeOfFile(new FileInfo(@path));

                string outputFileOrDir = itsADir
                    ? "directory"
                    : "file";

                Console.WriteLine($"The size of the {outputFileOrDir} is {size} bytes.");
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
