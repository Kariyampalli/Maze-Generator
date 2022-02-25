using Maze_Generator.Model;
using Maze_Generator.Model.Buttons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Generator.ViewModel
{
    public class StartButtonVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly StartButton startButton;

        public bool IsEnabled
        {
            get
            {
                return this.startButton.IsEnabled;
            }
            set
            {
                this.startButton.IsEnabled = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsEnabled)));
            }
        }
        public string Content
        {
            get
            {
                return this.startButton.Content;
            }
            set
            {
                this.startButton.Content = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Content)));
            }
        }
        public ICommand StartCommand 
        {
            get
            {
                return this.startButton.StartCommand;
            }
        }
        public StartButtonVm(ICommand command)
        {
            this.startButton = new StartButton(command);
        }
    }
}
