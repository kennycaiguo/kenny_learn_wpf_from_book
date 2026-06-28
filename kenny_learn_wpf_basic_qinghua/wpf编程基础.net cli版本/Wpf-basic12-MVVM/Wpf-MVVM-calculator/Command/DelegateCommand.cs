using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_MVVM_calculator.Command
{
    

    public class DelegateCommand : ICommand
    {
        Action execute;
        Func<bool> canExecute;

        public DelegateCommand(Action execute =null, Func<bool> canExecute =null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (canExecute == null) 
            {
                return true;
            }
            return canExecute();
        }

        public void UpdateCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public void Execute(object? parameter)
        {
            if (execute == null)
            {
                return;
            }
           execute();
        }
    }
    public class DelegateCommand<T> : ICommand
    {
        Action<T> execute;
        Func<T, bool> canExecute;

        public DelegateCommand(Action<T> execute = null, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            return canExecute((T)parameter);
        }

        public void UpdateCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public void Execute(object? parameter)
        {
            if (execute == null)
            {
                return;
            }
            execute((T)parameter);
        }
    }

}
