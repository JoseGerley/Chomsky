using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class Variable : Elemento
    {

        public static char initial = 'S';

        public Variable(char id) :base (id)
        {
            
            if (id.Equals(initial))
                special = true;
            else
                special = false;
        }

    }
}
