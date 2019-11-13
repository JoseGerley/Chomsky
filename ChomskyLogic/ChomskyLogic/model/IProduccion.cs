using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChomskyLogic.model
{
    public interface IProduccion
    {
        void setVariable(Elemento v);
        ProduccionUnica getProduction(int pos);
        void addProductionUnique(ICollection<Elemento> elements);
        Elemento getPrincipalVariable();
        ICollection<ProduccionUnica> listProductionUnique();
        void updateProduction(ICollection<ProduccionUnica> fixedProduction, int pos);
        void updateElements(int pos, ICollection<Elemento> elementos);
        String toString();
        void deleteUniqueProductio(ProduccionUnica p);
    }
}
