using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Cities
{
    public interface ICityService
    {
        IEnumerable<CityDTO> GetAll();
        CityDTO GetById(int id);
        void Create(CityDTO cityDTO);
        void Update(CityDTO cityDTO);
        void Delete(CityDTO cityDTO);
    }
}
