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
        public static List<FileInfo> GetDirContent(string directory, string filter)
        {
            var ui = new UserImpersonation("admin-kh", "ABERDEEN", @"vic)0.5sU+4|2D;");
            ui.ImpersonateValidUser();


            var dirInfo = new DirectoryInfo(directory);

            var files = dirInfo.EnumerateFiles(filter);


            ui.Dispose();

            return files.ToList();
        }

    }
}
