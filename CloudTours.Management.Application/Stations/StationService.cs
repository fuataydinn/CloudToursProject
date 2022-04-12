using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Stations
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public IEnumerable<StationDTO> GetAllStation()
        {
            var stations = _stationRepository.GetAll();
            var stationsDTOs=new List<StationDTO>();
            foreach (var entity in stations)
            {
                stationsDTOs.Add(new StationDTO()
                {
                    CityId = entity.CityId,
                    StationId = entity.StationId,
                    StationName=entity.StationName      
                });                
            }
            return stationsDTOs;
        }
        public IEnumerable<StationSummary> GetSummaries()
        {
            var station = _stationRepository.GetAll(true);

            var stationSummary=new List<StationSummary>();

            foreach (var item in station)
            {
                stationSummary.Add(new StationSummary() 
                {
                StationId = item.StationId,
                StationName = item.StationName,
                CityName=item.City.CityName
                });
            }
            return stationSummary;
        }
        public StationDTO GetById(int id)
        {
            var entity = _stationRepository.Find(id);
            if (entity!=null)
            {
                var stationDTO = new StationDTO()
                {
                    CityId = entity.CityId,
                    StationId = entity.StationId,
                    StationName = entity.StationName
                };
                return stationDTO;
            }
            else
            {
                return null;
            }
        }
        public void Create(StationDTO stationDTO)
        {
            var station = new Station()
            {    
                StationName= stationDTO.StationName,
                CityId= stationDTO.CityId

            };
            _stationRepository.Add(station);
        }
        public void Delete(StationDTO stationDTO)
        {
            if (stationDTO!=null)
            {
                var station = new Station()
                {
                  StationId= stationDTO.StationId

                };
                _stationRepository.Remove(station);
            }
        }

        public void Update(StationDTO stationDTO)
        {
            if (stationDTO!=null)
            {
                var station = new Station()
                {
                    StationName = stationDTO.StationName,
                    CityId = stationDTO.CityId,
                    StationId= stationDTO.StationId   
                   

                };
                _stationRepository.Update(station);
            }
        }

    }
}
