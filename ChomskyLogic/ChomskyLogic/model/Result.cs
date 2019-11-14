using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///The result class is responsible for taking charge of the last step in which binary character 
    ///productions will be taken into account
    ///</summary>
    public class Result : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;

        ///<summary>
        ///CONSTRUCTOR
        ///</summary>

        public Result(Gramatica g)
        {
            Gramatica g2 = (Gramatica)g.Clone();
            methodPrincipal(g2);
            resultanting = g2;
            newGrammar = defineString(g2);
        }

        /// <summary>
        /// This method is responsible for exposing the results and a string with its description
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
        /// This method is responsible for performing the step corresponding to the unit step.
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        public void methodPrincipal(Gramatica g)
        {
            char min = 'T';
            IProduccion termvars;
            IDictionary<Elemento,IProduccion > dicTerms= new Dictionary<Elemento, IProduccion>();
            IDictionary<Elemento[], IProduccion> dicVar = new Dictionary<Elemento[], IProduccion>();
            Elemento lamda = this.lamda(g);
            foreach ( Elemento a in g.getTerminals())
            {
                if (!a.Equals(lamda))
                {
                    Elemento e = new Variable(min);
                    min++;
                    g.addElementVariable(e);
                    termvars = new Produccion(e);
                    ICollection<Elemento> ter = new LinkedList<Elemento>();
                    ter.Add(a);
                    termvars.addProductionUnique(ter);
                    g.addProduction(termvars);
                    dicTerms.Add(a, termvars);
                }
            }
            /**
             for(int i = 0; i < dicTerms.Count(); i++)
            {
                Console.WriteLine("key: " + dicTerms.Keys.ElementAt(i).id + " pro: " + dicTerms.Values.ElementAt(i).getPrincipalVariable().id);
            }

            foreach(Elemento e in g.getTerminals())
            {
                Console.WriteLine("Terminal: " + e.id);
            }
            */
            for (int i = 0; i < g.productions.Count; i++)
            {
                IProduccion prod = g.productions.ElementAt(i);
                for (int j = 0; j < prod.listProductionUnique().Count; j++)
                {
                    ProduccionUnica body = prod.listProductionUnique().ElementAt(j);
                    foreach (Elemento a in g.getTerminals())
                    {
                        if (!a.Equals(lamda) &&
                            body.elements.Contains(a))
                        {
                            Console.WriteLine("Not found: "+a.id);
                            body.elements.Remove(a);
                            body.elements.Add(dicTerms[a].getPrincipalVariable());
                        }
                    }
                    /**
                    for (int k = 0; k < body.elements.Count() - 1; k++)
                    {
                        if (!binaryvars.ContainsKey(body[k].ToString() + body[k + 1].ToString()) && body.Length > 2)
                        {
                            binaryvars.Add(body[k].ToString() + body[k + 1].ToString(), (char)(Variables.Last() + 1));
                            Variables.Add((char)(Variables.Last() + 1));
                            Productions.Add(new Production(Variables.Last(), body[k].ToString() + body[k + 1].ToString()));
                        }
                        if (body.Length > 2)
                        {
                            body = body.Replace(body[k].ToString() + body[k + 1].ToString(), binaryvars[body[k].ToString() + body[k + 1].ToString()] + "");
                            k--;
                        }
                        prod.Body[j] = body;
                    }
    */
                }
            }
        }

        /// <summary>
        /// This method is responsible for returning a new string in which all occurrences of a specified Unicode character with unique productions
        /// </summary>
        /// <param name="g">
        /// Gramatica type g
        /// </param>
        /// <param name="body">
        /// ProduccionUnica type body
        /// </param>
        /// <param name="a">
        /// Elemento type a
        /// </param>
        /// <returns>
        /// ProduccionUnica type of a
        /// </returns>
        private ProduccionUnica Replace(ProduccionUnica body, Elemento a, Gramatica g)
        {
            ProduccionUnica aux = new ProduccionUnica();
            foreach (Elemento e in body.elements)
            {
                aux.elements.Add(e);
            }
            if (aux.elements.Contains(a))
            {
                aux.elements.Remove(a);
                aux.elements.Add(browseProductionVariable(g, a));
            }
            return aux;
        }

        private Elemento browseProductionVariable(Gramatica g, Elemento a)
        {
            
            foreach (IProduccion p in g.productions)
            {
                if(p.listProductionUnique().Count() == 1 &&
                    p.listProductionUnique().ElementAt(0).elements.Count() == 1 &&
                    p.listProductionUnique().ElementAt(0).elements.ElementAt(0).Equals(a))
                {
                    return p.getPrincipalVariable();
                }
            }
            return a;

        }
    }
}
