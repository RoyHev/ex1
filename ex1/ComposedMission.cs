using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /**
     * ComposedMission class - A class to take care of a case in which we want
     * to calculate on the same value more than one mission.
     * 
    **/
    public class ComposedMission : IMission
    {
        private string name;
        private string type;
        private List<MathFuncionPointer> mathFuncPtrList;

        public event EventHandler<double> OnCalculate;

        /**
         * CCTOR 
         * 
        **/
        public ComposedMission(string name)
        {
            this.name = name;
            this.type = "Composed";
            this.mathFuncPtrList = new List<MathFuncionPointer>();
        }


        /**
         * name member's property.
         * 
        **/
        public string Name {
            //returns name.
            get
            {
                return this.name;
            }
        }

        /**
         * type member's property.
         * 
        **/
        public string Type {
            //return the type of mission.
            get {
                return this.type;
            }
        }

        /**
         * Add function, to allow the addition of any and all missions into the list.
         * 
        **/
        public ComposedMission Add (MathFuncionPointer ptr)
        {
            this.mathFuncPtrList.Add(ptr);
            return this;
        }


        /**
         * Calculate "recursively" on the first given value
         * 
        **/
        public double Calculate(double value)
        {
            //first initiate the value to the result.
            double result = value;
            //go over each function pointer in the list and calculate it on the previous result.
            foreach (var funcPtr in this.mathFuncPtrList) {
                result = funcPtr(result);
            }
            OnCalculate?.Invoke(this, result);
            //return the final result
            return result;
        }
    }
}
