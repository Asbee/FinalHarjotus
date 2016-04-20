using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game.Player
{
    public class Player1
    {
        public bool MarketWork { get; set; }
        public bool UniversityWork { get; set; }
        public bool BurgerWork { get; set; }
        public bool JobsWork { get; set; }
        public bool BarWork { get; set; }

      
        public string PName { get; set; }
        public bool PFood { get; set; }
        public string PItems { get; set; }

        public int PMoney { get; set; }
        public int PScore { get; set; }
        public int PHappiness {  get; set; }   
        public int PTime { get; set; }
        public int PEducation { get; set; }

        public Player1()
        {           
            PMoney = 200;
            PScore = 0;
            PHappiness = 0;
            PEducation = 1;
            PTime = 3;
        }

        //Metodit
        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {
            Debug.WriteLine("The '" + command.Label + "' command has been selected.");
        }
        public void Work(int value, int time)
        {
            PMoney += value;
            PTime -= time;
        }
        public void Buy(int value)
        {
            PMoney -= value;
            PTime--;
        }
        public void Education ()
        {
            PEducation++;
            PTime--;
        }
        public void Relax(int relax, int time)
        {
            PHappiness += relax;
            PTime--;
        }
        public void Clock()
        {
           
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
        public async void RoundCheck()
        {
         if (PTime == 0)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("This week is over, next player get ready!");
                messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
                await messageDialog.ShowAsync();
                NewRound();
            }   
        }

    }

}
