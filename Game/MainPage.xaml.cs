using System;
using Game.Player;
using Game.Buildings;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Burger burger = new Burger();
        Player1 player = new Player1();


        //PääOhjelma
        public MainPage()
        {
            this.InitializeComponent();   
            
        }

        



        //Buttonit
        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Add(burger);
            
        }

        private void House_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
