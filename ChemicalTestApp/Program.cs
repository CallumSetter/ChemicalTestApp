using System;
using System.Collections.Generic;

namespace ChemicalTestApp
{
    class Program
    {
        //Global Variables

        static List<string> chemicals = new List<string>() { "Cyanide", "Propane", "Alcohol" };
        private static int chemcialTested;


        //Methods and Functions




        static void Main(string[] args)
        {
            bool Running = true;
            bool checkinput = true;
            string ReRunInput;

            while (Running == true)
            {
                Console.WriteLine("Welcome to Chemical Test App\n");
                Console.WriteLine("---------- Menu ----------\n");
                Console.WriteLine("Enter a Chemical for Testing\n" +
                    "For Cyanide Press 1\n" +
                    "For Propane Press 2\n" +
                    "For Alcohol Press 3\n");

                // Make sure the user only enters the digits 1, 2 or 3 rather than any other number or type of input i.e. letters or symbols
                // This will be done by creating a catch so when a number is not 

                string MyInput = "0";
                int MyInt = 0;

                while ((MyInt < 1) || (MyInt > 3))
                {
                    try
                    {
                        //Get the number that the user entered
                        MyInput = Console.ReadLine();
                        MyInt = Convert.ToInt32(MyInput);
                    }
                    catch (System.FormatException)
                    {
                        //Display an error message if the user enters a letter
                        Console.WriteLine("\nThat is not an interger\n");
                    }

                    if ((MyInt < 1) || (MyInt > 3))
                    {
                        //Display an error message if the user enters an invalid input
                        Console.WriteLine("\nPlease enter option 1, 2 or 3\n");
                    }
                }

                int chemicalTested = MyInt;






                //Add the chemical that is being tested and measure the number of live germs


                Random randGen = new Random();

                float sumEfficency = 0;


                int[] GermNumbers = new int[5];
                GermNumbers[0] = 100000;
                Console.WriteLine($"Initail Germ Count: { GermNumbers[0] } \n");

                for (int i = 1; i < 5; i++)
                {
                    //After an amount of time the number of live germs is again measured
                    Console.WriteLine("Chemical is Being Tested Please Wait 5 Seconds\n");


                    //Wait 5 seconds for each test
                    System.Threading.Thread.Sleep(1000);


                    //Live germs are measured again
                    //int afterChemicalTest = randGen.Next(0, initailChemicalTest);
                    GermNumbers[i] = randGen.Next(0, GermNumbers[i - 1]);

                    Console.WriteLine($"Number of Germs Left: {GermNumbers[i]}\n");

                    //Determine the efficiency of the chemical of it killing germs
                    float efficiency = (GermNumbers[i - 1] - GermNumbers[i]) / 5;


                    sumEfficency += efficiency;


                    //Loop 5 times
                }


                //Calculate the final effciency
                float finalEffciency = sumEfficency / 5;




                //Display the chemical name and its final effciency rating
                Console.WriteLine($"Chemical tested: {chemicals[chemicalTested - 1]} {finalEffciency} \n");



                //The process gets repeated with other chemicals

                do
                {
                    //Ask the user if they want to run the program again
                    Console.WriteLine("\nPress y to Run Again or Press n to Exit\n");
                    ReRunInput = Console.ReadLine();
                    switch (ReRunInput)
                    {
                        //Display the menu if the user wants to test another chemcial
                        case "y":
                            checkinput = true;
                            Running = true;

                            break;

                        //Display a thank you message if the user wants to exit    
                        case "n":
                            checkinput = true;
                            Running = false;
                            Console.WriteLine("Thank you for using ChemicalTestApp");

                            break;

                        //Display an error message if the user enters an invalid input 
                        default:
                            Console.WriteLine("\nThat is not a valid input...\n\n");

                            checkinput = false;
                            Running = true;
                            break;
                    }
                }
                while (checkinput == false);


                Console.WriteLine("\nRunning is " + Running + "\n");



                //Record the data and determine the least and most efficient chemical
            }
        }
    }
}
