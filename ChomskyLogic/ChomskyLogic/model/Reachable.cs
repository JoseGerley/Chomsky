using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    ///<summary>
    ///The Reachable class is responsible for identifying and treating the rules of the 
    ///the Reachable and their special cases.
    ///</summary>

    class Reachable : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
        public Reachable(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            resultanting = g2;
            newGrammar = defineString(g2);
        }
        /// <summary>
        /// This method is responsible for exposing the reachables and a string with its description
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
            return "Delete non Reachable";
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
            ICollection<Elemento> rea = findReachables(g);
            /*
            Console.WriteLine("-------------------------ALCANZABLES--------------");
            foreach(Elemento e in rea)
            {
                Console.WriteLine(e.id);
            }
            */
            deleteNonReacheble(rea, g);
        }
        /// <summary>
        /// This method is responsible for eliminating a non reachable according to the grammar entered by parameters
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="rea">
        /// ICollection type rea
        /// </param>
        private void deleteNonReacheble(ICollection<Elemento> rea, Gramatica g)
        {
            IList<int> pos = new List<int>();
            for (int i = 0; i < g.productions.Count(); i++)
            {
                if (!rea.Contains(g.productions.ElementAt(i).getPrincipalVariable()))
                {
                    pos.Add(i);
                }
            }
            for (int i = 0; i < pos.Count(); i++)
            {
                g.deleteProduction(g.productions.ElementAt(pos.ElementAt(i)));
            }
        }
        /// <summary>
        /// This method is responsible for finding the reachables according to the grammar entered by parameters
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <returns>
        /// ICollection type rea
        /// </returns>
   
        private ICollection<Elemento> findReachables(Gramatica g)
        {
            ICollection<Elemento> rea = new LinkedList<Elemento>();
            bool change;
            rea.Add(g.productions.ElementAt(0).getPrincipalVariable());

            do
            {
                change = false;
                addReachables(g, change, rea);
            } while (change);

            return rea;
        }
        /// <summary>
        /// This method is responsible for adding the reachables according to the grammar entered by parameters
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="b">
        /// bool type b
        /// </param>
        /// <param name="rea">
        /// ICollection type rea
        /// </param>

        private void addReachables(Gramatica g, bool b, ICollection<Elemento> rea)
        {
            for(int i = 0; i < rea.Count(); i++)
            {
                IProduccion p = g.GetProduccion(rea.ElementAt(i));
                for(int j = 0; j < p.listProductionUnique().Count(); j++)
                {
                    for(int f = 0;  f < p.listProductionUnique().ElementAt(j).elements.Count(); f++)
                    {
                        if (g.getVariables().Contains(p.listProductionUnique().ElementAt(j).elements.ElementAt(f))
                            && !rea.Contains(p.listProductionUnique().ElementAt(j).elements.ElementAt(f))
                            )
                        {
                            b = true;
                            rea.Add(p.listProductionUnique().ElementAt(j).elements.ElementAt(f));
                        }
                    }
                }
            }
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
    }
}
