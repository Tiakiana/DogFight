using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFights
{
    class FightManager
    {
        private float fitnessForWinning = 100;
        private float fitnessForHitting = 15;
        private float fitnessForSurviving = 0;
        Random rnd = new Random();
        public Dog Fight(Dog fir, Dog sec)
        {
            bool bothDogsAlive = true;
            Dog winner = null;
            while (bothDogsAlive)
            {
                if (fir.Dexterity>= rnd.Next(1,11))
                {
                    sec.HP -= fir.Strength;
                    fir.SetFitness(fitnessForHitting + fir.Strength*3);
                    if (sec.HP>0)
                    {
                        sec.SetFitness(fitnessForSurviving);
                    }
                }
                if (sec.HP>0 && sec.Dexterity>= rnd.Next(1,11))
                {
                    fir.HP -= sec.Strength;
                    sec.SetFitness(fitnessForHitting + sec.Strength*3);
                    if (fir.HP>0)
                    {
                        fir.SetFitness(fitnessForSurviving);
                    }
                }
                if (sec.HP<= 0)
                {
                    fir.SetFitness(fitnessForWinning);
                    bothDogsAlive = false;
                    winner = fir;
                }
                if (fir.HP<= 0)
                {
                    sec.SetFitness(fitnessForWinning);
                    bothDogsAlive = false;
                    winner = sec;
                }


            }

            return winner;

        }



    }
}
