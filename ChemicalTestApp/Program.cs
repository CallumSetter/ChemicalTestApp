//Imports
using System; 
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

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
                "For Cyanide Press 1\n" +
                "For Propane Press 2\n" +
                "For Alcohol Press 3\n");

            // Make sure the user only enters the digits 1, 2 or 3 rather than any other number or type of input i.e. letters or symbols
            
            string MyInput = "0";
            int MyInt = 0;

            while ((MyInt < 1) || (MyInt > 3))
            {
                try
                {
                    MyInput = Console.ReadLine();
                    MyInt = Convert.ToInt32(MyInput);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\nThat is not an interger\n");
                }

                if ((MyInt < 1) || (MyInt > 3))
                {
                    Console.WriteLine("\nPlease enter option 1, 2 or 3\n");
                }
            }

            int chemicalTested = MyInt;




            //Add the chemical that is being tested



            //Measure the number of live germs

            Random randGen = new Random();

            float sumEfficency = 0;

            


            for (int i = 0; i < 5; i++)
            {
                int initailChemicalTest = randGen.Next(1000, 100000);

                Console.WriteLine($"Initail Germ Count: {initailChemicalTest}");

                //After an amount of time the number of live germs is again measured

                Console.WriteLine("Chemical is Being Tested Please Wait 5 Seconds\n");

               
                System.Threading.Thread.Sleep(1000); 
                

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

           


            //The process gets repeated with other chemicals

            //Record the data and determine the least and most efficient chemical
        }

        //


    }
}
