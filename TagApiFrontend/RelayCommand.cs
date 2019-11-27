using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TagApiFrontend
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _methodToExecute;

        public RelayCommand(Action methodToExecute)
        {
            _methodToExecute = methodToExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_methodToExecute != null)
            {
                _methodToExecute();
            }
        }
    }
}