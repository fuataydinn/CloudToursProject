using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Cities
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<CityDTO> GetAll()
        {
            var cityEntities = _cityRepository.GetAll();
            var cityDTOs = new List<CityDTO>();
            foreach (var entity in cityEntities)
            {
                cityDTOs.Add(new CityDTO
                {
                    CityId = entity.CityId,
                    CityName = entity.CityName
                });
            }
            return cityDTOs;
        }
        public CityDTO GetById(int id)
        {
            var cityEntity = _cityRepository.Find(id);
            if (cityEntity != null)
            {
                var cityDTO = new CityDTO()
                {
                    CityId = cityEntity.CityId,
                    CityName = cityEntity.CityName
                };
                return cityDTO;
            }
            else
            {
                return null;
            }

        }
        public void Create(CityDTO cityDTO)
        {
            var city = new City()
            {
                CityName = cityDTO.CityName
            };
            _cityRepository.Add(city);
        }
        public void Delete(CityDTO cityDTO)
        {
            if (cityDTO != null)
            {
                var city = new City()
                {
                    CityId = cityDTO.CityId,
                    CityName = cityDTO.CityName
                };
                _cityRepository.Remove(city);
            }
        }
        public void Update(CityDTO cityDTO)
        {
            //var city = _cityRepository.Find(cityDTO.CityId);
            //city.CityName = cityDTO.CityName;

            var city = new City()
            {
                CityId = cityDTO.CityId,
                CityName = cityDTO.CityName
            };
            _cityRepository.Update(city);
        }

    }
}
