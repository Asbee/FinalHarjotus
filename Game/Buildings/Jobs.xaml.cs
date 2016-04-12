using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Game.Player;
using Game.Buildings;
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
    public sealed partial class Jobs : UserControl
    {
        Player1 player = new Player1();

        public Jobs()
        {
            this.InitializeComponent();
        }       

        public void BurgerJob()
        {
            if (player.PEducation == 0)
            {
                player.PJob = "Burger";
            }
                
        }
        public void MarketJob()
        {
            if (player.PEducation == 1)
            {
                player.PJob = "Market";
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            BurgerJob();
        }

        private void Market_Click(object sender, RoutedEventArgs e)
        {
            MarketJob();
        }
    }
}
