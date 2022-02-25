using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator.Model.MazeBackground
{
    class GridCreator
    {
        public GridCreator()
        {

        }

        public MazeGrid Create()
        {
            List<MazeCell> cells = new List<MazeCell>();

            double resize = 0.6;
            double mazeHeight = ((50 * resize) * 1.5) * 12.3;
            double mazeWidth = (100 * resize) * 12.5;

            bool space = true;
            double x = 0;
            double y = 0;
            for (int row = 0; row < 12; row++)
            {
                if (space)
                {
                    x = 50 * resize;
                }
                else
                {
                    x = 0;
                }
                for (int col = 0; col < 12; col++)
                {
                    cells.Add(new MazeCell($"{x},{y},0,0", row, col, resize));
                    x = x + (100 * resize);
                }
                space = !space;
                y = y + (50 * resize) * 1.5;
            }
            return new MazeGrid(mazeHeight, mazeWidth, cells);
        }
    }
}
