using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Generator.Command
{
    class GenericCommand : ICommand
    {
        /// <summary>
        /// Action a command does
        /// </summary>
        private Action<object> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCommand"/> class.
        /// </summary>
        /// <param name="a">
        /// Gets an action
        /// </param>
        public GenericCommand(Action<object> a)
        {
            this.action = a;
        }

        /// <summary>
        /// Checks if command can be executed (Isn't needed)
        /// </summary>
        public event EventHandler CanExecuteChanged;

        public void FireCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Tells if a command can be executed or not
        /// </summary>
        /// <param name="parameter">
        /// If the object can be executed
        /// </param>
        /// <returns>
        /// Returns always true.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter">
        /// Execute the command of the object.
        /// </param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}