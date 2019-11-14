using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///This class is responsible for providing the structure of a variable
    ///</summary>
    public class Variable : Elemento
    {

        ///<summary>
        ///Static variable to define the initial state with the symbol 's'
        ///</summary>
        public static char initial = 'S';

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
        public Variable(char id) :base (id)
        {
            
            if (id.Equals(initial))
                special = true;
            else
                special = false;
        }

    }
}
