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
        Player.Player player;       
         
        public JobsPopup()
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
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

        private async void BurgeriButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.BurgerWork == true)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You have a job here already! No rise for you!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("OK",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            if (player.BurgerWork == false )
            {
                player.BurgerWork = true;
                player.MarketWork = false;
                player.UniversityWork = false;
                player.JobsWork = false;
                player.BarWork = false;
                var messageDialog = new Windows.UI.Popups.MessageDialog("Congratulations! You're hired!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("OK",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            player.PTime--;
            player.RoundCheck(); 
        }

        private async void MarketButton_Click (object sender, RoutedEventArgs e)
        {
            if (player.MarketWork == true)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You have a job here already! No rise for you!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            if (player.MarketWork == false && player.PEducation > 5)
            {
                player.BurgerWork = false;
                player.MarketWork = true;
                player.UniversityWork = false;
                player.JobsWork = false;
                player.BarWork = false;
                var messageDialog = new Windows.UI.Popups.MessageDialog("Congratulations! You're hired!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }

            if (player.MarketWork == false && player.PEducation <= 5)
            {
                    var messageDialog = new Windows.UI.Popups.MessageDialog("You need to study more! Not enought experience! You don't know me!");
                    messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                    new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                    await messageDialog.ShowAsync();
             }
            player.PTime--;
            player.RoundCheck();
        }

        private async void University_Click (object sender, RoutedEventArgs e)
        {
            if (player.UniversityWork == true)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You have a job here already! No rise for you!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }

                if (player.UniversityWork == false && player.PEducation > 25)
            {
                player.BurgerWork = false;
                player.MarketWork = false;
                player.UniversityWork = true;
                player.JobsWork = false;
                player.BarWork = false;
                var messageDialog = new Windows.UI.Popups.MessageDialog("Congratulations! You're hired!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            if (player.UniversityWork == false && player.PEducation <= 25)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You need to study more! Not enought experience! You don't know me!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            player.PTime--;
            player.RoundCheck();

        }

        private async void BarW_Click(object sender, RoutedEventArgs e)
        {
            if (player.BarWork == true)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You have a job here already! No rise for you!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }

            if (player.BarWork == false && player.PEducation > 7)            
            {
                player.BurgerWork = false;
                player.MarketWork = false;
                player.UniversityWork = false;
                player.JobsWork = false;
                player.BarWork = true;
                var messageDialog = new Windows.UI.Popups.MessageDialog("Congratulations! You're hired!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            if (player.BarWork == false && player.PEducation <= 7)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You need to study more! Not enought experience! You don't know me!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            player.PTime--;
            player.RoundCheck();
        }

        private async void JobsW_Click(object sender, RoutedEventArgs e)
        {
            if (player.JobsWork == true)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You have a job here already! No rise for you!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }

            if (player.JobsWork == false && player.PEducation > 17)
            {
                player.BurgerWork = false;
                player.MarketWork = false;
                player.UniversityWork = false;
                player.JobsWork = true;
                player.BarWork = false;
                var messageDialog = new Windows.UI.Popups.MessageDialog("Congratulations! You're hired!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            if (player.JobsWork == false && player.PEducation <= 17)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("You need to study more! Not enought experience! You don't know me!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            player.PTime--;
            player.RoundCheck();
        }
    }
}
