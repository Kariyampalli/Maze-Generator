using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Maze_Generator.ViewModel;
using System.Collections.Generic;
using Maze_Generator.Model.MazeBackground;
using System.Collections.ObjectModel;
using Maze_Generator.Model;
using Maze_Generator.Model.Enums;

namespace MazeVmTest
{
    [TestClass]
    public class Test
    {
        private MazeVm mazeVm;
        public Test()
        {
            this.mazeVm = new MazeVm(null);
        }

        [TestMethod]
        public void TestSetEndHexagon()
        {
            try
            {
                this.mazeVm.SetEndHexagon(null);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells are too low to start the game");
            }

            try
            {
                this.mazeVm.SetEndHexagon(new List<MazeCell> { new MazeCell("", 2, 2, 2) });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells are too low to start the game");
            }

            try
            {
                this.mazeVm.SetEndHexagon(new List<MazeCell>());
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells are too low to start the game");
            }
        }

        [TestMethod]
        public void TestCreateMaze()
        {
            try
            {
                this.mazeVm.CreateMaze(null, 10, 10);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "cells or/and speed values are invalid at creating the maze");
            }

            try
            {
                this.mazeVm.CreateMaze(new List<MazeCell> { new MazeCell("", 2, 2, 2) }, 10, 10);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "cells or/and speed values are invalid at creating the maze");
            }

            try
            {
                this.mazeVm.CreateMaze(new List<MazeCell>(), 10, 10);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "cells or/and speed values are invalid at creating the maze");
            }

            try
            {
                this.mazeVm.CreateMaze(new List<MazeCell> { new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2) }, 101, 10);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "cells or/and speed values are invalid at creating the maze");
            }

            try
            {
                this.mazeVm.CreateMaze(new List<MazeCell> { new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2) }, -1, 10);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "cells or/and speed values are invalid at creating the maze");
            }

            try
            {
                this.mazeVm.CreateMaze(new List<MazeCell> { new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2) }, 100, 701);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "cells or/and speed values are invalid at creating the maze");
            }

            try
            {
                this.mazeVm.CreateMaze(new List<MazeCell> { new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2) }, 100, -1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "cells or/and speed values are invalid at creating the maze");
            }
        }

        [TestMethod]
        public void TestWork()
        {
            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
                obj.Invoke("Work", 2);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Work method for thread received an invalid object");
            }

            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
               obj.Invoke("Work", new object[] { null });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Work method for thread received an invalid object");
            }

            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
            obj.Invoke("Work", new object[] { new List<MazeCell> { new MazeCell("", 2, 2, 2) } });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Work method for thread received an invalid object");
            }

            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
             obj.Invoke("Work", new List<MazeCell>());
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Work method for thread received an invalid object");
            }
        }

        [TestMethod]
        public void TestUnselectCells()
        {
            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
             obj.Invoke("UnselectCells", new object[] { null });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells to be unselceted was invalid");
            }

            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
               obj.Invoke("UnselectCells", new List<MazeCell> { new MazeCell("", 2, 2, 2) });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells to be unselceted was invalid");
            }

            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
               obj.Invoke("UnselectCells", new List<MazeCell>());
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells to be unselceted was invalid");
            }
        }

        [TestMethod]
        public void PlaceHexagons()
        {
            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
                obj.Invoke("PlaceHexagons", new object[] { null, new List<MazeCell> { new MazeCell("", 2, 2, 2), new MazeCell("", 2, 2, 2) } });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells to be placed or current cell during placing hexagon was invalid");
            }
            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
                obj.Invoke("PlaceHexagons", new object[] { new MazeCell("", 2, 2, 2), new List<MazeCell> { new MazeCell("", 2, 2, 2) } });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells to be placed or current cell during placing hexagon was invalid");
            }
            try
            {
                PrivateObject obj = new PrivateObject(this.mazeVm);
                obj.Invoke("PlaceHexagons", new object[] { new MazeCell("", 2, 2, 2), null });
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells to be placed or current cell during placing hexagon was invalid");
            }
        }

        [TestMethod]
        public void CleanMaze()
        {
            try
            {
                this.mazeVm.CleanMaze(null);
            }
            catch(InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells are too low to Clean the maze");
            }

            try
            {
                this.mazeVm.CleanMaze(new List<MazeCell> { new MazeCell("",2,3,3)});
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Amount of cells are too low to Clean the maze");
            }


            VmClass vmClass = new VmClass();
            vmClass.TheMaze.Hexagons = new ObservableCollection<Hexagon> { new Hexagon("00", 2, 2, 2), new Hexagon("00", 2, 2, 2) };
            vmClass.TheMazeGrid.MazeCells[1].CellState = Cell.Selected;
            vmClass.TheMazeGrid.MazeCells[2].CellState = Cell.Selected;

            this.mazeVm.CleanMaze(vmClass.TheMazeGrid.MazeCells);

            Assert.IsTrue(vmClass.TheMazeGrid.MazeCells[1].CellState != Cell.Selected && vmClass.TheMazeGrid.MazeCells[2].CellState != Cell.Selected);
            Assert.IsTrue(vmClass.TheMazeGrid.MazeCells.FindAll(x => x.CellState == Cell.Taken).Count == 1);
            Assert.IsNotNull(this.mazeVm.EndHexagon);
        }
    }
}
