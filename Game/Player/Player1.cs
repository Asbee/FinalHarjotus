using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game.Player
{
    class Player1
    {
        public string PName { get; set; }
        public string PJob { get; set; }
        public bool PFood { get; set; }
        public string PItems { get; set; }

        public int PMoney { get; set; }
        private int PMoney2 = 200;
        public int PScore;
        public int PHappiness;   
        public int PTime = 50;
        public int PEducation = 0;

        //Metodit
        public void Work(int value, int time)
        {

            PMoney += value;
            PTime -= time;


        }
        public void Buy(int value)
        {
            PMoney -= value;
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
        public void Clock()
        {
            if(PMoney2 < PMoney || PMoney2 > PMoney)
            {
               PMoney2 = PMoney;
            }

        }

    }

}
