using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryServices;

namespace AvViewModel
{
    public interface ILogFileViewModel
    {
        FileStorageLocations FileStoreLocations { get; set; }

        IInputBox InputBox { get; set; }

        event EventHandler<PopupWindowEventArgs> DisplayPopupWindow;
    }
}
