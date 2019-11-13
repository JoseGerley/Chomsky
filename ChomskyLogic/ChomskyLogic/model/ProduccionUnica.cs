using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class ProduccionUnica
    {
        public ICollection<Elemento> elements { get; set; }

        public ProduccionUnica()
        {
            elements = new LinkedList<Elemento>();
        } 

        public String toString()
        {
            String aux = "";
            foreach(Elemento e in elements){
                aux += e.id;
            }
            return aux;
        }
    }
}
