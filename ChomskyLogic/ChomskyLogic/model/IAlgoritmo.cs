using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public interface IAlgoritmo
    {
        String grammar();
        void methodPrincipal(Gramatica g);
        String defineString(Gramatica g);
        String description();
    }
}
