using CloudTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Repositories
{
    public interface IBusModelRepository
    {
        IEnumerable<BusModel> GetAll(bool includeBusManuFac = false);
        BusModel Find(int id, bool includeBusManuFac = false);
        void Add(BusModel model);
        void Update(BusModel model);
        void Remove(BusModel model);
    }
}
