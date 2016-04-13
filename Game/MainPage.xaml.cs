using System;
using Game.Buildings;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Game.Player;
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
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Burger burger;
        House house;
        University university;
        Market market;
        Jobs jobs1;
        Player1 player;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().TryResizeView(new Size { Width = 1250, Height = 600 });
            burger = new Burger();
            house = new House();
            university = new University();
            market = new Market();
            jobs1 = new Jobs();
            player =(App.Current as App).player;
        }                       

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Add(burger);
        }

        private void House_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Add(house);
        }

        private void University_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Add(university);
        }

        private void Market_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Add(market);
        }

        private void Jobs_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Add(jobs1);
        }

        private void ScoreBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
