using Maze_Generator.Command;
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
using System.Windows;
using System.Windows.Input;

namespace Maze_Generator.ViewModel
{
    public class VmClass
    {
        public int HexagonSpeed { get; set; }
        public int CellSpeed { get; set; }
        public StartButtonVm Starter { get; set; }
        public MazeGridVm TheMazeGrid { get; set; }
        public MazeVm TheMaze { get; set; }
        public ObservableCollection<HexagonVm> PlacedHexagons { get; set; }


        public VmClass()
        {
            try
            {               
                this.Starter = new StartButtonVm(new GenericCommand(obj =>
                {
                    this.Start();
                }));
                this.TheMaze = new MazeVm(this.Starter);
                this.TheMazeGrid = new MazeGridVm();
                this.PlacedHexagons = new ObservableCollection<HexagonVm>();
                this.TheMaze.SetEndHexagon(this.TheMazeGrid.MazeCells);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An unexpected error has accured: {ex.Message}");
                this.Starter.IsEnabled = false;
            }
        }

        public void Start()
        {
            try
            {
                if (this.Starter.Content == "Restart")
                {
                    this.TheMaze.CleanMaze(this.TheMazeGrid.MazeCells);
                    this.Starter.Content = "Start";
                }
                else
                {
                    this.Starter.Content = "Restart";
                    this.TheMaze.CreateMaze(this.TheMazeGrid.MazeCells, this.CellSpeed, this.HexagonSpeed);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error has accured!\nPlease refrain from using the start button until its resolved: {ex.Message}");
            }
        }
    }
}
