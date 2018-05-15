using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryServices
{
    public class DirectoryAccess
    {
        private const string userInformation = @"*2EVSrPhDtk;QWI";

        public static List<FileInfo> GetDirContent(string directory, string filter)
        {
            var ui = new UserImpersonation("admin-kh", "ABERDEEN", userInformation);
            ui.ImpersonateValidUser();


            var dirInfo = new DirectoryInfo(directory);

            var files = dirInfo.EnumerateFiles(filter);


            ui.Dispose();

            return files.ToList();
        }

        public static string GetFileContent(string fullName)
        {
            var ui = new UserImpersonation("admin-kh", "ABERDEEN", userInformation);
            ui.ImpersonateValidUser();

            var text = File.ReadAllText(fullName);

            ui.Dispose();

            return text;
        }

    }
}
