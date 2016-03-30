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

        public int PMoney;
        public int PScore;
        public int PTime = 50;
        public int PEducation;


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
        public void Education()
        {
            
        }

    }

}
