using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
	class Ingredient
	{
		public string Name { get; }
		public double Quantity { get; set; }
		public string Unit { get; }
		public int Calories { get; }
		public string FoodGroup { get; }

		private readonly double originalQuantity;

		public Ingredient(string name, double quantity, string unit, int calories, string fGroup)
		{
			Name = name;
			Quantity = quantity;
			Unit = unit;
			originalQuantity = quantity;
			Calories = calories;
			FoodGroup = fGroup;
		}

		public void ResetQuantity()
		{
			Quantity = originalQuantity;
		}
	}
}
