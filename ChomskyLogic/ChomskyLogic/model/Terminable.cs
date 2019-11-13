using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class Terminable : IAlgoritmo
    {
        public String newGrammar;

        public Terminable(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            newGrammar = defineString(g2);
        }

        public string grammar()
        {
            return newGrammar;
        }

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

        private ICollection<Elemento> varAndTerm(Gramatica g, ICollection<Elemento> var) {
            ICollection<Elemento> terms = g.getTerminals();

            foreach (Elemento e in var)
            {
                terms.Add(e);
            }

            return terms;
        }

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

        private void deleteProductionNoTerminal(Gramatica g, ICollection<Elemento> allTerm)
        {
            ICollection<IProduccion> prod = g.productions;
            foreach (IProduccion p in prod)
            {
                if (!allTerm.Contains(p.getPrincipalVariable()) )
                {
                    g.deleteProduction(p);
                }
            }
        }

        private ICollection<Elemento> allTerm(Gramatica g, ICollection<Elemento> first)
        {
            ICollection<Elemento> allTerm = first;
            ICollection<Elemento> terms = g.getTerminals();

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

        private ICollection<Elemento> findFirstTerm(Gramatica g)
        {
            ICollection<Elemento> first = new LinkedList<Elemento>();
            ICollection<Elemento> terms = g.getTerminals();
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

        public string defineString(Gramatica g)
        {
            return this.description()+" \n"+g.toString();
        }

        public string description()
        {
            return "Delete non Terminables";
        }
    }
}
