using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
	 class Recipe
	{
		private List<Ingredient> ingredients;
		private List<string> steps;
		public string name { get; }
		public Recipe(string name)


		{
			ingredients = new List<Ingredient>();
			steps = new List<string>();
			this.name = name;
		}

		public Recipe()
		{
		}

		//adds ingredients
		public void AddIngredient(string name, double quantity, string unit, int calories, string fGroup)
		{
			Ingredient ingredient = new Ingredient(name, quantity, unit, calories, fGroup);
			ingredients.Add(ingredient);
		}
		//adds steps
		public void AddStep(string stepDescription)
		{
			steps.Add(stepDescription);
		}
		//method to display one recipe
		public void DisplayRecipe()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Recipe Details: {name}");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Ingredients:");
			foreach (Ingredient ingredient in ingredients)
			{
				Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
			}
			Console.WriteLine("\nSteps:");
			for (int i = 0; i < steps.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {steps[i]}");
			}
			Console.WriteLine();
		}

		//method to scale the recipe ingredients
		public void ScaleRecipe(double scaleFactor)
		{
			foreach (Ingredient ingredient in ingredients)
			{
				scaleFactor *= ingredient.Quantity ;
			}
		}

		//method to calculate the total calories of the recipe ingredients
		public int CalculateTotalCalories()
		{
			int totalCalories = 0;
			foreach (Ingredient ingredient in ingredients)
			{
				totalCalories += ingredient.Calories;
			}
			return totalCalories;
		}
		
		//method to reset ingredient quantities
		public void ResetQuantities()
		{
			foreach (Ingredient ingredient in ingredients)
			{
				ingredient.ResetQuantity();
			}
		}
		//method to clear recipe details
		public void ClearRecipe()
		{
			foreach (Ingredient ingredient in ingredients)
			{
				ingredients.Clear();
				steps.Clear();
			}
		}
	}
}

