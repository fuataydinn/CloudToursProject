using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.BusModels
{
    public class BusModelService : IBusModelService
    {
        private readonly IBusModelRepository _repository;

        public BusModelService(IBusModelRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BusModelDTO> GetAllBusModel()
        {
            var busModels = _repository.GetAll();
            var busModelDTOs = new List<BusModelDTO>();
            foreach (var busEntity in busModels)
            {
                busModelDTOs.Add(new BusModelDTO()
                {
                    BusModelId = busEntity.BusModelId,
                    BusModelName = busEntity.BusModelName,
                    HasToilet = busEntity.HasToilet,
                    SeatCapacity = busEntity.SeatCapacity,
                    Type = busEntity.Type,
                    BusManuFacturerId = busEntity.BusManuFacturerId
                });
            }
            return busModelDTOs;
        }

        public IEnumerable<BusModelSummary> GetAllSummaries()
        {
            var busModels = _repository.GetAll(true);
            var busSummary = new List<BusModelSummary>();
            foreach (var busEntity in busModels)
            {
                busSummary.Add(new BusModelSummary()
                {
                    BusModelId = busEntity.BusModelId,
                    BusModelName = busEntity.BusModelName,
                    HasToilet = busEntity.HasToilet,
                    SeatCapacity = busEntity.SeatCapacity,
                    Type = busEntity.Type,
                    BusManuFacturerName = busEntity.BusManuFacturer.Name
                });
            }
            return busSummary;
        }
        public BusModelDTO GetById(int id)
        {
            var busModel = _repository.Find(id);
            var busModelDTO = new BusModelDTO()
            {
                BusModelId = busModel.BusModelId,
                BusModelName = busModel.BusModelName,
                HasToilet = busModel.HasToilet,
                SeatCapacity = busModel.SeatCapacity,
                Type = busModel.Type,
                BusManuFacturerId = busModel.BusManuFacturerId
            };
            return busModelDTO;
        }

        public BusModelSummary GetAllWithID(int id)
        {
            var busModel = _repository.Find(id, true);
            var busModelSummary = new BusModelSummary()
            {
                BusModelId = busModel.BusModelId,
                BusModelName = busModel.BusModelName,
                HasToilet = busModel.HasToilet,
                SeatCapacity = busModel.SeatCapacity,
                Type = busModel.Type,
                BusManuFacturerName = busModel.BusManuFacturer.Name
            };
            return busModelSummary;
        }

        public void Create(BusModelDTO busModelDTO)
        {
            var busModel = new BusModel(busModelDTO.BusModelId, busModelDTO.BusModelName, busModelDTO.Type, busModelDTO.SeatCapacity, busModelDTO.HasToilet, busModelDTO.BusManuFacturerId);

            _repository.Add(busModel);
        }

        public void Delete(BusModelDTO busModelDTO)
        {
            var busModel = new BusModel(busModelDTO.BusModelId);
            _repository.Remove(busModel);
        }


        public void Update(BusModelDTO busModelDTO)
        {
            var busModel = new BusModel(busModelDTO.BusModelId,busModelDTO.BusModelName,busModelDTO.BusManuFacturerId);
            _repository.Update(busModel);
        }
    }
}
