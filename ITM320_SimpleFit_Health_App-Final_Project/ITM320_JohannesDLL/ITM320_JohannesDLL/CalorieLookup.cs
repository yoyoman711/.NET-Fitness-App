using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITM320_JohannesDLL
{
    public class CalorieLookup : FoodItem
    {
        public int GetCalories(string foodName)
        {
            foodName = foodName.ToLower();

            if (foodName == "pear")
            {
                return pear;
            }
            else if (foodName == "apple")
            {
                return apple; 
            }
            else if (foodName == "orange")
            {
                return orange;
            }

            else if (foodName == "bagel")
            {
                return bagel;
            }

            else if (foodName == "egg")
            {
                return egg;
            }
            else
            {
                throw new ArgumentException("Food not found. Please enter a valid name.");
            }
        }

    }
}
