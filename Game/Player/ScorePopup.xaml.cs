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
using Game.Buildings;
using System.Diagnostics;
using Game;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Game.Player
{
    public sealed partial class ScorePopup : UserControl
    {
        private MainPage page;

        public Player player { get; set; }
        
        public ScorePopup(MainPage page)
        {
            this.InitializeComponent();
            player = (App.Current as App).player;
            this.page = page;
            EducationSlider.Value = (App.Current as App).player.PEducation;
            HappySlider.Value = (App.Current as App).player.PHappiness;
            MoneySlider.Value = (App.Current as App).player.PMoney;
            
            
            
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
            page.close();
        }
    }
}
