using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player
{
    class Player1
    {
        public string PName { get; set; }
        public string PJob { get; set; }
        public bool PFood { get; set; }
        public string PItems { get; set; }
        public int Work { get; set; }


        //tee listaksi
        public double PMoney
        {
            get
            {
                return PMoney;
            }
            set
            {
                PMoney = 200;
            }
        }
        public int PScore
        {
            get
            {
                return PScore;
            }
            set
            {
                PScore = 0;
            }
        }
        public int PHappiness
        {
            get
            {
                return PHappiness;
            }
            set
            {
                PHappiness = 0;
            }
        }
        public int PTime
        {
            get
            {
                return PTime;
            }
            set
            {
                PTime = 50;
            }
        }
        
    }
}
