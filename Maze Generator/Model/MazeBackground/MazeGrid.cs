using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator.Model.MazeBackground
{
    class MazeGrid
    {
        public List<MazeCell> MazeCells { get; set; }
        public double FieldHeight { get; set; }
        public double FieldWidth { get; set; }
        public MazeGrid(double mazeHeight, double mazeWidth, List<MazeCell> cells)
        {
            this.FieldHeight = mazeHeight;
            this.FieldWidth = mazeWidth;
            this.MazeCells = cells;
        }
    }
}
