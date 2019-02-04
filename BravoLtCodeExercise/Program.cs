using System;
using System.Collections.Generic;

namespace BravoLtCodeExercise
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            int floorPref = 1;
            Console.WriteLine("Welcome to motel booking");
            Console.WriteLine("------------------------");
            Console.WriteLine("How many beds do you need?");
            Console.WriteLine("1, 2, or 3?");
            int bedCount = GetBeds();
            Console.WriteLine("Do you require handicap accessibility?");
            Console.WriteLine("Y or N");
            string isHandicap = YorN();
            Console.WriteLine("Do you have pets traveling with you?");
            Console.WriteLine("Y or N");
            string hasPets = YorN();
            int numberOfPets = 0;

            if (isHandicap == "N" && hasPets == "N")
            {
                Console.WriteLine("do you have a floor preference?");
                Console.WriteLine("1 or 2");
                floorPref = Convert.ToInt32(Console.ReadLine());
            }
            if (hasPets == "Y")
            {
                Console.WriteLine("There is a room charge of $20 per pet due to extensive cleaning required");
                Console.WriteLine("How Many Pets do you have?");
                numberOfPets = PetNumber();
                if (numberOfPets > 2)
                {
                    Console.WriteLine("I'm Sorry, that exceeds are maximum allotment of pets. " +
                        "You can not stay at our motel.");
                    Console.ReadLine();
                }
                else
                {
                    Checkout(floorPref, bedCount, numberOfPets);

                }
            }
            else
            {
                Checkout(floorPref, bedCount, numberOfPets);
            }
        }
        // checks that entered number is acceptable
        static int GetBeds()
        {
            string bedCount = Console.ReadLine();
            if (bedCount == "1" || bedCount == "2" || bedCount == "3")
            {
                return Convert.ToInt32(bedCount);
            }
            else
            {
                Console.WriteLine("sorry that is not one of the choices, try again");
                Console.WriteLine("How many beds do you need?");
                Console.WriteLine("1, 2, or 3?");
                return GetBeds();
            }
        }
        //checks that either Y or N is entered
        static string YorN()
        {
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                return "Y";
            }
            else if (answer == "N")
            {
                return "N";
            }
            else
            {
                Console.WriteLine("That is not one of the acceptable inputs.");
                Console.WriteLine("Please try again, Y or N");
                return YorN();
            }
        }

        //get number of pets
        static int PetNumber()
        {
            string NumberOfPets = Console.ReadLine();
            bool parsed = int.TryParse(NumberOfPets, out int petNumber);
            if (parsed == false)
            {
                Console.WriteLine("Sorry that is not a number, please try again.");
                return PetNumber();
            }
            else if (petNumber < 0)
            {
                Console.WriteLine("You can not have negative pets");
                return PetNumber();
            }
            return petNumber;
        }

        //give information about the room
        static void Checkout(int floor, int beds, int pets)
        {
            int total = getTotal(beds, pets);
            if (floor == 1)
            {
                Console.WriteLine("You will be on the 1st floor");
            }
            else
            {
                Console.WriteLine("you will be on the 2nd floor");
            }

            if (beds == 1)
            {
                Console.WriteLine("there will be 1 bed in your room");
            }
            else if (beds == 2)
            {
                Console.WriteLine("there will be 2 beds in your room");
            }
            else
            {
                Console.WriteLine("there will be 3 beds in your room");
            }
            Console.WriteLine("Your total will be {0} dollars", total);
            Console.ReadLine();
        }

        //total of room cost
        static int getTotal(int bedNumber, int petNumber)
        {
            int Total = 0;
            if (bedNumber == 1)
            {
                Total = 50;
            }
            else if (bedNumber == 2)
            {
                Total = 75;
            }
            else if (bedNumber == 3)
            {
                Total = 90;
            }
            Total = Total + petNumber * 20;
            return Total;
        }
    }
}
