using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITM320_FinalProj_MitchDLL
{
    public class BMICalc
    {
        public Weight _Weight { get; }
        public Height _Height { get; }
        public BMICalc(Weight myWeight, Height myHeight)
        {
            _Weight = myWeight;
            _Height = myHeight;
        }
        public string CalculateBMI(Weight _Weight, Height _Height)
        {
            double bmi = _Weight.weightValue / Math.Pow(_Height.heightValue / 100, 2);

            string category = "";
            if (bmi < 18.5)
            {
                category = "Underweight";
            }
            else if (bmi < 25)
            {
                category = "Normal weight";
            }
            else if (bmi < 30)
            {
                category = "Overweight";
            }
            else
            {
                category = "Obese";
            }
            string message = $"Your BMI is {bmi:F1}. You are {category}.";

            return message;

        }
    }
}
    