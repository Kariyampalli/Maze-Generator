using Maze_Generator.Model.MazeBackground;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator.Model
{
    class Maze
    {
        private List<Hexagon> hexagons;
        private Walker walker;
        public Maze()
        {
            this.Hexagons = new List<Hexagon>();
            this.walker = new Walker();
        }
        public List<Hexagon> Hexagons 
        {
            get
            {
                return this.hexagons;
            }
            set
            {
                this.hexagons = value;
            }
        }     

        public Tuple<MazeCell, List<MazeCell>> CreateMaze(List<MazeCell> cells, int cellSpeed)
        {
           return this.walker.Walk(cells, cellSpeed);
        }
       
    }
}
