using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /**
     * SingleMission class - A class that takes the function pointer and
     * calculates a single mission on a given value.
     * 
    **/
    public class SingleMission : IMission
    {
        private MathFuncionPointer mathFunctionPtr;
        private string name;
        private string type;

        /**
         * CCTOR
         * 
        **/
        public SingleMission (MathFuncionPointer mathFunctionPointer, string name)
        {
            this.name = name;
            this.mathFunctionPtr = mathFunctionPointer;
            this.type = "Single";
        }

        //name member's property.
        public string Name {
            //returns the name of the mission.
            get
            {
                return name;
            }
        }

        //type member's property.
        public string Type {
            //returns the type of the mission.
            get
            {
                return type;
            }
        }

        public event EventHandler<double> OnCalculate;

        /**
         * Invokes the calculate method on a given value, and returns the result of
         * the specific single mission.
         **/
        public double Calculate(double value)
        {
            //put in result the value and invoke the event handler.
            double result = this.mathFunctionPtr(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
