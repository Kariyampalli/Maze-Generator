using Maze_Generator.Model.Enums;
using Maze_Generator.Model.MazeBackground;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze_Generator.Model
{
    class Walker
    {
        private Random random;
        public Walker()
        {
            this.random = new Random();
        }

        public Tuple<MazeCell, List<MazeCell>> Walk(List<MazeCell> cells, int cellSpeed)
        {
            bool run = true;
            List<MazeCell> unselectedCells = cells.Where(c => c.CellState == Cell.Unselected).ToList();
            List<MazeCell> selectedCells = new List<MazeCell>();
            MazeCell FirstCell = null;

            List<Hexagon> hexagons = new List<Hexagon>();
            int randomVal = this.random.Next(1, 144);
            MazeCell nextCell = unselectedCells[this.random.Next(0, unselectedCells.Count)];
            
            while (run)
            {
                if (nextCell.CellState != Cell.Taken)
                {
                    if (FirstCell == null)
                    {
                        FirstCell = nextCell;
                        hexagons.Add(new Hexagon(nextCell.Margin, nextCell.Row, nextCell.Col, nextCell.Resize));
                    }
                    if(nextCell.CellState != Cell.Selected)
                    {
                        nextCell.CellState = Cell.Selected; 
                        selectedCells.Add(nextCell);
                    }
                  
                    Thread.Sleep(cellSpeed); //100 max
                    Tuple<Direction, int, int> t = GetRandomDirection(nextCell.Row, nextCell.Col);
                    nextCell.direction = t.Item1;                   
                    nextCell = cells.First(c => c.Row == t.Item2 && c.Col == t.Item3);
                }
                else
                {
                    if (FirstCell == null)
                    {
                        nextCell = cells[this.random.Next(1, 144)];
                        continue;
                    }
                    else
                    {
                        return Tuple.Create(FirstCell,selectedCells);
                    }
                }
            }
            return null;
        }

        private Tuple<Direction, int, int> GetRandomDirection(int currentRow, int currentCol)
        {
            Tuple<int, int> nextRowAndCol = Tuple.Create(-1, -1); //nextRow, nextCol
            Direction direction = Direction.Right;
            int rand = 0;
            while (nextRowAndCol.Item1 < 0 || nextRowAndCol.Item1 > 11 || nextRowAndCol.Item2 < 0 || nextRowAndCol.Item2 > 11)
            {
                rand = this.random.Next(1, 7);
                switch (rand)
                {
                    case 1:
                        direction = Direction.TopRight;
                        nextRowAndCol = GetDirectionBasedValues(Direction.TopRight, currentRow, currentCol);
                        break;
                    case 2:
                        direction = Direction.TopLeft; //Column value only changes if current row isn't modulu 2
                        nextRowAndCol = GetDirectionBasedValues(Direction.TopLeft, currentRow, currentCol);
                        break;
                    case 3:
                        direction = Direction.Right;
                        nextRowAndCol = GetDirectionBasedValues(Direction.Right, currentRow, currentCol);
                        break;
                    case 4:
                        direction = Direction.Left;
                        nextRowAndCol = GetDirectionBasedValues(Direction.Left, currentRow, currentCol);
                        break;
                    case 5:
                        direction = Direction.BottomRight;
                        nextRowAndCol = GetDirectionBasedValues(Direction.BottomRight, currentRow, currentCol);
                        break;
                    case 6:
                        direction = Direction.BottomLeft;
                        nextRowAndCol = GetDirectionBasedValues(Direction.BottomLeft, currentRow, currentCol);
                        break;
                    default:
                        throw new Exception("Direction not implemented!");
                }
            }
            return Tuple.Create(direction, nextRowAndCol.Item1, nextRowAndCol.Item2);
        }
        public Tuple<int, int> GetDirectionBasedValues(Direction direction, int currentRow, int currentCol)
        {
            int nextRow;
            int nextCol;
            switch (direction)
            {
                case Direction.TopRight:
                    nextRow = currentRow - 1;
                    if (currentRow % 2 == 0) //Column value only changes if current row is modulu 2
                    {
                        nextCol = currentCol + 1;
                        break;
                    }
                    nextCol = currentCol;
                    break;
                case Direction.TopLeft:
                    //Column value only changes if current row isn't modulu 2
                    nextRow = currentRow - 1;
                    if (currentRow % 2 != 0)
                    {
                        nextCol = currentCol - 1;
                        break;
                    }
                    nextCol = currentCol;
                    break;
                case Direction.Right:
                    nextRow = currentRow;
                    nextCol = currentCol + 1;
                    break;
                case Direction.Left:
                    nextRow = currentRow;
                    nextCol = currentCol - 1;
                    break;
                case Direction.BottomRight:
                    nextRow = currentRow + 1;
                    if (currentRow % 2 == 0)
                    {
                        nextCol = currentCol + 1;
                        break;
                    }
                    nextCol = currentCol;
                    break;
                case Direction.BottomLeft:
                    nextRow = currentRow + 1;
                    if (currentRow % 2 != 0)
                    {
                        nextCol = currentCol - 1;
                        break;
                    }
                    nextCol = currentCol;
                    break;
                default:
                    throw new Exception("Direction not implemented!");
            }
            return Tuple.Create(nextRow, nextCol);
        }
    }
}
