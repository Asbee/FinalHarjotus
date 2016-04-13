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
    public sealed partial class Baari : UserControl
    {
        Player.Player1 player = new Player.Player1();
        Baaripopup baaripop = new Baaripopup();


        //Aika ja Työ arvot
        int money = 15;
        int time = 10;



        public Baari()
        {
            this.InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Kapakka.Children.Add(baaripop);
        }
        private void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            player.Work(money, time);
        }
    }
}