﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Game.Buildings
{
    public sealed partial class Baaripopup : UserControl
    {
        Player.Player1 player;

        //Hinnat
        int beer = 20;
        int jallu = 35;
        int wine = 50;
        int time = 1;

        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {
            Debug.WriteLine("The '" + command.Label + "' command has been selected.");
        }

        public Baaripopup()
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
        }

        private async void BeerButton_Click(object sender, RoutedEventArgs e)
        {
            player.CashSound();
            player.Buy(beer, time);
            player.PHappiness++;
            player.PDrink++;           
           

            if (player.PDrink == 4)
            {                
                var messageDialog = new Windows.UI.Popups.MessageDialog("You are getting too drunk! Bartender wont serve for you anymore and you are thrown out of the Bar.");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
                
              }
            player.RoundCheck();

        }

        private void JalluButton_Click(object sender, RoutedEventArgs e)
        {
            player.CashSound();
            player.Buy(jallu, time);
            player.PHappiness++;
            player.PDrink++;
            player.RoundCheck();
        }

        private void WineButton_Click(object sender, RoutedEventArgs e)
        {
            player.CashSound();
            player.Buy(wine, time);
            player.PHappiness++;
            player.PDrink++;
            player.RoundCheck();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }
    }
}
