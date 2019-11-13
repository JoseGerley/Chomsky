using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public abstract class Elemento : ICloneable
    {
        public char id { get; set; }
        public Boolean special { get; set; }
        

        public Elemento(char id)
        {
            this.id = id;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
