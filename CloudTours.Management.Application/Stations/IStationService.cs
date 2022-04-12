using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Stations
{
    public interface IStationService
    {
        IEnumerable<StationDTO> GetAllStation();
        IEnumerable<StationSummary> GetSummaries();
        StationDTO GetById(int id);
        void Create (StationDTO dto);
        void Update (StationDTO dto);
        void Delete (StationDTO dto);
    }
}
