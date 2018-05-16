using System.Windows.Controls;

namespace AvViewModel
{
    public class TextDisplayWindowViewModel 
    {
        public string Text { get; set; }

        public object CurrentViewModel
        {
            get { return this; }
        }
    }
}
