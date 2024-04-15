using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace st10152431_PROG6221_POE_Part1
{
    //-------------------------------------------------------------Represents a recipe containing ingredients and steps
    internal class Recipe
    {
        private ingredient[] ingredients;
        private string[] steps;

        //-------------------------------------------------------------Displays the details of the recipe including ingredients and steps
        public void DisplayRecipe()
        {
            Console.WriteLine("\nIngredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredient ingredient = ingredients[i];
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------Plays an MP3 file
        public static void PlayMp3(string filePath)
        {
            try
            {
                using (var reader = new Mp3FileReader(filePath))
                using (var waveOut = new WaveOutEvent())
                {
                    waveOut.Init(reader);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------Plays a specific MP3 file (Rick Astley in this case)
        public void ChatGPT()
        {
            Console.WriteLine("No 'ChatGPT' just Rick Astley :)");
            PlayMp3("nggyUP.mp3");
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------All references to sources used 
        public void References()
        {
            //Troelsen, A. (2023). Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming (Eleventh Edition). Apress.
            //Rick Astley, (1987). Never Gonna Give You Up [Recorded by R. Astley] on Whenever You Need Somebody. London, England: RCA Records.
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------
        public void ScaleRecipe(double factor)
        {
            if (factor != 0.5 && factor != 2 && factor != 3)
            {
                Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine($"Recipe scaled by a factor of {factor}.");
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------Resets the quantities of all ingredients in the recipe to their original values
        public void ResetQuantities()
        {
            if (ingredients == null)
            {
                Console.WriteLine("Recipe details have not been entered yet.");
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }

            Console.WriteLine("Quantities have been reset to original values.");
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------Enters the details of the recipe including ingredients and steps
        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numOfIngredients = GetPositiveIntegerInput();

            ingredients = new ingredient[numOfIngredients];

            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                ingredient ingredient = new ingredient();

                Console.Write("Name: ");
                ingredient.Name = Console.ReadLine();

                Console.Write("Quantity: ");
                double quantity = GetPositiveDoubleInput();
                ingredient.Quantity = quantity;
                ingredient.OriginalQuantity = quantity;

                Console.Write("Unit of measurement: ");
                ingredient.Unit = Console.ReadLine();

                ingredients[i] = ingredient;
            }

            Console.Write("Enter the number of steps: ");
            int numOfSteps = GetPositiveIntegerInput();

            steps = new string[numOfSteps];

            for (int i = 0; i < numOfSteps; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------
        public void ClearData()
        {
            ingredients = null;
            steps = null;
            Console.WriteLine("Recipe data has been cleared.");
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------Gets a positive integer input from the user
        public static int GetPositiveIntegerInput()
        {
            int input;
            while (true)
            {
                Console.Write("Enter a positive integer: ");
                if (int.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }
        }
        //-------------------------------------------------------------



        //-------------------------------------------------------------Gets a positive double input from the user
        public static double GetPositiveDoubleInput()
        {
            double input;
            while (true)
            {
                Console.Write("Enter a positive number: ");
                if (double.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
        }
        //-------------------------------------------------------------
    }
    //-------------------------------------------------------------
}
//-------------------------------------------------------.o0 END OF FILE 0o.---------------------------------------------------------
