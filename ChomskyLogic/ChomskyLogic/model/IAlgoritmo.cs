using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{

    ///<summary>
    ///This interface is responsible for owning the algorithms that will 
    ///depend on its use according to the grammar entered
    ///</summary>
    public interface IAlgoritmo
    {


        String grammar();
        void methodPrincipal(Gramatica g);
        String defineString(Gramatica g);
        String description();
        Gramatica resultantingGrammar();
    }
}
