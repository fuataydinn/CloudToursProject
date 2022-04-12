using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.BusModels
{
    public interface IBusModelService 
    {
        IEnumerable<BusModelDTO> GetAllBusModel();
        IEnumerable<BusModelSummary> GetAllSummaries();
        BusModelDTO GetById(int id);
        BusModelSummary GetAllWithID(int id);
        void Create(BusModelDTO model);
        void Update(BusModelDTO model);
        void Delete(BusModelDTO model);
    }
}
