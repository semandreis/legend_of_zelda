using System;
using System.IO;
using System.Reflection;

namespace Zelda.Records
{
    // used https://stackoverflow.com/questions/55307517/issue-getting-txt-file-from-folder-not-in-the-debug to avoid having to copy and paste the csv into bin with each update
    public static class FilePathFinder
    {
        static string debugPath = Assembly.GetExecutingAssembly().Location;
        static string basePath = debugPath.Substring(0, debugPath.IndexOf("\\bin\\", StringComparison.InvariantCultureIgnoreCase));
        public static string FindFilePath(string directory, string filename)
        {
            return Path.Combine(basePath, directory, filename); ;
        }
    }
}
