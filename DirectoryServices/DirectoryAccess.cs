using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryServices
{
    public class DirectoryAccess
    {
        //private const string userInformation = @"T$hs4Q|/f*P:?@J";

        public static string Password { get; set; }

        public static List<FileInfo> GetDirContent(string directory, string filter)
        {
            var ui = new UserImpersonation("admin-kh", "ABERDEEN", Password);
            ui.ImpersonateValidUser();


            var dirInfo = new DirectoryInfo(directory);

            var files = dirInfo.EnumerateFiles(filter);

            ui.Dispose();

            return files.ToList();
        }

        public static string GetFileContent(string fullName)
        {
            var ui = new UserImpersonation("admin-kh", "ABERDEEN", Password);
            ui.ImpersonateValidUser();

            var text = File.ReadAllText(fullName);

            ui.Dispose();

            return text;
        }

    }
}
