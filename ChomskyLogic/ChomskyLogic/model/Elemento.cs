using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///The abstract Elemento class is in charge of the logic regarding the 
    ///characteristics that an element contains.
    ///</summary>
    public abstract class Elemento : ICloneable
    {
        public char id { get; set; }
        public Boolean special { get; set; }

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>

        public Elemento(char id)
        {
            this.id = id;
        }

        /// <summary>
        /// This method is responsible for cloning an item
        /// </summary>
        /// <returns>
        /// object type object
        /// </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
