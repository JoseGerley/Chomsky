using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    ///<summary>
    ///The Terminables class is responsible for identifying and treating
    ///the terminables and their special cases.
    ///</summary>
    public class Terminable : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;

        public Terminable(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            resultanting = g2;
            newGrammar = defineString(g2);
        }
        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
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
            ICollection<Elemento> first = findFirstTerm(g);
            
            /*
            Console.WriteLine("---------------------TERMINABLES INICIO-------------------------");
            foreach (Elemento e in first)
            {
                Console.WriteLine(e.id);
            }
            */
            ICollection<Elemento> allTerm = this.allTerm(g, first);
            
            /*
            Console.WriteLine("---------------------TERMINABLES-------------------------");
            foreach (Elemento e in allTerm)
            {
                Console.WriteLine(e.id);
            }
            */
            deleteProductionNoTerminal(g,allTerm);
            deleteUniqueProduction(g,this.varAndTerm(g,allTerm));
            
        }

        /// <summary>
        /// This method is responsible for performing the step corresponding to the unit step.
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="var">
        /// ICollection type var
        /// </param>
        /// <returns>
        /// ICollection type terms
        /// </returns>
        private ICollection<Elemento> varAndTerm(Gramatica g, ICollection<Elemento> var) {
            ICollection<Elemento> terms = this.cloneCollEl(g.getTerminals());

            foreach (Elemento e in var)
            {
                terms.Add(e);
            }

            return terms;
        }
        /// <summary>
        /// This method is responsible for eliminating a unique production according to the grammar entered by parameters
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="allTerm">
        /// ICollection type allTerm
        /// </param>
        private void deleteUniqueProduction(Gramatica g, ICollection<Elemento> allTerm)
        {
            ICollection<IProduccion> prod = g.productions;

            for (int j = 0; j < prod.Count(); j++)
            {
                ICollection<ProduccionUnica> up = prod.ElementAt(j).listProductionUnique();
                IList<int> pos = new List<int>();
                for (int z = 0; z < up.Count(); z++)
                {
                    bool on = false;
                    
                    for (int i = 0; i < up.ElementAt(z).elements.Count(); i++)
                    {
                        if (!allTerm.Contains(up.ElementAt(z).elements.ElementAt(i)))
                        {
                            on = true;
                        }
                    }
                    if (on)
                    {
                        pos.Add(z);
                    }
                }

                for (int i = 0; i < pos.Count(); i++)
                {
                    prod.ElementAt(j).deleteUniqueProductio(up.ElementAt(pos.ElementAt(i)));
                }
            }
        }

        /// <summary>
        /// This method is responsible for eliminating a unique no terminal production according to the grammar entered by parameters
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="allTerm">
        /// ICollection type allTerm
        /// </param>

        private void deleteProductionNoTerminal(Gramatica g, ICollection<Elemento> allTerm)
        {
            ICollection<IProduccion> prod = g.productions;
            IList<int> pos = new List<int>();
            for(int i = 0; i<prod.Count(); i++)
            {
                if (!allTerm.Contains(prod.ElementAt(i).getPrincipalVariable()) )
                {
                    pos.Add(i);
                }
            }
            for (int i = 0; i < pos.Count(); i++)
            {
                g.deleteProduction(prod.ElementAt(pos.ElementAt(i)));
            }
        }


        /// <summary>
        /// This method is responsible for verifying all the terms belonging to the bodies of the productions
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="first">
        /// ICollection type first
        /// </param>
        /// <returns>
        /// ICollection type allTerm
        /// </returns>
        private ICollection<Elemento> allTerm(Gramatica g, ICollection<Elemento> first)
        {
            ICollection<Elemento> allTerm = first;
            ICollection<Elemento> terms = this.cloneCollEl(g.getTerminals());

            foreach (Elemento e in first)
            {
                terms.Add(e);
            }

            bool change = false;
            do
            {
                change = false;
                for (int i = 0; i < g.productions.Count(); i++)
                {
                    bool on = false;
                    for (int j = 0; j < g.productions.ElementAt(i).listProductionUnique().Count(); j++)
                    {
                        bool all = true;
                        for (int z = 0; z < g.productions.ElementAt(i).listProductionUnique().ElementAt(j).elements.Count(); z++)
                        {
                            Elemento a = g.productions.ElementAt(i).listProductionUnique().ElementAt(j).elements.ElementAt(z);
                            if (!terms.Contains(a))
                            {
                                all = false;
                            }
                        }
                        if (all)
                        {
                            on = true;
                        }
                    }
                    if (on && !allTerm.Contains(g.productions.ElementAt(i).getPrincipalVariable()))
                    {
                        change = true;
                        allTerm.Add(g.productions.ElementAt(i).getPrincipalVariable());
                        terms.Add(g.productions.ElementAt(i).getPrincipalVariable());
                    }
                }


            } while (change);

            return allTerm;
        }

        /// <summary>
        /// This method is responsible for cloning an element.
        /// </summary>
        /// <param name="t">
        /// ICollection type t
        /// </param>
        /// <returns>
        /// ICollection type terms
        /// </returns>
        private ICollection<Elemento> cloneCollEl(ICollection<Elemento> t)
        {
            ICollection<Elemento> terms = new LinkedList<Elemento>();
            foreach(Elemento e in t)
            {
                terms.Add(e);
            }
            return terms;
        }

        /// <summary>
        /// This method is responsible for finding the first term belonging to the grammar entered by parameters
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <returns>
        /// ICollection type first
        /// </returns>
        private ICollection<Elemento> findFirstTerm(Gramatica g)
        {
            ICollection<Elemento> first = new LinkedList<Elemento>();
            ICollection<Elemento> terms = this.cloneCollEl(g.getTerminals());
            for (int i=0; i < g.productions.Count(); i++)
            {
                bool on = false;
                for (int j = 0; j < g.productions.ElementAt(i).listProductionUnique().Count(); j++)
                {
                    bool all = true;
                    for(int z = 0; z < g.productions.ElementAt(i).listProductionUnique().ElementAt(j).elements.Count(); z++)
                    {
                        Elemento a = g.productions.ElementAt(i).listProductionUnique().ElementAt(j).elements.ElementAt(z);
                        if (!terms.Contains(a))
                        {
                            all = false;
                        }
                    }
                    if (all)
                    {
                        on = true;
                    }
                }
                if (on)
                {
                    first.Add(g.productions.ElementAt(i).getPrincipalVariable());
                    terms.Add(g.productions.ElementAt(i).getPrincipalVariable());
                }
            }
            return first;
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
            return this.description()+" \n"+g.toString();
        }

        /// <summary>
        /// This method is responsible for exposing the description message
        /// </summary>
        /// <returns>
        /// string type description message
        /// </returns>
        public string description()
        {
            return "Delete non Terminables";
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
