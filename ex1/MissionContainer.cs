using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excercise_1
{
    public delegate double MathFuncionPointer(double d);

    public class FunctionsContainer {

        private Dictionary<string, MathFuncionPointer> funcDictionary;

        public FunctionsContainer() {

            funcDictionary = new Dictionary<string, MathFuncionPointer>();
        }

        public MathFuncionPointer this[string key] {

            get {
                if (funcDictionary.ContainsKey(key)){
                    return funcDictionary[key];
                } else {
                    funcDictionary[key] = val => val;
                    return funcDictionary[key];
                }
            }

            set {
                if (value != null) {
                    funcDictionary[key] = value;
                }
            }
        }

        public List<string> getAllMissions(){
            return funcDictionary.Keys.ToList();

        }

    }
}
