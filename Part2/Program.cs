using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			

			List<Recipe> recipes = new List<Recipe>();

			bool exit = false;
			while (!exit)
			{
				Console.WriteLine("Please choose an option:");
				Console.WriteLine("1.Enter a new recipe");
				Console.WriteLine("2.display recipe details");
				Console.WriteLine("3.Display all recipes");
				Console.WriteLine("4. Scale the recipe");
				Console.WriteLine("5. Reset quantities");
				Console.WriteLine("6. Clear the recipe and enter a new one");
				Console.WriteLine("7. Exit");

				int option = int.Parse(Console.ReadLine());
				Recipe rec = new Recipe();
				switch (option)
				{
					case 1:
						Recipe recipe1 = inputRecipe ();
						recipes.Add (recipe1);
						break;
					case 2:
						DisplayAllRecipes(recipes);
						break;
					case 3:
						DisplayRecipeDetails(recipes);
							break;

					case 4:
						Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
						double scaleFactor = double.Parse(Console.ReadLine());
						rec.ScaleRecipe(scaleFactor);
						rec.DisplayRecipe();
						break;
					case 5:
						rec.ResetQuantities();
						rec.DisplayRecipe();
						break;
					case 6:
						rec.ClearRecipe();
						
						break;
					case 7:
						exit = true;
						break;
					default:
						Console.WriteLine("Invalid option! Please try again.");
						break;
				}
			}

		}
		static Recipe inputRecipe()
		{
			Console.WriteLine("==============================================================================================");
			Console.ForegroundColor = ConsoleColor.Green;
			//prompt user to enter recipe name
			Console.WriteLine("Please enter the recipe name:");
			string recName = Console.ReadLine();
			//create object for Recipe
			Recipe recipe = new Recipe(recName);

			Console.ForegroundColor = ConsoleColor.Green;
			//method to get user input for recipe 
			Console.WriteLine("============USER RECIPE INPUT=============");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Enter the number of ingredients:");
			int ingredientCount = int.Parse(Console.ReadLine());

			//used a for loop to count the ingredients
			for (int i = 0; i < ingredientCount; i++)
			{
				//here im prompting the user to add details about the ingredients
				Console.WriteLine($"Enter the name of ingredient {i + 1}:");
				string name = Console.ReadLine();

				Console.WriteLine($"Enter the quantity of {name}:");
				double quantity = double.Parse(Console.ReadLine());

				Console.WriteLine($"Enter the unit of measurement for {name}:");
				string unit = Console.ReadLine();

				Console.WriteLine($"Enter the number of calories for {name}:");
				int calories = int.Parse(Console.ReadLine());

				Console.WriteLine($"Enter the food group for {name}:");
				string fGroup = Console.ReadLine();
				recipe.AddIngredient(name, quantity, unit, calories, fGroup);
			}

			//get steps from user
			Console.WriteLine("Enter the number of steps:");
			int stepCount = int.Parse(Console.ReadLine());

			//loop to count the steps stepCount
			for (int i = 0; i < stepCount; i++)
			{
				Console.WriteLine($"Enter step {i + 1}:");
				string stepDescription = Console.ReadLine();

				recipe.AddStep(stepDescription);
			}

			Console.WriteLine(" Your Recipe has been created successfully!");
			Console.WriteLine("==============================================================================================");
			//used to return a value
			return recipe;
			
		}

		//method to display recipe details
		private static void DisplayRecipeDetails(List<Recipe> recipes)
		{
			Console.WriteLine("==============================================================================================");
			if (recipes.Count == 0)
			{
				Console.WriteLine("No recipes available.");
				return;
			}

			Console.WriteLine("Enter the recipe number to display details:");
			int recipeNumber = int.Parse(Console.ReadLine());

			if (recipeNumber >= 1 && recipeNumber <= recipes.Count)
			{
				Recipe selectedRecipe = recipes[recipeNumber - 1];
				selectedRecipe.DisplayRecipe();

				int totalCalories = selectedRecipe.CalculateTotalCalories();
				Console.WriteLine($"Total Calories: {totalCalories}");

				if (totalCalories > 300)
				{
					Console.WriteLine("WARNING: Total calories exceed 300!");
				}
			}
			else
			{
				Console.WriteLine("Invalid recipe number!");
			}
		}
		//method to display all the recipes
		private static void DisplayAllRecipes(List<Recipe> recipes)
		{
			Console.WriteLine("==============================================================================================");
			if (recipes.Count == 0)
			{
				Console.WriteLine("No recipes available.");
				return;
			}

			List<Recipe> sortedRecipes = recipes.OrderBy(r => r.name).ToList();

			Console.WriteLine("All Recipes:");
			for (int i = 0; i < sortedRecipes.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {sortedRecipes[i].name}");
			}
		}
	}
}
