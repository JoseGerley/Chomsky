using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class Produccion : IProduccion
    {
        private ICollection<ProduccionUnica> productions;
        private Elemento element;

        public Produccion(Elemento v)
        {
            productions = new LinkedList<ProduccionUnica>();
            element = v;
        }

        public void addProductionUnique(ICollection<Elemento> elements)
        {
            ProduccionUnica aux = new ProduccionUnica();
            aux.elements = elements;
            productions.Add(aux);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void deleteUniqueProductio(ProduccionUnica p)
        {
            productions.Remove(p);
        }

        public Elemento getPrincipalVariable()
        {
            return element;
        }

        public ProduccionUnica getProduction(int pos)
        {
            return productions.ElementAt(pos);
        }

        public ICollection<ProduccionUnica> listProductionUnique()
        {
            return productions;
        }


        public void setVariable(Elemento v)
        {
            element = v;
        }

        public string toString()
        {
            String aux = "";
            aux += "" + element.id;
            aux += "->";
            foreach(ProduccionUnica p in productions)
            {
                aux += p.toString();
                aux += "|";
            }
            return aux;
        }
        //Update the elementos of a unique production
        public void updateElements(int pos, ICollection<Elemento> elementos)
        {
            productions.ElementAt(pos).elements = elementos;
        }
        //receive a unique production and chage this production for another in a position selected
        public void updateProduction(ICollection<ProduccionUnica> fixedProduction, int pos)
        {
            productions = fixedProduction;
        }
    }
}
