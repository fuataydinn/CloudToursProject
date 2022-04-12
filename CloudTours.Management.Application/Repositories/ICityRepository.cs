using CloudTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        City Find(int id);
        void Add(City city);
        void Update(City city);
        void Remove(City city);
            
    }
}
