//Imports
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace ChemicalTestApp
{
    class Program
    {
        //Global Variables

        static List<string> chemicals = new List<string>() { "Cyanide", "Propane", "Alcohol", "Zync", "Cooper", "Hydrogen" };
        static List<int> chemicalTested = new List<int>();
        static List<float> chemicalEfficiencies = new List<float>();


        //Methods and Functions
        static string CheckProceed()
        {
            while (true)
            {
                Console.WriteLine("To rerun press y or to quit press n to exit\n");

                string proceed = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(proceed))
                {
                    proceed = proceed.ToLower().Substring(0, 1);

                    if (proceed.Equals("y") || proceed.Equals("n"))
                    {
                        return proceed;
                    }
                }
                Console.WriteLine("Please enter either y or n\n\n");
            }
            
        }

        static int CheckInt(string question, int min, int max)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine(question);

                    int userInput = Convert.ToInt32(Console.ReadLine());

                    if (userInput < min || userInput > max)
                    {
                        //Display an error message letting the user know that they must not choose a number higher than 3 or lower than 1
                        Console.WriteLine($"\nError: Please enter option between {min} and {max}\n");
                    }
                    else
                    {
                        if (chemicalTested.Contains(userInput))
                        {
                            Console.WriteLine("This chemical has already been tested. Choose another chemical.\n");
                        }
                        else
                        {
                            return userInput;
                        }
                    }


                }
                catch
                {
                    //Display an error message letting the user know that any type of letter is not an interger
                    Console.WriteLine("\nError: That is not an interger\n");
                }
            }
        }
        static void OneChemical()
        {
          
            chemicalTested.Add(CheckInt("\n---------- Menu ----------\n" +
                        "Enter a Chemical for Testing\n" +
                        "For Cyanide Press 1\n" +
                        "For Propane Press 2\n" +
                        "For Alcohol Press 3\n" +
                        "For Zync Press 4\n" +
                        "For Cooper Press 5\n" +
                        "For Hyrogen Press 6\n", 1, 6));


            //Add the chemical that is being tested and measure the number of live germs


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

            chemicalEfficiencies.Add(finalEffciency);



            //Display the chemical name and its final effciency rating

            Console.WriteLine($"Chemical tested: {chemicals[chemicalTested[chemicalTested.Count - 1] - 1]} {finalEffciency} \n");

            //Ask the user if they want to test another chemical or do they want to stop
        }

        static void SortChemicals()
        {
            for (int outer = 0; outer < chemicalEfficiencies.Count-1; outer++)
            {
                for (int inner = outer + 1; inner < chemicalEfficiencies.Count; inner++)
                {
                    if (chemicalEfficiencies[inner] > chemicalEfficiencies[outer])
                    {
                        int tempChem = chemicalTested[outer];
                        chemicalTested[outer] = chemicalTested[inner];
                        chemicalTested[inner] = tempChem;

                        float tempEff = chemicalEfficiencies[outer];
                        chemicalEfficiencies[outer] = chemicalEfficiencies[inner];
                        chemicalEfficiencies[inner] = tempChem;
;
                    }
                }
            }
        }

        static string DisplayChemicalRanking()
        {
            string ranking = "Final result for all chemicals are - \n";
            for (int chemIndex = 0; chemIndex < chemicalTested.Count; chemIndex++)
            {
                ranking += $"Chemical tested: {chemicals[chemicalTested[chemIndex] - 1]} {chemicalEfficiencies[chemIndex]}%\n";
            }

            return ranking;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chemical Test App\n");


            string reRun = "a";


            do
            {

                OneChemical();

                reRun = CheckProceed();


            }
            while (reRun.Equals("y"));

            Console.WriteLine("Thanks for using the chemical application\n");

            //Determine the least and most efficient chemical
            SortChemicals();

            Console.WriteLine(DisplayChemicalRanking());

            Console.WriteLine($"The most efficient chemical is: {chemicals[chemicalTested[0] - 1]} {chemicalEfficiencies[0]}%");

        }

    }

}

