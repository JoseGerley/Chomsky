using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    ///<summary>
    ///The Anulable class is responsible for identifying and treating the rules of the 
    ///the Anulable and their special cases.
    ///</summary>
    public class Anulable : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>
        public Anulable(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            resultanting = g2;
            newGrammar = defineString(g2);
        }

        /// <summary>
        /// This method is responsible for performing the step corresponding to the unit step.
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
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
        /// <summary>
        /// This method is responsible for applying the rule to identify voidable variables.
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="anul">
        /// ICollection type anul
        /// </param>
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

        /// <summary>
        /// This method is responsible for eliminating the bodies of productions that contain voidable according to the production read.
        /// </summary>
        /// <param name="pro">
        /// IProduccion type pro
        /// </param>

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
        /// <summary>
        /// This method is responsible for identifying an element that contains voidable according to the grammar.
        /// </summary>
        /// <param name="a">
        /// Elemento type a
        /// </param>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
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
        /// <summary>
        /// This method is responsible for recognizing the first element containing lambda checking variables according to the grammar
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <returns>
        /// Elemento type lambda
        /// </returns>
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
        /// <summary>
        /// This method is responsible for recognizing the first element containing lambda checking terminals according to the grammar
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <returns>
        /// Elemento type lambda
        /// </returns>
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
        /// <summary>
        /// This method is responsible for finding the nullable elements according to the grammar introduced
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="rea">
        /// ICollection type rea
        /// </param>
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
        /// <summary>
        /// This method is responsible for verifying the addition of a voidable element according to the grammar introduced
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="rea">
        /// ICollection type g
        /// </param>
        /// <returns>
        /// bool type change
        /// </returns>
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

        /// <summary>
        /// This method is responsible for exposing the anulables and a string with its description
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
            return "Delete non Anulable";
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

        ///<summary>
        ///This method is responsible for creating a new grammar
        ///<returns>
        ///string type of newGrammar
        /// </returns>
        ///</summary>
        public string grammar()
        {
            return newGrammar;
        }
    }
}
