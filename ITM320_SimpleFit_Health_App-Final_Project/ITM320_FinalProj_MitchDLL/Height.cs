using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITM320_FinalProj_MitchDLL
{
    public class Height
    {
        public double heightValue { get; set; }
        public Height(double height)
        {
            if (height < 0 || height > 300)
            {
                throw new ArgumentException("Invalid input. Height must be between 0 and 300 centimeters.");
            }
            else
            {
                heightValue = height;
            }
        }

    }
}
