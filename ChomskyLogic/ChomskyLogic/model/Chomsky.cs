using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public class Chomsky
    {
        public Gramatica grammar;
        public String actualGrammar;
        public String nextGrammar { get; private set; }
        
        public Chomsky(String s)
        {
            grammar = new Gramatica();
            InstanceGrammar(s);
            actualGrammar = "G: \n"+grammar.toString();
            nextGrammar = "G': \n";

        }

        private IList<char> convertStringToVariables(String s)
        {
            IList<char> listVar = new List<char>();
            List<string> listString = s.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < listString.Count(); i++)
            {
                //Console.WriteLine(listString.ElementAt(i).ElementAt(0));
                char c = listString.ElementAt(i).ElementAt(0);
                listVar.Add(c);
                //Console.Write(" add");
            }

            return listVar;
        }

        private IList<char> convertStringToTerminals(String s, IList<char> var)
        {
            IList<char> listVar = new List<char>();

            List<string> listString = s.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < listString.Count(); i++)
            {
                //Console.WriteLine("line: "+listString.ElementAt(i));
                String[] pre_post = listString.ElementAt(i).Split('>');
                //Console.WriteLine("post >: " + pre_post[1]);
                String[] post_A = pre_post[1].Split('_');
                //Console.WriteLine("post_A: " + post_A[0]);
                String post = arrayToString(post_A);
                //Console.WriteLine("post: "+post);
                for (int j = 0; j < post.Length; j++)
                {
                    //Console.WriteLine(post.ElementAt(j));
                    if (!listVar.Contains(post.ElementAt(j)) && !var.Contains(post.ElementAt(j)) )  {
                        listVar.Add(post.ElementAt(j));
                        //Console.Write(" add \n");
                    }
                }
            }
            return listVar;
        }

        private String arrayToString(String[] s)
        {
            String aux = "";
            for(int i = 0; i < s.Length; i++)
            {
                aux += s[i];
                //Console.WriteLine("post_A for: " + s[i] +"y aux :"+aux);
            }
            return aux;
        }

        private void addTotalProduction(String s)
        {
            List<string> listString = s.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach(String letra in listString)
            {
                addProduction(letra);
            }

        }

        private void addProduction(String s)
        {
            String[] pre_post = s.Split('>');
            //Console.WriteLine("-----------Production: "+Char.Parse(pre_post[0]));
            Elemento elmt = browseElement(Char.Parse(pre_post[0]));
            IProduccion p = new Produccion(elmt);
            String[] post = pre_post[1].Split('_');
            for(int i = 0; i < post.Length; i++)
            {
                ICollection<Elemento> e = new LinkedList<Elemento>();
                for(int j = 0; j < post[i].Length; j++)
                {
                    e.Add(browseElement(post[i].ElementAt(j)));
                }
                p.addProductionUnique(e);
            }
            
            grammar.productions.Add(p);

        }

        public Elemento browseElement(char v)
        {
            Elemento e = null;
            e = grammar.getVariableSpecifies(v);
            if(e == null)
            {
                //Console.WriteLine("Is terminal Char: "+v);
                e = grammar.getTerminalSpecifies(v);
            }
            /*
            else
            {
                Console.WriteLine("Is Variable Char: " + v);
            }
            */
            return e;
        }

        private String variablesGrammar()
        {
            //Console.WriteLine("In Variables");
            ICollection<Elemento> e = grammar.getVariables();
            String aux = "";
            for(int i = 0; i < e.Count(); i++)
            {
                //Console.WriteLine("time: " + i + " char: " + e.ElementAt(i).id + " isSpecial: " + e.ElementAt(i).special);
                aux += e.ElementAt(i).id;
            }
            return aux;
        }
        private String termianlesGrammar()
        {
            //Console.WriteLine("In Terminales");
            ICollection<Elemento> e = grammar.getTerminals();
            String aux = "";
            for (int i = 0; i < e.Count(); i++)
            {
                //Console.WriteLine("time: " + i + " char: " + e.ElementAt(i).id+" isSpecial: "+ e.ElementAt(i).special);
                aux += e.ElementAt(i).id;
            }
            return aux;
        }

        private String listToString(IList<char> v)
        {
            String aux = "";
            for (int i = 0; i < v.Count; i++)
            {
                aux += v.ElementAt(i);
            }

            return aux;
        }

        private void InstanceGrammar(String s)
        {
            IList<char> variables = convertStringToVariables(s);
            IList<char> terminals = convertStringToTerminals(s, variables);
            grammar.determineElements(variables, terminals);
            /*
            Console.WriteLine("------------------PRUEBAS----------------------");
            Console.WriteLine(listToString(variables));
            Console.WriteLine(listToString(terminals));
            variablesGrammar();
            termianlesGrammar();
            */

            addTotalProduction(s);
        }

        
    }
}
