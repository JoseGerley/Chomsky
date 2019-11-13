using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class Terminal : Elemento
    {
        public static char lamda = '#';

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
