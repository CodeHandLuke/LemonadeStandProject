﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UserInterface
    {
        //member variables (try to refrain from making static variables)


        //member methods
        public static string ChooseRestockChoice() //This is used to validate user input for restocking inventory
        {
            bool chosenRestockChoice = false;
            string restockChoice = "";
            while (!chosenRestockChoice)
            {
                restockChoice = (Console.ReadLine());
                Console.WriteLine("\n");
                switch (restockChoice)
                {
                    case "1":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "2":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "3":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "4":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "5":
                        chosenRestockChoice = true;
                        return restockChoice;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
            return restockChoice;
        }

        public static string ChooseMenuChoice() //This is used to validate user input for restocking inventory
        {
            bool chosenMenuChoice = false;
            string MenuChoice = "";
            while (!chosenMenuChoice)
            {
                MenuChoice = (Console.ReadLine());
                Console.WriteLine("\n");
                switch (MenuChoice)
                {
                    case "1":
                        chosenMenuChoice = true;
                        return MenuChoice;
                    case "2":
                        chosenMenuChoice = true;
                        return MenuChoice;
                    case "3":
                        chosenMenuChoice = true;
                        return MenuChoice;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
            return MenuChoice;
        }

        public static string ChooseRecipeChoice() //This is used to validate user input for setting daily recipe
        {
            bool chosenRecipeChoice = false;
            string recipeChoice = "";
            while (!chosenRecipeChoice)
            {
                recipeChoice = (Console.ReadLine());
                Console.WriteLine("\n");
                switch (recipeChoice)
                {
                    case "1":
                        chosenRecipeChoice = true;
                        return recipeChoice;
                    case "2":
                        chosenRecipeChoice = true;
                        return recipeChoice;
                    case "3":
                        chosenRecipeChoice = true;
                        return recipeChoice;
                    case "4":
                        chosenRecipeChoice = true;
                        return recipeChoice;
                    case "5":
                        chosenRecipeChoice = true;
                        return recipeChoice;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
            return recipeChoice;
        }

        public static string ValidateGameChoice()
        {
            bool isInputValid = false;
            string gameChoice = "";
            while (!isInputValid)
            {
                Console.WriteLine("Choose whether you want to play for 7, 14, or 21 days by typing in the '7', '14', or '21'...");
                gameChoice = Console.ReadLine();
                switch (gameChoice)
                {
                    case "7":
                        isInputValid = true;
                        Console.Clear();
                        return gameChoice;
                    case "14":
                        isInputValid = true;
                        Console.Clear();
                        return gameChoice;
                    case "21":
                        isInputValid = true;
                        Console.Clear();
                        return gameChoice;
                    default:
                        Console.WriteLine("Invalid Input, Try again.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            return gameChoice;
        }

        public static string ChosenNewGame() //this is used to validate user input to either restart game or exit app
        {
            bool isInputValid = false;
            string newGameChoice = "";
            while (!isInputValid)
            {
                Console.WriteLine("Press '1' to restart a new game or press '2' to exit the app.");
                newGameChoice = Console.ReadLine();
                switch (newGameChoice)
                {
                    case "1":
                        isInputValid = true;
                        Console.Clear();
                        return newGameChoice;
                    case "2":
                        isInputValid = true;
                        Console.Clear();
                        return newGameChoice;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input, Try again.");
                        Console.ReadLine();
                        break;
                }
            }
            return newGameChoice;
        }

        //public static double MathRoundFunction()
        //{

        //}
    }
}
