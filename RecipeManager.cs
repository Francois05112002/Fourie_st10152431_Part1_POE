using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10152431_PROG6221_POE_Part1
{
    //-------------------------------------------------------------Manages a collection of recipes
    internal class RecipeManager
    {
        private List<Recipe> recipes;

        //-------------------------------------------------------------Constructor
        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }
        //-------------------------------------------------------------


        //-------------------------------------------------------------Adds a recipe to the collection
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }
        //-------------------------------------------------------------


        //-------------------------------------------------------------Displays details of all recipes in the collection
        public void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("\nAll Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"Recipe {i + 1}:");
                recipes[i].DisplayRecipe();
            }
        }
        //-------------------------------------------------------------


        //-------------------------------------------------------------Gets the number of recipes in the collection
        public int GetRecipeCount()
        {
            return recipes.Count;
        }
        //-------------------------------------------------------------


        //-------------------------------------------------------------Gets the recipe at a specified index in the collection
        public Recipe GetRecipeAtIndex(int index)
        {
            if (index >= 0 && index < recipes.Count)
            {
                return recipes[index];
            }
            else
            {
                return null;
            }
        }
        //-------------------------------------------------------------


        //-------------------------------------------------------------Resets the quantities of a specified recipe to their original values
        public void ResetQuantitiesOfRecipe(int recipeNumber)
        {
            if (recipeNumber <= 0 || recipeNumber > recipes.Count)
            {
                Console.WriteLine("Invalid recipe number.");
                return;
            }

            recipes[recipeNumber - 1].ResetQuantities();
            Console.WriteLine($"Quantities of recipe {recipeNumber} have been reset to original values.");
        }
        //-------------------------------------------------------------


        //-------------------------------------------------------------Clears all data (ingredients and steps) of all recipes in the collection
        public void ClearAllRecipesData()
        {
            foreach (var recipe in recipes)
            {
                recipe.ClearData();
            }
        }
        //-------------------------------------------------------------


        //-------------------------------------------------------------Initiates the ChatGPT cheat for the recipe manager
        public void ChatGPTworker()
        {
            Recipe recipe = new Recipe();
            recipe.ChatGPT();
        }
        //-------------------------------------------------------------
    }
    //-------------------------------------------------------------
}
//-------------------------------------------------------.o0 END OF FILE 0o.---------------------------------------------------------


