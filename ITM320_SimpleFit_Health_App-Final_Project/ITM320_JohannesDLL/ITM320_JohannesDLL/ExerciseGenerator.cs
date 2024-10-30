using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITM320_JohannesDLL
{
    public class ExerciseGenerator
    {
        static string sunday = "20 jumping jacks";
        static string monday = "50 push ups";
        static string tuesday = "40 squats";
        static string wednesday = "10 deadlifts";
        static string thursday = "5 30-second wall sits";
        static string friday = "60 sit ups";
        static string saturday = "20 bicep curls";

        public static string GenerateExercise(string dayOfWeek)
        {
            dayOfWeek = dayOfWeek.ToLower();

            if (dayOfWeek == "sunday")
            {
                return sunday;
            }
            else if (dayOfWeek == "monday")
            {
                return monday;
            }
            else if (dayOfWeek == "tuesday")
            {   
                return tuesday;
            }
            else if (dayOfWeek == "wednesday")
            {
                return wednesday;
            }
            else if (dayOfWeek == "thursday")
            {
                return thursday;
            }
            else if (dayOfWeek == "friday")
            {
                return friday;
            }
            else if (dayOfWeek == "saturday")
            {
                return saturday;
            }
            else
            {
                throw new ArgumentException("Invalid day of week. Please enter valid day.");
            }
        }
    }
}
