using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class Anulable : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;

        public Anulable(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            resultanting = g2;
            newGrammar = defineString(g2);
        }


        public void methodPrincipal(Gramatica g)
        {
            ICollection<Elemento> anul = new LinkedList<Elemento>();
            findAnulables(g, anul);
            Console.WriteLine("--------------------------ANULABLE--------------------------");
            foreach (Elemento e in anul)
            {
                Console.WriteLine(e.id);
            }
        }

        private Elemento lamda(Gramatica g)
        {
            Elemento lamda = null;
            ICollection<Elemento> term = g.getTerminals();
            
            foreach(Elemento e in term)
            {
                if (e.special)
                {
                    lamda = e;
                }
            }
            return lamda;
        }

        private void findAnulables(Gramatica g, ICollection<Elemento> rea)
        {
           
            bool change;
            rea.Add(g.productions.ElementAt(0).getPrincipalVariable());
            Elemento lamda = this.lamda(g);
            if(lamda == null)
            {
                Console.WriteLine("No existe Lamda");
            }
            else
            {
                rea.Add(lamda);
                Console.WriteLine("existe Lamda :"+rea.ElementAt(0).id);
                do
                {
                    change = false;
                    addAnul(g, change, rea);
                }while (change);

            }

        }

        private void addAnul(Gramatica g, bool b, ICollection<Elemento> rea)
        {
            for (int i = 0; i < rea.Count(); i++)
            {
                IProduccion p = g.productions.ElementAt(i);
                bool isAnul = false;
                for (int j = 0; j < p.listProductionUnique().Count(); j++)
                {
                    bool uniqueLamda = true;
                    for (int f = 0; f < p.listProductionUnique().ElementAt(j).elements.Count(); f++)
                    {
                        
                        if (
                            !rea.Contains(p.listProductionUnique().ElementAt(j).elements.ElementAt(f))
                            )
                        {
                            
                            uniqueLamda = false;
                        }
                    }
                    if (uniqueLamda)
                    {
                        
                        isAnul = true;
                    }
                }
                if (isAnul)
                {
                    b = true;
                    rea.Add(g.productions.ElementAt(i).getPrincipalVariable());
                }
            }
        }


        public string defineString(Gramatica g)
        {
            return this.description() + " \n" + g.toString();
        }

        public string description()
        {
            return "Delete non Anulable";
        }

        public Gramatica resultantingGrammar()
        {
            return resultanting;
        }


        public string grammar()
        {
            return newGrammar;
        }
    }
}
