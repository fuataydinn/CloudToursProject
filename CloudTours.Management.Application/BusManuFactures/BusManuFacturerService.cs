using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.BusManuFactures
{
    public class BusManuFacturerService : IBusManuFactureService
    {
        private readonly IBusManuFacturerRepository _repository;

        public BusManuFacturerService(IBusManuFacturerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BusManuFacturerDTO> GetAll()
        {
            var busManuFacturers = _repository.GetAll();
            var busManuFacturesDTO = new List<BusManuFacturerDTO>();
            foreach (var busManuFacturer in busManuFacturers)
            {
                busManuFacturesDTO.Add(new BusManuFacturerDTO()
                {
                    BusManuFacturerId = busManuFacturer.BusManuFacturerId,
                    Name = busManuFacturer.Name
                });
            }
            return busManuFacturesDTO;
        }
        public BusManuFacturerDTO GetById(int id)
        {
            var bus = _repository.Find(id);
            var busManuFacturesDTO = new BusManuFacturerDTO()
            {
                BusManuFacturerId = bus.BusManuFacturerId,
                Name = bus.Name
            };
            return busManuFacturesDTO;

        }
        public void Create(BusManuFacturerDTO busManuFacturerDTO)
        {
            var busManuFacturer = new BusManuFacturer(busManuFacturerDTO.BusManuFacturerId, busManuFacturerDTO.Name);
            _repository.Create(busManuFacturer);
        }
        public void Update(BusManuFacturerDTO busManuFacturerDTO)
        {
            var busManuFacturer = new BusManuFacturer(busManuFacturerDTO.BusManuFacturerId, busManuFacturerDTO.Name);
            _repository.Update(busManuFacturer);
        }
        public void Delete(BusManuFacturerDTO busManuFacturerDTO)
        {
            Delete(busManuFacturerDTO.BusManuFacturerId);
        }

        public void Delete(int id)
        {
            var busManuFacturer2 = _repository.Find(id);
            if (busManuFacturer2 != null)
            {
                //var busManuFacturer = new BusManuFacturer(busManuFacturer2.BusManuFacturerId, busManuFacturer2.Name);
                _repository.Delete(busManuFacturer2);
            }
        }
    }
}

