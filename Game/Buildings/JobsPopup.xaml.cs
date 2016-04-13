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
    public sealed partial class JobsPopup : UserControl
    {
        Player.Player1 player;       
         
        public JobsPopup()
        {
            this.InitializeComponent();
            player = new Player.Player1();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }

        private void BurgeriButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.BurgerWork == false )
            {
                player.BurgerWork = true;
                player.MarketWork = false;
                player.UniversityWork = false;
            }           
        }

        private void MarketButton_Click (object sender, RoutedEventArgs e)
        {
            if (player.MarketWork == false)
            {
                player.BurgerWork = false;
                player.MarketWork = true;
                player.UniversityWork = false;
            }
        }

        private void University_Click (object sender, RoutedEventArgs e)
        {
            if (player.UniversityWork == false)
            {
                player.BurgerWork = false;
                player.MarketWork = false;
                player.UniversityWork = true;
            }

        }
    }
}
