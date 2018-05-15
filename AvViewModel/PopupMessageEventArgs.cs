using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvViewModel
{
    public class PopupMessageEventArgs : EventArgs
    {
        public string Message { get; set; }

        public PopupMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
