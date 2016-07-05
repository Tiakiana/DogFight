using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFights
{
    class Breeder
    {
        Random rnd = new Random();
        FightManager FM = new FightManager();
        public List<Dog> Potentials = new List<Dog>();
        public List<Dog> NaturallySelected = new List<Dog>();
        public List<Dog> Fought = new List<Dog>();
        public List<Dog> Best = new List<Dog>();
        
        List<string> genestrings = new List<string>();
        public float HighestFitness = 0;


        private float mutationChance = 10;

        public void StartPopulation(int noOfStart)
        {
            for (int i = 0; i < noOfStart; i++)
            {
                string genes = "000";


                if (rnd.Next(1, 101) <= mutationChance)
                {
                    int r = rnd.Next(1, 4);
                    switch (r)
                    {
                        case 1:
                            genes = "100";
                            break;
                        case 2:
                            genes = "010";

                            break;
                        case 3:
                            genes = "001";

                            break;
                        default:
                            break;
                    }
                }


                Dog dog = new Dog(genes);
                Potentials.Add(dog);
            }

        }
        //Udvælger de seks bedste
        // Der skal her laves en liste over de all-time bedste kandidater som er dem vi tager og breeder fra.


        public void NaturalSelection()
        {
            

            List<Dog> sortedlists = Potentials.OrderByDescending(x => x.Fitness).ToList();
            Potentials = sortedlists;
            
            for (int i = 0; i < 6; i++)
            {
                if (Potentials[i].Fitness>=HighestFitness)          
                {
                NaturallySelected.Add(Potentials[i]);

                    HighestFitness = Potentials[i].Fitness;

                }
            }
            Best.AddRange(NaturallySelected);
            List<Dog> placehol = Best;
            Best = placehol.OrderByDescending(x => x.Fitness).ToList();
            if (Best.Count>6)
            {
                Best.RemoveRange(5,Best.Count-6);
            }

        }

        

        public void Breeding()
        {
            genestrings.Clear();
            Potentials.Clear();
            NaturallySelected.Clear();
            NaturallySelected = new List<Dog>(Best);
            int x = NaturallySelected.Count/2;
            for (int i = 0; i < x; i++)
            {
                // Select the subjects for mating.
                int choice = rnd.Next(0, NaturallySelected.Count);
                Dog d1 = NaturallySelected[choice];
                NaturallySelected.RemoveAt(choice);
                choice = rnd.Next(0, NaturallySelected.Count);
                Dog d2 = NaturallySelected[choice];
                NaturallySelected.RemoveAt(choice);



                //Switch genes

                int gene = rnd.Next(0, 3);
                char[] strain1 = d1.Genetics.ToCharArray();
                char[] strain2 = d2.Genetics.ToCharArray();
                char placeholder = strain1[gene];
                strain1[gene] = strain2[gene];
                strain2[gene] = placeholder;

                string s = new string(strain1);
                string s2 = new string(strain2);
                genestrings.Add(s);
                genestrings.Add(s2);


            }

        }

        public void CreateNewBatch()
        {
            foreach (string item in genestrings)
            {

                for (int i = 0; i < 10; i++)
                {
                    string genes = item;
                    if (rnd.Next(1, 101) < mutationChance)
                    {
                        char[] gen = genes.ToCharArray();
                        int genemutated = rnd.Next(0, 3);

                        
                        int val = (int)Char.GetNumericValue(gen[genemutated]);
                        val += rnd.Next(1, 4);
                        if (val<0)
                        {
                            val = 0;
                        }
                        string s = val.ToString();
                        gen[genemutated] = s[0];
                        genes = new string(gen); 

                    }
                    Dog d = new Dog(genes);
                    Potentials.Add(d);

                }


            }

        }

        public void MakeFighting()
        {
            int x = Potentials.Count/2;
            for (int i = 0; i < x; i++)
            {
                Dog d1;
                Dog d2;


                int dog1 = rnd.Next(0, Potentials.Count);
                d1 = Potentials[dog1];
                Fought.Add(d1);
                Potentials.RemoveAt(dog1);

                dog1 = rnd.Next(0, Potentials.Count);

                d2 = Potentials[dog1];
                Fought.Add(d2);
                Potentials.RemoveAt(dog1);



                 FM.Fight(d1, d2);
            }
            Potentials = Fought;

        }

    }
}
