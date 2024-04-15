using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace st10152431_PROG6221_POE_Part1
{
    internal class Program
    {
        //-------------------------------------------------------------The application's entry-point (has the Main method)... Displays Menu and is responsible for user inputs. 
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear Data");
                Console.WriteLine("6. ChatGPT cheat");
                Console.WriteLine("7. Exit");

                int choice = Recipe.GetPositiveIntegerInput();

                switch (choice)
                {
                    case 1:
                        Recipe recipe = new Recipe();
                        recipe.EnterRecipeDetails();
                        recipeManager.AddRecipe(recipe);
                        break;

                    case 2:
                        recipeManager.DisplayAllRecipes();
                        break;

                    case 3:
                        Console.WriteLine("Enter the index of the recipe you want to scale:");
                        int recipeIndex = Recipe.GetPositiveIntegerInput() - 1;
                        if (recipeIndex >= 0 && recipeIndex < recipeManager.GetRecipeCount())
                        {
                            Recipe selectedRecipe = recipeManager.GetRecipeAtIndex(recipeIndex);
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                            double factor = Recipe.GetPositiveDoubleInput();
                            selectedRecipe.ScaleRecipe(factor);
                        }
                        else
                        {
                            Console.WriteLine("Invalid recipe index.");
                        }
                        break;

                    case 4:
                        Console.Write("Enter the recipe number to reset quantities: ");
                        int recipeNumber = Recipe.GetPositiveIntegerInput();
                        recipeManager.ResetQuantitiesOfRecipe(recipeNumber);
                        break;

                    case 5:
                        recipeManager.ClearAllRecipesData();
                        Console.WriteLine("Recipe data for all recipes has been cleared.");
                        break;

                    case 6:
                        recipeManager.ChatGPTworker();
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            }
        }
        //-------------------------------------------------------------
    }
}
//-------------------------------------------------------.o0 END OF FILE 0o.---------------------------------------------------------

