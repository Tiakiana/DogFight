using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DogFights
{
    class Program
    {
        static Breeder br = new Breeder();

        static void StandardRun()
        {
            Console.Clear();
            Console.WriteLine(br.HighestFitness);
            br.MakeFighting();
            br.NaturalSelection();
            br.Breeding();
            br.CreateNewBatch();


            foreach (Dog item in br.Best)
            {
                Console.WriteLine(item.Genetics + "    " + item.Fitness);
           
            }
           
        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 150;

            

            br.StartPopulation(20);
            int x = 10;
            while (x!=0)
            {
                Console.WriteLine("PUPPYGRINDER 2000");
                Console.WriteLine("-Grinding puppies for better genetics");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("press [number] + [enter]");
                Console.WriteLine();
                Console.WriteLine("1: Single batch of puppies to be trained and fight each other to the death. Their deaths won't be in vain!");
                Console.WriteLine("2: 10 batches of puppies for the Grinder. Get a list of who has potential and who does not.");
                Console.WriteLine("3: 100 batches of puppies ready to spanked into lethal killing machines");
                Console.WriteLine("4: 500 batches of puppies will be mercilesly pitted against each other. Get the name and stats of the best performing puppy of all time.");
                Console.WriteLine("5: Halp!");

                switch (x)
                {
                    case 1:
                        StandardRun();
                        break;
                    case 2:
                        for (int i = 0; i < 10; i++)
                        {
                            StandardRun();
                            Console.WriteLine();
                            foreach (var VARIABLE in br.Potentials)
                            {
                                
                                Console.WriteLine(VARIABLE.Genetics);
                            }
                        }
                        break;

                    case 3:
                        for (int i = 0; i < 100; i++)
                        {
                            StandardRun();
                        }

                        break;

                    case 4:
                        for (int i = 0; i < 500; i++)
                        {
                            StandardRun();
                            Console.WriteLine("The Dog that has done the best is named Rufus, and it's stats are as follows:");
                            Console.WriteLine("Strength: 1+ " + br.Best[0].Genetics.Substring(0,1));
                            Console.WriteLine("Stamina: " + br.Best[0].Genetics.Substring(1,1));
                            Console.WriteLine("Dexterity: 1+ " + br.Best[0].Genetics.Substring(2, 1));
                            Console.WriteLine();
                            Console.WriteLine("We remember It fondly");


                        }

                        break;
                    case 5:
                        Console.WriteLine("First number to be displayed is the highest current fitness number");
                        Console.WriteLine("The next six 3-digit numbers are the current genetic makeup of the best puppies so far");
                        Console.WriteLine("Following the 3 digits are that dogs current fitness");
                        break;
                }

              
                

                x = Int32.Parse(Console.ReadLine());

            }


            Console.WriteLine("Exiting the PuppyGrinder 2000");
            Console.WriteLine("Press Any Key To Continue");
           
            Console.ReadKey();
            Console.WriteLine("Not that one!");
            Console.WriteLine("Try again");
            Console.ReadKey();


        }
    }
}
