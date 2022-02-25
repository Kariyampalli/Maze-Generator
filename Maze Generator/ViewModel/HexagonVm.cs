using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Maze_Generator.Model;

namespace Maze_Generator.ViewModel
{
   public class HexagonVm
    {
        private readonly Hexagon hexagon;
        public HexagonVm(string margin, int row, int col, double resize)
        {
            this.hexagon = new Hexagon(margin, row, col, resize);
        }
        public string Margin
        {
            get
            {
                return this.hexagon.Margin;
            }
        }
        public Brush Color
        {
            get
            {
                return this.hexagon.Color;
            }
            set
            {
                this.hexagon.Color = value;
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
                return this.hexagon.TopRightPoints;
            }
        }
        public string TopLeftPoints
        {
            get
            {
                return this.hexagon.TopLeftPoints;
            }
        }
        public string RightPoints
        {
            get
            {
                return this.hexagon.RightPoints;
            }
        }
        public string LeftPoints
        {
            get
            {
                return this.hexagon.LeftPoints;
            }
        }

        public string BottomRightPoints
        {
            get
            {
                return this.hexagon.BottomRightPoints;
            }
        }

        public string BottomLeftPoints
        {
            get
            {
                return this.hexagon.BottomLeftPoints;
            }
        }

        //public void ChangeWallOpacity(Direction direction)
        //{
        //    hexagon.ChangeWallOpacity(direction, direction);
        //}

        public double TopLeftWallOpacity
        {
            get
            {
                return this.hexagon.TopLeftWallOpacity;
            }
        }
        public double TopRightWallOpacity
        {
            get
            {
                return this.hexagon.TopRightWallOpacity;
            }
        }
        public double RightWallOpacity
        {
            get
            {
                return this.hexagon.RightWallOpacity;
            }
        }
        public double BottomLeftWallOpacity
        {
            get
            {
                return this.hexagon.BottomLeftWallOpacity;
            }
        }
        public double BottomRightWallOpacity
        {
            get
            {
                return this.hexagon.BottomRightWallOpacity;
            }
        }
        public double LeftWallOpacity
        {
            get
            {
                return this.hexagon.LeftWallOpacity;
            }
        }
    }
}
