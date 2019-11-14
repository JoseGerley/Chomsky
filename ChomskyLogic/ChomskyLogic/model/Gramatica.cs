﻿using System;
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


        public IProduccion GetProduccion(Elemento e)
        {
            IProduccion p = productions.Where(x => x.getPrincipalVariable().Equals(e)).First();
            return p;
        }
        
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

        public ICollection<Elemento> getTerminals()
        {
            return terminals;
        }

        public ICollection<Elemento> getVariables()
        {
            return variables;
        }


        public Elemento getTerminalSpecifies(char t)
        {
            Elemento aux;
            aux = terminals.Where(x => x.id == t).FirstOrDefault();
            return aux;
        }

        public Elemento getVariableSpecifies(char t)
        {
            Elemento aux;
            aux = variables.Where(x => x.id == t).FirstOrDefault();
            return aux;
        }

        public void deleteProduction(IProduccion prod)
        {
            productions.Remove(prod);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
