#How to run RECIPE APP
Link: https://github.com/ST10213417/Part2

1.Click run in Visual Studio

2.App will provide menu with 7 options:
You can choose any option below
{
#Please choose an option:
1.Enter a new recipe
2.Display all recipes
3.Display recipe details
4. Scale the recipe
5. Reset quantities
6. Clear the recipe and enter a new one
7. Exit
}

if option #1
Program is going to prompt user to enter recipe details and those details consist of Ingrediet and Step details

if option #2
Program will print out and display all the recipes that have been enter already

if option #3
program will ask user to enter number of Recipe they want to display and then display it after user entered

if option #4
This will ask user to enter the number of recipe that they want to scale and then provide a scale menu for user and scale the recipe after user enter their option

if option #5
The program will reset all the quantities of the selected number of recipe

if option #6
This will Clear recipe that has been entered and prompt user to enter new one

if option #7
ends program

#Changes i made(Total words:133)

This updated code has 7 options on the menu available now unlike the part 1. This program allows users to enter more than one recipe
 and store more than one recipe at a time. I switched my arrays to list which is a c# version of arraylist. The contents/objects can
 be accessed through their respective index which allows to sort, search and modify list. The Program is making use of getters and 
setters now. I also added new methods such as “CalculateTotalCalories” and I make use of delegates to calculate the calories.The main
 has a new method to get user input, a method to display recipe details, method to display all the recipes at once in alphabetical order,
 method to calculate total calories of ingredients and warn the user if calories exceed 300.
