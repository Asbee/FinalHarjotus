using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Game.Player;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Game;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Game.Buildings
{
    public sealed partial class Burger : UserControl
    {
        BurgerPopup burgerpop;
        Player.Player player;
    
        public Burger()
        {
           this.InitializeComponent();
           player = (App.Current as App).player; 
           burgerpop = new BurgerPopup();
        }
        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {           
            Debug.WriteLine("The '" + command.Label + "' command has been selected.");
        }

        //Time and work values
        int work = 30;
        int time = 1;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }
        private async void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.BurgerWork == true)
            {
                player.Work(work, time);
                player.RoundCheck();
            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You dont work here!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Burgeri.Children.Add(burgerpop);
        }
    }
}
