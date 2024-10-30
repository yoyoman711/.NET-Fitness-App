using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITM320_FinalProj_MitchDLL
{
    public class Weight
    {
        public double weightValue { get; set; }
        public Weight(double weight)
        {
            if (weight < 0 || weight > 1000)
            {
                throw new ArgumentException("Invalid input. Weight must be between 0 and 1000 kilograms.");
            }
            else 
            {
                weightValue = weight;
            }
        }

    }
}
