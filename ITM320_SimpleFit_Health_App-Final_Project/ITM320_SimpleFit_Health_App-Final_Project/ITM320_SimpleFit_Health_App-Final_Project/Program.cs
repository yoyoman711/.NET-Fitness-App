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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SimpleFit: Health App");

            int choice;

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

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Welcome to the BMI calculator!");
                            Console.WriteLine("Please enter your height in centimeters:");
                            double heightBMI = double.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your weight in kilograms:");
                            double weightBMI = double.Parse(Console.ReadLine());

                            string result = BMICalc.CalculateBMI(heightBMI, weightBMI);

                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 2:
                        try
                        {
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
                        Console.WriteLine("Welcome to the Calorie Lookup Database!");
                        Console.WriteLine("Please enter the name of food item (chicken/bagel/orange/apple/egg)");
                        string itemName = Console.ReadLine();
                        try
                        {
                            int calories = CalorieLookup.GetCalories(itemName);
                            Console.WriteLine($"Calories in a {itemName}: {calories}");
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
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 0);
        }
    }
}