using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excercise_1
{
    public delegate double MathFuncionPointer(double d);

    /**
     * A class that defines a Dictionary for the name of a specific
     * math function pointer to it's function pointer.
     **/
    public class FunctionsContainer {
        //member
        private Dictionary<string, MathFuncionPointer> funcDictionary;

        /**
         * CCTOR
         **/
        public FunctionsContainer() {

            funcDictionary = new Dictionary<string, MathFuncionPointer>();
        }

        /**
         * Indexer for this class.
         **/
        public MathFuncionPointer this[string key] {
            //returns the pointer to the math function if exists, otherwise creates a new one.
            get {
                if (funcDictionary.ContainsKey(key)){
                    return funcDictionary[key];
                } else {
                    //initiate in the dictionary a new one and return it.
                    funcDictionary[key] = val => val;
                    return funcDictionary[key];
                }
            }
            //sets the key and value in the dictionary for a certain mission.
            set {
                if (value != null) {
                    funcDictionary[key] = value;
                }
            }
        }

        /**
         * Returns a list of all missions that exist in the dictionary.
         **/
        public List<string> getAllMissions(){
            return funcDictionary.Keys.ToList();

        }

    }
}
