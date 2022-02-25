using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Generator.Model.Buttons
{
    public class StartButton
    {
        private string content;
        private bool isEnabled;
        public ICommand StartCommand { get; private set; }
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.isEnabled = value;           
            }
        }
        public string Content 
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }
        public StartButton(ICommand command)
        {
            this.isEnabled = true;
            this.StartCommand = command;
            this.Content = "Start";
        }
    }
}
