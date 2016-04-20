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
    public sealed partial class University : UserControl
    {
        Player.Player1 player;
        int work = 200;
        int time = 1;

        public University()
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

        private async void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.UniversityWork == true)
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

        private async void StudyButton_Click(object sender, RoutedEventArgs e)
        {            
            player.PTime--;
            player.RoundCheck();
            player.PEducation += 1;
            if (player.PEducation == 10)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Congrats! You've mastered elementry school");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }
            if (player.PEducation == 20)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Congrats! You've mastered hight school");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
            }

        }
    }
}
