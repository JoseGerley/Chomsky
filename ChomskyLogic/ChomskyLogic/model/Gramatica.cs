using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

   ///<summary>
    ///The Grammar class is responsible for shaping the logic of what is one of these.
    ///Handles the content of a grammar: Variables, terminals, productions.
    ///</summary>
    public class Gramatica : ICloneable
    {
        private ICollection<Elemento> variables {  get; set; }
        private ICollection<Elemento> terminals {  get; set; }
        public ICollection<IProduccion> productions { get; }
        ///<summary>
        ///CONSTRUCTOR
        ///</summary>

        public Gramatica()
        {
            variables = new LinkedList<Elemento>();
            terminals = new LinkedList<Elemento>();
            productions = new LinkedList<IProduccion>();
        }
        /// <summary>
        /// This method is responsible for obtaining the first production of grammar
        /// </summary>
        /// <returns>
        /// IProduccion type of productions
        /// </returns>
        public IProduccion firstProduction()
        {
            return productions.ElementAt(0);
        }

        /// <summary>
        /// This method is responsible for obtaining a production of grammar
        /// </summary>
        /// <param name="e">
        /// Elemento type e
        /// </param>
        /// <returns>
        /// IProduccion type of productions
        /// </returns>
        public IProduccion GetProduccion(Elemento e)
        {
            IProduccion p = productions.Where(x => x.getPrincipalVariable().Equals(e)).First();
            return p;
        }
        /// <summary>
        /// This method is responsible for classifying the elements found in the 
        /// grammar, either terminals or variables
        /// </summary>
        /// <param name="variables">
        /// IList type variables
        /// </param>
        /// /// <param name="terminals">
        /// IList type terminals
        /// </param>

        public void determineElements(IList<char> variables, IList<char> terminals)
        {
            //ICollection<char> introduce = new LinkedList<char>();
            
            foreach(char c in variables){
                this.variables.Add(new Variable(c));
                
            }
            foreach(char c in terminals)
            {
                this.terminals.Add(new Terminal(c));
            }

        }

        /// <summary>
        /// This method is in charge of being used to convert to string to anyone who invokes it.
        /// </summary>
        /// <returns>
        /// string type aux
        /// </returns>
        public String toString()
        {
            String aux = "";
            foreach (IProduccion e in productions)
            {
                aux += e.toString();
                aux += " \n";
            }
            return aux;
        }
        /// <summary>
        /// This method is responsible for providing the terminals
        /// </summary>
        /// <returns>
        /// ICollection type terminals
        /// </returns>
        public ICollection<Elemento> getTerminals()
        {
            return terminals;
        }
        /// <summary>
        /// This method is responsible for providing the variables
        /// </summary>
        /// <returns>
        /// ICollection type variables
        /// </returns>
        public ICollection<Elemento> getVariables()
        {
            return variables;
        }

        /// <summary>
        /// This method is responsible for giving a specific terminal using a searched character.
        /// </summary>
        /// <param name="t">
        /// char type t
        /// </param>
        /// <returns>
        /// Elemento type aux
        /// </returns>
        public Elemento getTerminalSpecifies(char t)
        {
            Elemento aux;
            aux = terminals.Where(x => x.id == t).FirstOrDefault();
            return aux;
        }
        /// <summary>
        /// This method is responsible for giving a specific variable using a searched character.
        /// </summary>
        /// <param name="t">
        /// char type t
        /// </param>
        /// <returns>
        /// Elemento type aux
        /// </returns>
        public Elemento getVariableSpecifies(char t)
        {
            Elemento aux;
            aux = variables.Where(x => x.id == t).FirstOrDefault();
            return aux;
        }
        /// <summary>
        /// This method is responsible for eliminating a production according to the production entered by parameters
        /// </summary>
        /// <param name="prod">
        /// IProduccion type prod
        /// </param>

        public void deleteProduction(IProduccion prod)
        {
            productions.Remove(prod);
        }
        /// <summary>
        /// This method is responsible for cloning an item
        /// </summary>
        /// <returns>
        /// object type object
        /// </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
