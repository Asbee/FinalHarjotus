﻿using System;
using System.Collections.Generic;
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
    public sealed partial class Market : UserControl
    {
        Player.Player1 player;
        Marketpopup marketpop;

        //Aika ja Työ arvot
        int work = 15;
        int time = 10;
        
        public Market()
        {
            this.InitializeComponent();
            player = new Player.Player1();
            marketpop = new Marketpopup();
        }
        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {
            System.Diagnostics.Debug.WriteLine("The '" + command.Label + "' command has been selected.");
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Marketti.Children.Add(marketpop);
        }
        private async void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.MarketWork == true)
            {
                player.Work(work, time);

            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You dont work here!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
        }
    }
}
