using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///The Units class is responsible for identifying and treating
    ///the units and their special cases.
    ///</summary>
    public class Units : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
        public Units(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            resultanting = g2;
            newGrammar = defineString(g2);
        }

        /// <summary>
        /// This method is responsible for exposing the units string with its description
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <returns>
        /// string type description
        /// </returns>
        public string defineString(Gramatica g)
        {
            return this.description() + " \n" + g.toString();
        }

        /// <summary>
        /// This method is responsible for exposing the description message
        /// </summary>
        /// <returns>
        /// string type description message
        /// </returns>
        public string description()
        {
            return "Browse Units";
        }
        /// <summary>
        /// This method is responsible for bringing the resultanting grammar
        /// </summary>
        /// <returns>
        /// Gramatica type resultanting
        /// </returns>
        public Gramatica resultantingGrammar()
        {
            return resultanting;
        }
        /// <summary>
        /// This method is responsible for creating a new grammar
        /// </summary>
        /// <returns>
        /// string type newGrammar
        /// </returns>
        public string grammar()
        {
            return newGrammar;
        }

        /// <summary>
        /// This method is responsible for performing the step corresponding to the unit step.
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>

        public void methodPrincipal(Gramatica g)
        {
            int max = 0;
            ICollection<LinkedList<Elemento>> unitPerPro = new LinkedList<LinkedList<Elemento>>();
           for(int i = 0; i < g.productions.Count(); i++)
            {
                LinkedList<Elemento> units = new LinkedList<Elemento>();
                getUnitsOfProduction(units, g.productions.ElementAt(i), g);
                unitPerPro.Add(units);
                if (units.Count() > max)
                    max = units.Count();
            }

           while(max > 0)
            {
                for (int i = 0; i < g.productions.Count(); i++)
                {
                    ICollection<Elemento> units = unitPerPro.ElementAt(i);
                    addOtherUnit(units, g.productions.ElementAt(i), g);
                }
                max--;
            }
        }
        /// <summary>
        /// This method is responsible for adding a new unit to the grammar to convert
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="produccion">
        /// IProduccion type produccion
        /// </param>
        /// <param name="units">
        /// ICollection type units
        /// </param>
        private void addOtherUnit(ICollection<Elemento> units, IProduccion produccion, Gramatica g)
        {
            foreach(Elemento u in units)
            {
                foreach (ProduccionUnica pro in g.GetProduccion(u).listProductionUnique())
                {
                    if(!produccion.listProductionUnique().Contains(pro))
                        produccion.addProductionUnique(pro.elements);
                }
            }
        }
        /// <summary>
        /// This method is responsible for eliminating empty unit productions.
        /// </summary>
        /// <param name="pro">
        /// IProduccion type produccion
        /// </param>
        private void deleteEmpty(IProduccion pro)
        {
            ICollection<ProduccionUnica> li = new LinkedList<ProduccionUnica>();
            foreach (ProduccionUnica proU in pro.listProductionUnique())
            {
                if (proU.elements.Count() == 0)
                    li.Add(proU);
            }
            foreach (ProduccionUnica proU in li)
            {
                pro.deleteUniqueProductio(proU);
            }
        }

        /// <summary>
        /// This method is responsible for providing the units of the productions
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="produccion">
        /// IProduccion type produccion
        /// </param>
        /// <param name="units">
        /// ICollection type units
        /// </param>
        private void getUnitsOfProduction(ICollection<Elemento> units, IProduccion produccion,Gramatica g)
        {
           

            foreach (ProduccionUnica pro in produccion.listProductionUnique())
            {
                if (pro.elements.Count() == 1 &&
                    g.getVariables().Contains(pro.elements.ElementAt(0))
                    )
                {
                    //Console.WriteLine(pro.elements.ElementAt(0).id+" add in "+produccion.getPrincipalVariable().id);
                    units.Add(pro.elements.ElementAt(0));
                    pro.elements.Clear();
                }

            }
            deleteEmpty(produccion);
        }
    }
}
