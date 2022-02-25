using Maze_Generator.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Maze_Generator.Model.MazeBackground
{
    public class MazeCell : INotifyPropertyChanged
    {
        private double opacity;
        private Brush color;
        private Cell cellState;
        public Direction direction;
        public Cell CellState 
        {
            get
            {
                return this.cellState;
            }
            set
            {
                if(value == Cell.Selected)
                {
                    this.Color = Brushes.Red;
                }
                if(value == Cell.Unselected || value == Cell.Taken)
                {
                    this.Color = Brushes.GreenYellow;
                    if(value == Cell.Taken)
                    {
                        this.CellOpacity = 0;
                    }
                    else
                    {
                        this.CellOpacity = 0.7;
                    }
                }
                this.cellState = value;
            }
        }
        private Random random;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Resize { get; private set; }
        public MazeCell(string margin, int row, int col, double resize)
        {
            this.CellState = Cell.Unselected;
            this.Margin = margin;
            this.Row = row;
            this.Col = col;
            this.Resize = resize;
            this.random = new Random();

            this.CellOpacity = 0.7;
        }

        public double CellOpacity // Could DELETE
        {
            get
            {
                return this.opacity;
            }
            set
            {
                this.opacity = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CellOpacity)));
            }
        }
        public string Margin
        {
            get;
            set;
        }
     
        public int Row
        {
            get;
            private set;
        }

        public int Col
        {
            get;
            private set;
        }

        public string Points
        {
            //Takes an default hexagon size, resizes it and returns it
            get
            {
                return $"0,{25 * this.Resize} {50 * this.Resize},0 {100 * this.Resize},{25 * this.Resize}" +
                    $" {100 * this.Resize},{75 * this.Resize} {50 * this.Resize},{100 * this.Resize} 0,{75 * this.Resize}";
            }
        }
        public Brush Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(this.Color)));              
            }
        }
    }
}
