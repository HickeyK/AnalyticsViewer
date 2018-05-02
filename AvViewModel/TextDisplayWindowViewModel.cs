using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmDialogs;

namespace AvViewModel
{
    class TextDisplayWindowViewModel : IModalDialogViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool? DialogResult { get; }
    }
}
