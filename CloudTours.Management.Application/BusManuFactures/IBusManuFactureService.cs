using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.BusManuFactures
{
    public interface IBusManuFactureService
    {
        IEnumerable<BusManuFacturerDTO> GetAll();
        BusManuFacturerDTO GetById(int id);
        void Update(BusManuFacturerDTO busManuFacturerDTO);
        void Create(BusManuFacturerDTO busManuFacturerDTO); 
        void Delete(BusManuFacturerDTO busManuFacturerDTO);
        void Delete(int id);



    }
}
