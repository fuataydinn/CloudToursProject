using CloudTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Repositories
{
    public interface IStationRepository
    {
        IEnumerable<Station> GetAll(bool includeCity=false);
        Station Find(int id,bool includeCity=false);
        void Add(Station station);
        void Update(Station station);
        void Remove(Station station);
    }
}
