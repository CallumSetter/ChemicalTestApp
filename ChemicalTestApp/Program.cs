//Imports
using System; 
using System.Collections.Generic;

namespace ChemicalTestApp
{
    class Program
    {
        //Global Variables

        static List<string> chemicals = new List<string>(){"Cyanide", "Propane", "Alcohol"};
        private static int chemcialTested;


        //Methods and Functions




        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chemical Test App\n");
            Console.WriteLine("---------- Menu ----------\n");
            Console.WriteLine("Enter a Chemical for Testing\n" +
                "1. Cyanide\n" +
                "2. Propane\n" +
                "3. Alcohol\n");


            //Add the chemical that is being tested
            int chemicalTested = Convert.ToInt32(Console.ReadLine());


            //Measure the number of live germs

            Random randGen = new Random();

            float sumEfficency = 0;

            


            for (int i = 0; i < 5; i++)
            {
                int initailChemicalTest = randGen.Next(1000, 100000);

                Console.WriteLine($"Initail Germ Count: {initailChemicalTest}");

                //After an amount of time the number of live germs is again measured

                Console.WriteLine("Chemical is Being Tested Please Wait 5 Seconds\n");

               
                System.Threading.Thread.Sleep(5000); 
                

                //Live germs are measured again
                int afterChemicalTest = randGen.Next(0, initailChemicalTest);

                Console.WriteLine($"Number of Germs Left: {afterChemicalTest}\n");

                //Determine the efficiency of the chemical of it killing germs

                float efficiency = (float)(initailChemicalTest - afterChemicalTest) / 5;

                sumEfficency += efficiency;


                //Loop 5 times
            }


            //Calculate the final effciency

            float finalEffciency = sumEfficency / 5;

             

            //Display the chemical name and its final effciency rating

            Console.WriteLine($"Chemical tested: {chemicals[chemicalTested -1]} {finalEffciency} \n");


                //Add the chemical that is being tested

            //After an amount of time the number of live germs is again measured

            //Determine the efficiency of the chemical of it killing germs

            //Loop 5 times

            //Display the chemical name and its final effciency rating

            //The process gets repeated with other chemicals

            //Record the data and determine the least and most efficient chemical
        }

        //


    }
}
