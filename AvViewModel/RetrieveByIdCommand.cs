using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvViewModel
{
    class RetrieveByIdCommand : ICommand
    {
        private Action<int> _action;

        public RetrieveByIdCommand(Action<int> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int cadisId;
            if (int.TryParse(parameter.ToString(), out cadisId))
            {
                _action(cadisId);
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}
