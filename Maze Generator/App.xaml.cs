﻿using Maze_Generator.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Maze_Generator
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
