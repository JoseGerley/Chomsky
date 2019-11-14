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
            /*
            Console.WriteLine("--------------------------ANULABLE--------------------------");
            foreach (Elemento e in anul)
            {
                Console.WriteLine(e.id);
            }
            */
            applyAnul(g, anul);
        }

        private void applyAnul(Gramatica g, ICollection<Elemento> anul)
        {
            Elemento lamda = anul.ElementAt(0);
            anul.Remove(lamda);
            Elemento initial = this.initial(g);
            if (anul.Contains(initial))
            {
                ICollection<Elemento> lam = new LinkedList<Elemento>();
                lam.Add(lamda);
                g.firstProduction().addProductionUnique(lam);
            }

            foreach (Elemento anular in anul)
            {
                anularElemento(anular, g);
            }
            for (int i = 1; i < g.productions.Count; i++)
            {
                for (int j = 1; j < g.productions.ElementAt(i).listProductionUnique().Count(); j++)
                {
                    if (g.productions.ElementAt(i).listProductionUnique().ElementAt(j).elements.Contains(lamda))
                    {
                        g.productions.ElementAt(i).listProductionUnique().ElementAt(j).elements.Clear();
                    }
                
                }
            }
            foreach (IProduccion pro in g.productions)
            {
                deleteEmpty(pro);
            }
        }
           

        private void deleteEmpty(IProduccion pro)
        {
            ICollection<ProduccionUnica> li = new LinkedList<ProduccionUnica>();
            foreach(ProduccionUnica proU in pro.listProductionUnique())
            {
                if (proU.elements.Count() == 0)
                    li.Add(proU);
            }
            foreach (ProduccionUnica proU in li)
            {
                pro.deleteUniqueProductio(proU);
            }
        }

        private void anularElemento( Elemento a, Gramatica g)
        {

            for (int i = 0; i < g.productions.Count(); i++)
            {
                IProduccion p = g.productions.ElementAt(i);
                ICollection<ProduccionUnica> aux = new LinkedList<ProduccionUnica>();
                for (int j = 0; j < p.listProductionUnique().Count(); j++)
                {
                    for (int f = 0; f < p.listProductionUnique().ElementAt(j).elements.Count(); f++)
                    {
                        if (p.listProductionUnique().ElementAt(j).elements.ElementAt(f).Equals(a))
                        {
                            ProduccionUnica proU = new ProduccionUnica();
                            foreach (Elemento e in p.listProductionUnique().ElementAt(j).elements) {
                                proU.elements.Add(e);
                            }
                            proU.elements.Remove(a);
                            aux.Add(proU);
                        }
                    }
                }
                foreach(ProduccionUnica pu in aux)
                {
                    p.addProductionUnique(pu.elements);
                }

            }
            
            
        }

        private Elemento initial(Gramatica g)
        {
            Elemento lamda = null;
            ICollection<Elemento> term = g.getVariables();

            foreach (Elemento e in term)
            {
                if (e.special)
                {
                    lamda = e;
                }
            }
            return lamda;
        }

        private Elemento lamda(Gramatica g)
        {
            Elemento lamda = null;
            ICollection<Elemento> term = g.getTerminals();
            
            foreach (Elemento e in term)
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
            //rea.Add(g.productions.ElementAt(0).getPrincipalVariable());
            Elemento lamda = this.lamda(g);
            if(lamda == null)
            {
                //Console.WriteLine("No existe Lamda");
            }
            else
            {
                rea.Add(lamda);
                //Console.WriteLine("existe Lamda :"+rea.ElementAt(0).id);
                do
                {

                    change = addAnul(g, rea);
                }while (change);

            }

        }

        private bool addAnul(Gramatica g, ICollection<Elemento> rea)
        {
            bool change = false;
            for (int i = 0; i < g.productions.Count(); i++)
            {
                IProduccion p = g.productions.ElementAt(i);
                bool isAnul = false;
                if (rea.Contains(p.getPrincipalVariable()))
                {

                }
                else
                {
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

                }
                if (isAnul)
                {
                    change = true;
                    rea.Add(g.productions.ElementAt(i).getPrincipalVariable());
                }
            }
            return change;
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
