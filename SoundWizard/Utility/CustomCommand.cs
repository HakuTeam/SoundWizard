namespace SoundWizard.Utility
{
    using System;
    using System.Windows.Input;

    public class CustomCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool b = this.canExecute == null ? true : this.canExecute(parameter);
            return b;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}