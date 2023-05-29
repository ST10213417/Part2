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

			bool Quit = false;
			while (!Quit)
			{
				//menu that shows options user can pick
				Console.WriteLine("Please choose an option:");
				Console.WriteLine("1.Enter a new recipe");
				Console.WriteLine("2.Display all recipes");
				Console.WriteLine("3.Display recipe details");
				Console.WriteLine("4. Scale the recipe");
				Console.WriteLine("5. Reset quantities");
				Console.WriteLine("6. Clear the recipe and enter a new one");
				Console.WriteLine("7. Exit");

				int Choice = int.Parse(Console.ReadLine());

				//new object to call methods from another class
				Recipe rec = new Recipe();
				switch (Choice)
				{
					case 1:
						//call input recipe method
						Recipe Recipe1 = inputRecipe ();
						recipes.Add (Recipe1);
						break;
					case 2:
						//call method to display all the recips
						DisplayAllRecipes(recipes);
						break;
					case 3:
						//call method to display recope details
						DisplayRecipeDetails(recipes);
							break;

					case 4:
						//call scaling method from other class
						Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
						double scaleFactor = double.Parse(Console.ReadLine());
						rec.ScaleRecipe(scaleFactor);
						rec.DisplayRecipe();
						break;
					case 5:
						//call the method to rest the quatities from other class
						rec.ResetQuantities();
						rec.DisplayRecipe();
						break;
					case 6:
						//call method to clear recipe
						rec.ClearRecipe();
						
						break;
					case 7:
						//used to exit program
						Quit = true;
						break;
					default:
						//tells user if they selected an option that isnt available
						Console.WriteLine("Option! Please try again.");
						break;
				}
			}

		}
		//method to get user input for the recipes
		static Recipe inputRecipe()
		{
			Console.WriteLine("==============================================================================================");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("============USER RECIPE DETAILS=============");
			//prompt user to enter recipe name
			Console.WriteLine("Recipe name:");
			string recName = Console.ReadLine();
			//create object for Recipe
			Recipe recipe = new Recipe(recName);

			
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Number of ingredients:");
			int ingredientCount = int.Parse(Console.ReadLine());

			//used a for loop to count the ingredients
			for (int i = 0; i < ingredientCount; i++)
			{
				//here im prompting the user to add details about the ingredients
				Console.WriteLine($"Ingredient name {i + 1}:");
				string name = Console.ReadLine();

				Console.WriteLine($"Quantity of {name}:");
				double quantity = double.Parse(Console.ReadLine());

				Console.WriteLine($"Unit of measurement for {name}:");
				string unit = Console.ReadLine();

				Console.WriteLine($"Calories for {name}:");
				int calories = int.Parse(Console.ReadLine());

				Console.WriteLine($"Food group for {name}:");
				string fGroup = Console.ReadLine();
				recipe.AddIngredient(name, quantity,unit,calories,fGroup);
			}

			//get steps from user
			Console.WriteLine("Number of steps:");
			int stepCount = int.Parse(Console.ReadLine());

			//loop to count the steps stepCount
			for (int i = 0; i < stepCount; i++)
			{
				Console.WriteLine($"Enter step {i + 1}:");
				string stepDescription = Console.ReadLine();

				recipe.AddStep(stepDescription);
			}

			Console.WriteLine(" Your Recipe has been created successfully!");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("==============================================================================================");
			//used to return a value
			return recipe;

		}

		//method to display recipe details
		private static void DisplayRecipeDetails(List<Recipe> recipes)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("==============================================================================================");
			//if loop to check if theres any stored recipes available in the arraylist
			if (recipes.Count == 0)
			{
				Console.WriteLine("No recipes available.");
				return;
			}

			Console.WriteLine("Enter the recipe number to display details:");
			int recipeNum = int.Parse(Console.ReadLine());

			//if else loop to check if the calories are under or over 300 calories
			if (recipeNum >= 1 && recipeNum <= recipes.Count)
			{
				Recipe selectedRecipe = recipes[recipeNum - 1];
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
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("==============================================================================================");
			if (recipes.Count == 0)
			{
				Console.WriteLine("No recipes available.");
				return;
			}
			// display recipes in aplhabetical order
			List<Recipe> sortedRecipes = recipes.OrderBy(r => r.name).ToList();

			Console.WriteLine("All Recipes:");
			for (int i = 0; i < sortedRecipes.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {sortedRecipes[i].name}");
			}
		}
	}
}
