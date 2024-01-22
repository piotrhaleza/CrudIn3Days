using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Bukma.Elements
{
    public class Command : ICommand
    {
        private readonly Action<object> execute;

        public event EventHandler CanExecuteChanged;
       
        public Command(Action execute) 
        {
            this.execute = x => execute();
        }
       
        public Command(Action<object> execute)
        {
            this.execute = execute;
        }

            public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

    }
}

