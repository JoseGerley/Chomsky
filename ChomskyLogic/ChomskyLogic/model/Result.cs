using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class Result : IAlgoritmo
    {
        public String newGrammar;
        public Gramatica resultanting;

        public Result(Gramatica g)
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
            return "Browse Units";
        }

        public Gramatica resultantingGrammar()
        {
            return resultanting;
        }


        public string grammar()
        {
            return newGrammar;
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

        public void methodPrincipal(Gramatica g)
        {
            char min = 'U';
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
                    dicTerms.Add(e, termvars);
                }
            }
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
