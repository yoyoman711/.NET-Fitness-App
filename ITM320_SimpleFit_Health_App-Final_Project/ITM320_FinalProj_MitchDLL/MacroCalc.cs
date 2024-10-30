using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITM320_FinalProj_MitchDLL
{
    public static class MacroCalc
    {
        public static double CalculateCalorieNeeds(string gender, double height, double weight, int age, int activityLevel)
        {
            if (height < 0 || height > 300)
            {
                throw new ArgumentException("Invalid input. Height must be between 0 and 300 centimeters.");
            }
            if (weight < 0 || weight > 1000)
            {
                throw new ArgumentException("Invalid input. Weight must be between 0 and 1000 kilograms.");
            }
            if (age < 0 || age > 150)
            {
                throw new ArgumentException("Invalid input. Age must be between 0 and 150 years.");
            }
            double bmr = 0;
            if (gender.ToLower() == "male")
            {
                bmr = (10 * weight) + (6.25 * height) - (5 * age) + 5;
            }
            else if (gender.ToLower() == "female")
            {
                bmr = (10 * weight) + (6.25 * height) - (5 * age) - 161;
            }
            else
            {
                throw new ArgumentException("Invalid gender. Please enter 'male' or 'female'.");
            }

            double activityFactor = 0;
            switch (activityLevel)
            {
                case 1:
                    activityFactor = 1.2;
                    break;
                case 2:
                    activityFactor = 1.375;
                    break;
                case 3:
                    activityFactor = 1.55;
                    break;
                case 4:
                    activityFactor = 1.725;
                    break;
                default:
                    throw new ArgumentException("Invalid activity level.Please enter a number 1-4. ");
            }

            double tdee = bmr * activityFactor;

            return tdee;

        }
        public static void CalculateMacroNeeds(double tdee, out double fatGrams, out double proteinGrams, out double carbGrams)
        {
            double fatRatio = 0.30;
            double fatCalories = tdee * fatRatio;
            fatGrams = fatCalories / 9;
            double proteinRatio = 0.30;
            double proteinCalories = tdee * proteinRatio;
            proteinGrams = proteinCalories / 4; 
            double carbRatio = 0.40;
            double carbCalories = tdee * carbRatio;
            carbGrams = carbCalories / 4;
        }
    }

}
