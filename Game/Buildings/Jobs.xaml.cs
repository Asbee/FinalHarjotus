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
using System.Diagnostics;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Game.Buildings
{
    public sealed partial class Jobs : UserControl
    {
        Player1 player;
        JobsPopup jobspop;


        // Arvot
        int work = 30;
        int time = 15;

        

        public Jobs()
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
            jobspop = new JobsPopup();

        }

        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {
            Debug.WriteLine("The '" + command.Label + "' command has been selected.");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)Parent;
            grid.Children.Remove(this);
        }

        private async void Work_Click(object sender, RoutedEventArgs e)
        {
            if (player.JobsWork == true)
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

        private void GetJob_Click(object sender, RoutedEventArgs e)
        {
            Duuni.Children.Add(jobspop);
        }
    }
}
