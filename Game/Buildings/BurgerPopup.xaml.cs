using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Game.Player;
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
    public sealed partial class BurgerPopup : UserControl
    {
        Player.Player player;
        //Items value
        int burgerointi = 20;
        int Matto = 50;
        int Ranut = 15;

        public BurgerPopup()
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }

        private void BurgeriButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= burgerointi)
            { 
                player.CashSound();
            player.Buy(burgerointi, 0);
            player.RoundCheck();
            player.PFood = true;
        }
            else 
            {
                player.NoBuy();
            }
        }

        private void RanutButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= Ranut)
            {
                player.CashSound();
                player.Buy(Ranut, 0);
                player.RoundCheck();
                player.PFood = true;
            }
            else
            {
                player.NoBuy();
            }
        }

        private void MattoButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= Matto)
            {
                player.CashSound();
                player.Buy(Matto, 0);
                player.RoundCheck();
                player.PFood = true;
            }
            else
            { player.NoBuy(); }
                    }
    }
}
