using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///The ProduccionUnica class is responsible for the business logic of this element of
    ///grammar for this special case
    ///</summary>
    public class ProduccionUnica : ICloneable
    {
        public ICollection<Elemento> elements { get; set; }


        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
        public ProduccionUnica()
        {
            elements = new LinkedList<Elemento>();
        }
        /// <summary>
        /// This method is in charge of being used to convert to string to anyone who invokes it.
        /// </summary>
        /// <returns>
        /// string type aux
        /// </returns>
        public String toString()
        {
            String aux = "";
            foreach(Elemento e in elements){
                aux += e.id;
            }
            return aux;
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
