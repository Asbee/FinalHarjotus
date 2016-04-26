using System;
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
        Player.Player player;

        //Hinnat
        int beer = 5;
        int jallu = 15;
        int wine = 20;
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

        private void BeerButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= beer)
            {
                player.CashSound();
                player.Buy(beer, time);
                player.PHappiness++;
                player.PDrink++;
            }
            else
            {
                player.NoBuy();
            }

            if (player.PDrink == 4)
            {
                player.TooDrunk();
            }

            player.RoundCheck();

        }

        private void JalluButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= jallu)
            {
                player.CashSound();
                player.Buy(jallu, time);
                player.PHappiness++;
                player.PDrink++;
                player.RoundCheck();
            }
            else
            {
                player.NoBuy();
            }

            if (player.PDrink == 4)
            {
                player.TooDrunk();
            }
        }

        private void WineButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= wine)
            {
                player.CashSound();
                player.Buy(wine, time);
                player.PHappiness++;
                player.PDrink++;
                player.RoundCheck();
            }
            else
            {
                player.NoBuy();
            }

            if (player.PDrink == 4)
            {
                player.TooDrunk();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }
    }
}
