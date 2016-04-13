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
        public bool MarketWork { get; set; }
        public bool UniversityWork { get; set; }
        public bool BurgerWork { get; set; }
      
        public string PName { get; set; }
        public string PJob { get; set; }
        public bool PFood { get; set; }
        public string PItems { get; set; }

        public int PMoney { get; set; }
        public int PScore;
        public int PHappiness;   
        public int PTime = 50;
        public int PEducation = 0;

        public Player1()
        {
           
            PMoney = 200;
            PScore = 0;
            PHappiness = 0;
            PEducation = 1;
        }

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
           

        }

    }

}
