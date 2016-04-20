using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Game.Player
{
    public class Player1 : INotifyPropertyChanged
    {
        MediaElement media;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool MarketWork { get; set; }
        public bool UniversityWork { get; set; }
        public bool BurgerWork { get; set; }
        public bool JobsWork { get; set; }
        public bool BarWork { get; set; }
        public int PDrink { get; set; }
      
        public string PName { get; set; }
        public bool PFood { get; set; }
        public string PItems { get; set; }

        private int pscore { get; set; }
        private int pmoney;
        public int PMoney
        { get
            { return pmoney; }
            set
            {
                pmoney = value;
                RaisePropertyChanged();
            }
        }
        public int Score
        {
            get
            {
                return pscore;
            }
            set
            {
                pscore = value;
                RaisePropertyChanged();
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
        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {
            Debug.WriteLine("The '" + command.Label + "' command has been selected.");
        }
        public Player1()
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
           if(PTime == 0)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Week is over! Next player, get ready!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
                NewRound();
            }
        }
        public void NewRound()
        {
            if (PFood == true)
            {
                PTime = 10;
                PFood = false;
            }
            else
            {
                PTime = 8;
            }
        }


        //Sound Files
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

        

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}
