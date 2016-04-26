using System;
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
    public sealed partial class Marketpopup : UserControl
    {

        Player.Player player;

        //Hinnat
        int pinaatti = 15;
        int banaani = 5;
        int makarooni = 20;

        public Marketpopup()
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
        }

        private void BanaaniButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= banaani)
            {
                player.CashSound();
                player.Buy(banaani, 0);
                player.RoundCheck();
            }
            else
            {
                player.NoBuy();
            }
        }

        private void PinaattiButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= pinaatti)
            {
                player.CashSound();
                player.Buy(pinaatti, 0);
                player.RoundCheck();
            }
            else
            {
                player.NoBuy();
            }
        }

        private void MakaroniButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.PMoney >= makarooni)
            {
                player.CashSound();
                player.Buy(makarooni, 0);
                player.RoundCheck();
            }
            else
            {
                player.NoBuy();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }
    }
}
