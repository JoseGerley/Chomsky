using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///The terminal class is responsible for identifying and treating the rules of the 
    ///the terminals and their special cases.
    ///</summary>
    public class Terminal : Elemento
    {

        //<summary>
        ///static variable to define the lambda value
        ///</summary>
        public static char lamda = '#';

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
        public Terminal(char id) : base (id)
        {
            if (id.Equals(lamda))
            {
                special = true;
            }
            else
            {
                special = false;
            }
        }


    }
}
