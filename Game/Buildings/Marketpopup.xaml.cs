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

        Player.Player1 player;

        //Hinnat
        int pinaatti = 20;
        int banaani = 10;
        int makarooni = 15;

        public Marketpopup()
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
        }

        private void BanaaniButton_Click(object sender, RoutedEventArgs e)
        {
            player.Buy(banaani, 0);
            player.RoundCheck();
        }

        private void PinaattiButton_Click(object sender, RoutedEventArgs e)
        {
            player.Buy(pinaatti, 0);
            player.RoundCheck();
        }

        private void MakaroniButton_Click(object sender, RoutedEventArgs e)
        {
            player.Buy(makarooni, 0);
            player.RoundCheck();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }
    }
}
