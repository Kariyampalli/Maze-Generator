using Maze_Generator.Model.MazeBackground;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator.ViewModel
{
    public class MazeGridVm
    {
        private readonly MazeGrid mazeGrid;
        private GridCreator creator;
        public MazeGridVm()
        {
            this.creator = new GridCreator();
            this.mazeGrid = this.creator.Create(); //COULD ADD HEIGHT AND WIDTH AS PARAMETERS IF THERE IS TIME
        }
        public List<MazeCell> MazeCells
        {
            get
            {
                return this.mazeGrid.MazeCells;
            }
        }

        public double FieldHeight
        {
            get
            {
                return this.mazeGrid.FieldHeight;
            }
        }
        public double FieldWidth
        {
            get
            {
                return this.mazeGrid.FieldWidth;
            }
        }
    }
}
