using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Xaml;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Game.Player
{
    public class Player : INotifyPropertyChanged 
    {
        MediaElement media;
        MainMenu.MainMenu mainmenu;
       

        public event PropertyChangedEventHandler PropertyChanged;
        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {
            Debug.WriteLine("The '" + command.Label + "' command has been selected.");
        }

        public bool MarketWork { get; set; }
        public bool UniversityWork { get; set; }
        public bool BurgerWork { get; set; }
        public bool JobsWork { get; set; }
        public bool BarWork { get; set; }
        public int PDrink { get; set; }
      
        public string PName { get; set; }
        public bool PFood { get; set; }
        public string PItems { get; set; }

        private int pmoney;
        private int pmoneyMin = 0;
        public bool ActivePlayer { get; set; }
        public int PMoney
        { get
            {  
                return pmoney;
            }
            set
            {
                if (value >= pmoneyMin)
                {
                    pmoney = value;
                    RaisePropertyChanged();
                }                
            }
        }
        
        public int PHappiness {  get; set; }
        private int ptime;  
        public int PTime
        {
            get
            {
                return ptime;
            }
            set
            {
                ptime = value;
                RaisePropertyChanged();
            }
        }
        public int PEducation { get; set; }
      
        public Player()
        {           
            PMoney = 200;          
            PHappiness = 0;
            PEducation = 0;
            PTime = 10;
            PDrink = 0;            
        }

        //Metodit
        public void Work(int value, int time)
        {
            PMoney += value;
            PTime -= time;
        }
        public void Buy(int value, int time)
        {
            PMoney -= value;
            PTime -= time;
        }
        public async void NoBuy()
        {
            var messageDialog = new Windows.UI.Popups.MessageDialog("Not enough money!");
            messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
            new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
            await messageDialog.ShowAsync();
        }
        public async void TooDrunk()
        {
            var messageDialog = new Windows.UI.Popups.MessageDialog("You are getting too drunk! Bartender wont serve for you anymore and you are thrown out of the Bar.");
            messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
            new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
            await messageDialog.ShowAsync();
        }
        public void Education ()
        {
            PEducation++;
        }
        public void Relax(int relax, int time)
        {
            PHappiness += relax;
            PTime -= time;
        }
        public async void RoundCheck()
        {
            
            if (PTime == 0)
            {
                
                var messageDialog = new Windows.UI.Popups.MessageDialog("Week is over! Next player, get ready!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("OK",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
                RoundEndSound();
                NewRound();
            }
        }
        public async void Winner()
        {
            WinnerSound();
            var messageDialog = new Windows.UI.Popups.MessageDialog("YOU WON!!!!");
            messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Start over!",
            new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
            await messageDialog.ShowAsync();
            (App.Current as App).GoMenu();
                   
        }
        public async void NewRound()
        {   
                                     
            if (PFood == true && PDrink <= 4)
            {               
                PTime = 10;                
            }
            if (PFood == false && PDrink > 4)
            {
                PTime = 5;                
                var messageDialog = new Windows.UI.Popups.MessageDialog("You forgot to eat, but you remembered to drink. Enjoy your hangover and starvation combination!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();                
            }
            if (PFood == false && PDrink <= 4)
            {
                PTime = 8;               
                var messageDialog = new Windows.UI.Popups.MessageDialog("You forgot to eat, less time for you!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();               
            }
            if (PFood == true && PDrink > 4)
            {
                PTime = 7;               
                var messageDialog = new Windows.UI.Popups.MessageDialog("You've got a hangover");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();                
            }
            if (PMoney >= 2000 && PEducation >= 30 && PHappiness >= 15)
            {
                Winner();
            }
            PFood = false;
            PDrink = 0;
        }

        //Sound Method
        public async void CashSound()
        {
            media = new MediaElement();
            media.AutoPlay = true;
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("CashRegister.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            media.SetSource(stream, file.ContentType);
        }
        public async void RoundEndSound()
        {
            media = new MediaElement();
            media.AutoPlay = true;
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("Rooster.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            media.SetSource(stream, file.ContentType);
        }
        public async void StudySound()
        {
            media = new MediaElement();
            media.AutoPlay = true;
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("StudySound.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            media.SetSource(stream, file.ContentType);
        }
        public async void WinnerSound()
        {
            media = new MediaElement();
            media.AutoPlay = true;
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("WinnerSound.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            media.SetSource(stream, file.ContentType);
        }

        

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}
