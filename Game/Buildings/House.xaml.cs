using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Game.Player;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
// Copyright 2016, Aaro Lyytinen, Santtu Boman, Nicolas Liuhanen. All rights reserved
// Version 1.2 
// FastLaneGame

namespace Game.Buildings
{
    public sealed partial class House : UserControl
    {
        Player.Player player;
        
        int Happiness = 2;
        int time = 1;  

        public House()
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);            
        }

        private void RelaxButton_Click(object sender, RoutedEventArgs e)
        {
            player.Relax(Happiness, time);
            player.RoundCheck();
        }
    }
}
