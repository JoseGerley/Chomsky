using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///The produccion class is responsible for the business logic of this element
    ///of grammar. Update, convert, add and modify variables.
    ///</summary>
    public class Produccion : IProduccion
    {
        private ICollection<ProduccionUnica> productions;
        private Elemento element;

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
        public Produccion(Elemento v)
        {
            productions = new LinkedList<ProduccionUnica>();
            element = v;
        }

        /// <summary>
        /// This method is responsible for adding a production using the incoming elements per parameter.
        /// </summary>
        /// <param name="elements">
        /// ICollection type elements
        /// </param>


        public void addProductionUnique(ICollection<Elemento> elements)
        {
            ProduccionUnica aux = new ProduccionUnica();
            aux.elements = elements;
            productions.Add(aux);
        }

        /// <summary>
        /// This method is responsible for cloning an element.
        /// </summary>
        /// <returns>
        /// object type object
        /// </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// This method is responsible for eliminating a  unique production according to the production entered by parameters
        /// </summary>
        /// <param name="p">
        /// ProduccionUnica type p
        /// </param>

        public void deleteUniqueProductio(ProduccionUnica p)
        {
            productions.Remove(p);
        }

        /// <summary>
        /// This method is responsible for providing the main production variable
        /// </summary>
        /// <returns>
        /// Element type of element
        /// </returns>
        public Elemento getPrincipalVariable()
        {
            return element;
        }

        /// <summary>
        /// This method is responsible for providing a production
        /// </summary>
        /// <param name="pos">
        /// int type of pos
        /// </param>
        /// <returns>
        /// ProduccionUnica type of productions
        /// </returns>
        public ProduccionUnica getProduction(int pos)
        {
            return productions.ElementAt(pos);
        }
        /// <summary>
        /// This method is responsible for providing a list of a unique production
        /// </summary>
        /// <returns>
        /// ICollection type of productions
        /// </returns>
        public ICollection<ProduccionUnica> listProductionUnique()
        {
            return productions;
        }

        /// <summary>
        /// This method is responsible for modifying the content of a variable
        /// </summary>
        /// <param name="v">
        /// Elemento type v
        /// </param>
        public void setVariable(Elemento v)
        {
            element = v;
        }
        /// <summary>
        /// This method is in charge of being used to convert to string to anyone who invokes it.
        /// </summary>
        /// <returns>
        /// string type aux
        /// </returns>
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

        /// <summary>
        /// This method is in charge of updating the elements of a unique production
        /// </summary>
        /// <param name="elementos">
        /// ICollection type elementos
        /// </param>
        /// <param name="pos">
        /// int type pos
        /// </param>

        public void updateElements(int pos, ICollection<Elemento> elementos)
        {
            productions.ElementAt(pos).elements = elementos;
        }
        /// <summary>
        /// This method is in charge of receiving a unique production and chage this production for another in a position selected
        /// </summary>
        /// <param name="fixedProduction">
        /// ICollection type fixedProduction
        /// </param>
        /// <param name="pos">
        /// int type pos
        /// </param>

        public void updateProduction(ICollection<ProduccionUnica> fixedProduction, int pos)
        {
            productions = fixedProduction;
        }
    }
}
