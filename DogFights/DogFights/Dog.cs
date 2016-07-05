using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFights
{
    class Dog
    {
        private float fitness { get; set; }
        public float Fitness {
            get { return fitness; }
        }


        private string genetics { get; set; }

        public string Genetics
        {
            get { return genetics; }
        }

        public void SetGenetics(string str)
        {
            genetics = str;
        }

        private float strength { get; set; }
        private float stamina { get; set; }
        private float dexterity { get; set; }

        public float Strength {
            get {return strength; }
        }
        public float Stamina
        {
            get { return stamina; }
        }
        public float Dexterity
        {
            get { return dexterity; }
        }


        public float HP { get; set; }

        public Dog()
        {
            genetics = "000";
            strength = float.Parse(genetics.Substring(0, 1)) + 1;
            stamina = float.Parse(genetics.Substring(1, 1));
            dexterity = float.Parse(genetics.Substring(2, 1))+1;
            HP = stamina*3 + 3;
        }

        public Dog(string genecode)
        {
            genetics = genecode;
            strength = float.Parse(genetics.Substring(0, 1))+1;
            stamina = float.Parse(genetics.Substring(1, 1));
            dexterity = float.Parse(genetics.Substring(2, 1))+1;
            HP = stamina * 3 + 3;
        }

        public void SetFitness(float fitn)
        {
            fitness += fitn;
        }
    }
}
