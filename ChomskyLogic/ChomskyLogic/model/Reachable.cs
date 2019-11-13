using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    class Reachable : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;
        public Reachable(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            resultanting = g2;
            newGrammar = defineString(g2);
        }

        public string defineString(Gramatica g)
        {
            return this.description() + " \n" + g.toString();
        }

        public string description()
        {
            return "Delete non Reachable";
        }


        public string grammar()
        {
            return newGrammar;
        }

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

        public Gramatica resultantingGrammar()
        {
            return resultanting;
        }
    }
}
