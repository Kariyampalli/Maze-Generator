using Maze_Generator.Model.Enums;
using Maze_Generator.Model;
using Maze_Generator.Model.MazeBackground;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace Maze_Generator.ViewModel
{
    public class MazeVm : INotifyPropertyChanged
    {
        public Random random;
        public StartButtonVm Starter { get; private set; }
        public int HexagonSpeed { get; set; }
        public int CellSpeed { get; set; }
        public Hexagon EndHexagon { get; set; }
        private Dispatcher dispatcher;
        private Thread thread; //Thread for the maze creation
        private Walker walker; //walker is only used for direction oriented operation in this class
        private readonly Maze maze;

        public MazeVm(StartButtonVm starter)
        {
            this.Starter = starter;
            this.random = new Random();
            this.walker = new Walker();
            this.dispatcher = Dispatcher.CurrentDispatcher;
            this.maze = new Maze();
            this.Hexagons = new ObservableCollection<Hexagon>();
        }
        public void SetEndHexagon(List<MazeCell> cells)
        {
            if (cells == null || cells.Count <= 1)
            {
                throw new InvalidOperationException("Amount of cells are too low to start the game");
            }
            int randomVal = this.random.Next(1, 144);
            MazeCell randomCell = cells[randomVal];
            randomCell.CellState = Cell.Taken;
            this.EndHexagon = new Hexagon(randomCell.Margin, randomCell.Row, randomCell.Col, randomCell.Resize);
        }
        public ObservableCollection<Hexagon> Hexagons
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateMaze(List<MazeCell> cells, int cellSpeed, int hexagonSpeed) //Creaetes the maze im the given speeds
        {
            if (cells == null || cells.Count <= 1 || cellSpeed > 100 || hexagonSpeed > 700 || cellSpeed < 0 || hexagonSpeed < 0)
            {
                throw new InvalidOperationException("cells or/and speed values are invalid at creating the maze");
            }
            this.CellSpeed = cellSpeed;
            this.HexagonSpeed = hexagonSpeed;
            this.Starter.IsEnabled = false;
            this.thread = new Thread(new ParameterizedThreadStart(Work));
            this.thread.Start(cells);
        }
        private void Work(object c)
        {
            if (c == null || c.GetType() != typeof(List<MazeCell>))
            {
                throw new InvalidOperationException("Work method for thread received an invalid object");
            }
            List<MazeCell> cells = (List<MazeCell>)c;
            if (cells.Count <= 1)
            {
                throw new InvalidOperationException("Work method for thread received an invalid object");
            }
            bool continueWork = true;
            while (this.Hexagons.Count < cells.Count - 1 && continueWork)
            {
                Tuple<MazeCell, List<MazeCell>> t;
                t = this.maze.CreateMaze(cells, this.CellSpeed);
                if(!this.PlaceHexagons(t.Item1, cells))
                {
                    continueWork = false;
                }
                this.UnselectCells(t.Item2);
            }
            this.Starter.IsEnabled = true;
        }

        private void UnselectCells(List<MazeCell> cells)
        {
            if (cells == null)
            {
                throw new InvalidOperationException("Amount of cells to be unselceted was invalid");
            }
            foreach (var c in cells)
            {
                if (c.CellState == Cell.Selected)
                {
                    c.CellState = Cell.Unselected;
                }
            }
        }
        private bool PlaceHexagons(MazeCell currentCell, List<MazeCell> cells)
        {
            if (currentCell == null || cells == null || cells.Count <= 1)
            {
                throw new InvalidOperationException("Amount of cells to be placed or current cell during placing hexagon was invalid");
            }
            Hexagon h = new Hexagon(currentCell.Margin, currentCell.Row, currentCell.Col, currentCell.Resize);
            h.ChangeWallOpacityCurrentDirection(currentCell.direction);
            Direction lastDirection = currentCell.direction;
            currentCell.CellState = Cell.Taken;
            try
            {
                this.dispatcher.Invoke(() =>
                {
                    this.Hexagons.Add(h);
                    Hexagon hex = this.Hexagons[0];
                });
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {
                MessageBox.Show("Placing of the hexagons was closed abruptly");
                return false;
            }

            bool run = true;
            while (run)
            {
                Tuple<int, int> t = this.walker.GetDirectionBasedValues(currentCell.direction, currentCell.Row, currentCell.Col);
                currentCell = cells.First(c => c.Row == t.Item1 && c.Col == t.Item2);
                if (currentCell.CellState == Cell.Taken)
                {
                    if (this.EndHexagon.Row == currentCell.Row && this.EndHexagon.Col == currentCell.Col)
                    {
                        this.EndHexagon.ChangeWallOpacityLastDirection(lastDirection);
                        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.EndHexagon)));
                    }
                    else
                    {

                        foreach (Hexagon hex in this.Hexagons)
                        {
                            if (hex.Row == currentCell.Row && hex.Col == currentCell.Col)
                            {
                                hex.ChangeWallOpacityLastDirection(lastDirection);
                                break;
                            }
                        }
                    }
                    run = false;
                    continue;
                }

                try
                {
                    this.dispatcher.Invoke(() =>
                                   {
                                       h = new Hexagon(currentCell.Margin, currentCell.Row, currentCell.Col, currentCell.Resize);
                                       h.ChangeWallOpacityCurrentDirection(currentCell.direction);
                                       h.ChangeWallOpacityLastDirection(lastDirection);
                                       currentCell.CellState = Cell.Taken;
                                       this.Hexagons.Add(h);
                                   });
                }
                catch (System.Threading.Tasks.TaskCanceledException)
                {
                    MessageBox.Show("Placing of the hexagons was closed abruptly");
                    return false;
                }

                lastDirection = currentCell.direction;
                Thread.Sleep(this.HexagonSpeed);
            }
            return true;
        }

        public void CleanMaze(List<MazeCell> cells)
        {
            if (cells == null || cells.Count <= 1)
            {
                throw new InvalidOperationException("Amount of cells are too low to Clean the maze");
            }
            this.Hexagons.Clear();
            foreach (var c in cells)
            {
                //c.CellOpacity = 1;
                c.CellState = Cell.Unselected;
            }
            MazeCell cell = cells[this.random.Next(0, 144)];
            this.EndHexagon = new Hexagon(cell.Margin, cell.Row, cell.Col, cell.Resize);
            cell.CellState = Cell.Taken;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.EndHexagon)));
        }
    }
}
