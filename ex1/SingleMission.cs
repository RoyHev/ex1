using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private MathFuncionPointer mathFunctionPtr;
        private string name;
        private string type;

        public SingleMission (MathFuncionPointer mathFunctionPointer, string name)
        {
            this.name = name;
            this.mathFunctionPtr = mathFunctionPointer;
            this.type = "Single";
        }
        public string Name {
            get
            {
                return name;
            }
        }

        public string Type {
            get
            {
                return type;
            }
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double result = this.mathFunctionPtr(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
