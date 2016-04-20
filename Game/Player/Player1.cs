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
        public int PMoney { get; set; }
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
        public int PTime { get; set; }
        public int PEducation { get; set; }

        public Player1()
        {           
            PMoney = 200;
            PScore = 0;
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
        public void RoundCheck()
        {
           if(PTime == 0)
            {
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
