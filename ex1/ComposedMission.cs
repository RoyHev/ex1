using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private string name;
        private string type;
        private List<MathFuncionPointer> mathFuncPtrList;

        public event EventHandler<double> OnCalculate;

        public ComposedMission(string name)
        {
            this.name = name;
            this.type = "Composed";
            this.mathFuncPtrList = new List<MathFuncionPointer>();
        }

        public string Name {
            get
            {
                return this.name;
            }
        }

        public string Type {
            get {
                return this.type;
            }
        }

        public ComposedMission Add (MathFuncionPointer ptr)
        {
            this.mathFuncPtrList.Add(ptr);
            return this;
        }

        

        public double Calculate(double value)
        {
            double result = value;
            foreach (var funcPtr in this.mathFuncPtrList) {
                result = funcPtr(result);
            }
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
