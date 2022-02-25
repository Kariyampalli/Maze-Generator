using Maze_Generator.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Maze_Generator.Model
{
    public class Hexagon : INotifyPropertyChanged
    {
        private Brush color;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Resize { get; private set; }
        public Hexagon(string margin, int row, int col, double resize)
        {
            this.Margin = margin;
            this.Row = row;
            this.Col = col;
            this.Resize = resize;
            this.Color = Brushes.Red;
            this.BottomLeftWallOpacity = 1;
            this.BottomRightWallOpacity = 1;
            this.TopRightWallOpacity = 1;
            this.TopLeftWallOpacity = 1;
            this.LeftWallOpacity = 1;
            this.RightWallOpacity = 1;
        }
        public string Margin
        {
            get;
            private set;
        }
        public Brush Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (this.color != value)
                {
                    this.color = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Color)));
                }
            }
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

        public string TopRightPoints
        {
            get
            {
                return $"{50 * this.Resize},0 {100 * this.Resize},{25 * this.Resize}";
            }
        }

        public double TopLeftWallOpacity { get; set; }
        public double TopRightWallOpacity { get; set; }
        public double RightWallOpacity { get; set; }
        public double BottomLeftWallOpacity { get; set; }
        public double BottomRightWallOpacity { get; set; }
        public double LeftWallOpacity { get; set; }




        public string TopLeftPoints
        {
            get
            {
                return $"0,{25 * this.Resize} {50 * this.Resize},0";
            }
        }
        public string RightPoints
        {
            get
            {
                return $"{100 * this.Resize},{25 * this.Resize} {100 * this.Resize},{75 * this.Resize}";
            }
        }
        public string LeftPoints
        {
            get
            {
                return $"0,{75 * this.Resize} 0,{25 * this.Resize}";
            }
        }

        public string BottomRightPoints
        {
            get
            {
                return $"{100 * this.Resize},{75 * this.Resize} {50 * this.Resize},{100 * this.Resize}";
            }
        }

        public string BottomLeftPoints
        {
            get
            {
                return $"{50 * this.Resize},{100 * this.Resize} 0,{75 * this.Resize}";
            }
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

        public void ChangeWallOpacityLastDirection(Direction lastDirection)
        {
            if (lastDirection == Direction.TopRight)
            {
                this.BottomLeftWallOpacity = 0;
                this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(this.BottomLeftWallOpacity)));
            }
            if (lastDirection == Direction.TopLeft)
            {
                this.BottomRightWallOpacity = 0;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.BottomRightWallOpacity)));
            }
            if (lastDirection == Direction.BottomRight)
            {
                this.TopLeftWallOpacity = 0;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TopLeftWallOpacity)));
            }
            if (lastDirection == Direction.BottomLeft)
            {
                this.TopRightWallOpacity = 0;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TopRightWallOpacity)));
            }
            if (lastDirection == Direction.Right)
            {
                this.LeftWallOpacity = 0;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.LeftWallOpacity)));
            }
            if (lastDirection == Direction.Left)
            {
                this.RightWallOpacity = 0;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.RightWallOpacity)));
            }
        }
        public void ChangeWallOpacityCurrentDirection(Direction nextDirection)
        {
            if (nextDirection == Direction.BottomLeft)
            {
                this.BottomLeftWallOpacity = 0;
            }
            if (nextDirection == Direction.BottomRight)
            {
                this.BottomRightWallOpacity = 0;
            }
            if (nextDirection == Direction.TopLeft)
            {
                this.TopLeftWallOpacity = 0;
            }
            if (nextDirection == Direction.TopRight)
            {
                this.TopRightWallOpacity = 0;
            }
            if (nextDirection == Direction.Left)
            {
                this.LeftWallOpacity = 0;
            }
            if (nextDirection == Direction.Right)
            {
                this.RightWallOpacity = 0;
            }
        }
    }
}

