using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvViewModel
{
    public class PopupWindowEventArgs : EventArgs
    {
        public object ViewModel { get; set; }

        public PopupWindowEventArgs(object vm)
        {
            ViewModel = vm;
        }
    }
}
