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
        public int PDrink { get; set; }
      
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
            PTime = 10;
            PDrink = 0;
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
