using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITM320_FinalProj_MitchDLL;
using ITM320_JohannesDLL;

namespace ITM320_SimpleFit_Health_App_Final_Project
{
    class Program
    {
        //ITM 320: Final Project
        //Project Name: SimpleFit - A Health Application
        //Team Member 1: Mitch Donovan
        //Team Member 2: Johannes de Quant

        /*SimpleFit is a health application that allows you to track all your fitness needs! Complete with 4 different unique functions, including a BMI Calculator and an Exercise Generator,
        this app is the perfect app for any fitness enthusiast. */
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SimpleFit: Health App");

            int choice;

            //A do-while loop is utilized so that the main menu prompt is maintained while the user's choice is anything but '0'
            do
            {
                Console.WriteLine("\n Main Menu:");
                Console.WriteLine("1. BMI Calculator");
                Console.WriteLine("2. Macro Calculator");
                Console.WriteLine("3. Calorie Lookup");
                Console.WriteLine("4. Exercise Generator");
                Console.WriteLine("0. Exit");
                Console.Write("Please enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                //while the user's input is anything but '0', the program executes the respective case based on the user's input
                switch (choice)
                {
                    case 1:
                        try
                        {
                            //The first fucntion calculates the user's BMI
                            //It takes the the user's inputs as their height and weight in cm and kg respectively
                            //It then calculates their BMI and outputs it at as the result.
                            Console.WriteLine("Welcome to the BMI calculator!");
                            Console.WriteLine("Please enter your height in centimeters:");
                            double height = double.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your weight in kilograms:");
                            double weight = double.Parse(Console.ReadLine());

                            Height myHeight = new Height(height);
                            Weight myWeight = new Weight(weight);

                            BMICalc myBMICalc = new BMICalc(myWeight, myHeight);

                            string bmiResult = myBMICalc.CalculateBMI(myWeight, myHeight);

                            Console.WriteLine(bmiResult);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 2:
                        try
                        {
                            //The second function calculates the user's daily macronutrient needs.
                            //It takes 5 inputs from the user: gender, height, weight, age, and activity level.
                            //It then takes everything and calculates the total TDEE: Total Daily Energy Expenditure.
                            //Then, it calculates the calories needed from macros based on established ratios and converts their caloric value into grams.
                            //Afterward, the function outputs the daily calorie needs, as well as their daily protein, fat, and carbohydrate needs.
                            Console.WriteLine("Welcome to the Calorie and Macronutrient Calculator!");

                            Console.Write("Enter your gender (Male/Female): ");
                            string gender = Convert.ToString(Console.ReadLine());

                            Console.Write("Enter your height in centimeters: ");
                            double height = double.Parse(Console.ReadLine());

                            Console.Write("Enter your weight in kilograms: ");
                            double weight = double.Parse(Console.ReadLine());

                            Console.Write("Enter your age in years: ");
                            int age = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter your activity level:");
                            Console.WriteLine("1. Sedentary (little or no exercise)");
                            Console.WriteLine("2. Lightly active (light exercise or sports 1-3 days a week)");
                            Console.WriteLine("3. Moderately active (moderate exercise or sports 3-5 days a week)");
                            Console.WriteLine("4. Very active (hard exercise or sports 6-7 days a week)");
                            Console.Write("Enter your choice: ");
                            int activityLevel = int.Parse(Console.ReadLine());

                            double tdee = MacroCalc.CalculateCalorieNeeds(gender, height, weight, age, activityLevel);
                            double fatGrams, proteinGrams, carbGrams;
                            MacroCalc.CalculateMacroNeeds(tdee, out fatGrams, out proteinGrams, out carbGrams);


                            Console.WriteLine();
                            Console.WriteLine("RESULTS:");
                            Console.WriteLine($"Your estimated daily calorie needs are {tdee:F0} calories.");
                            Console.WriteLine($"Your estimated daily protein needs are {proteinGrams:F0} grams.");
                            Console.WriteLine($"Your estimated daily fat needs are {fatGrams:F0} grams.");
                            Console.WriteLine($"Your estimated daily carbohydrate needs are {carbGrams:F0} grams.");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception ed)
                        {
                            Console.WriteLine(ed.Message);
                        }
                        break;
                    case 3:

                        //The third function is the Calorie Lookup function.
                        //The calorie function pulls pre-defined caloric values of five food items: pear, bagel, orange, apple, or egg.
                        //Based on what the user wants to input, the user can "lookup" the value of these five items they choose to eat.
                        //The function will return the value of the food item the user wants to see.
                        Console.WriteLine("Welcome to the Calorie Lookup Database!");

                        CalorieLookup lookup = new CalorieLookup();

                        Console.WriteLine("Please enter the name of food item (pear/bagel/orange/apple/egg)");
                        string foodName = Console.ReadLine();

                        try
                        {
                            int calories = lookup.GetCalories(foodName);
                            Console.WriteLine($"Calories in a {foodName}: {calories}");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception ed)
                        {
                            Console.WriteLine(ed.Message);
                        }
                        break;
                    case 4:
                        //The fourth function is the Exercise Generator function.
                        //Like the calorie function, this function has pre-determined exercises stored as string values for each day of the week.
                        //The user can then choose a day of the week to exercise on, and the function will output a suggested exercise to do for that day.
                        Console.WriteLine("Welcome to the Exercise Generator!");
                        Console.WriteLine("Please day of the week you plan to exercise");
                        string dayOfWeek = Console.ReadLine();
                        try
                        {
                            string exercise = ExerciseGenerator.GenerateExercise(dayOfWeek);
                            Console.WriteLine($"Your exercise for {dayOfWeek}: {exercise}");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception ed)
                        {
                            Console.WriteLine(ed.Message);
                        }
                        break;
                    case 0:
                        //The program ends if the user chooses '0'
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        //If the user chooses any other invalid value in the main menu, it will output this message.
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 0);
        }
    }
}