using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public abstract class Elemento
    {
        public char id { get; set; }
        public Boolean special { get; set; }
        

        public Elemento(char id)
        {
            this.id = id;
        }

    }
}
