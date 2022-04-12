using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using CloudTours.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.DataAccess
{
    public class BusModelRepository : IBusModelRepository
    {

        private readonly CloudToursDbContext _context;

        public BusModelRepository(CloudToursDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BusModel> GetAll(bool includeBusManuFac = false)
        {
            var dbQuery = _context.BusModels.AsQueryable();

            if (includeBusManuFac)
            {
                dbQuery = dbQuery.Include(b => b.BusManuFacturer);

            }
            return dbQuery.ToList();
        }

        public BusModel Find(int id, bool includeBusManuFac = false)
        {
            var busModel = _context.BusModels.Find(id);
            if (busModel != null && includeBusManuFac)
            {
                _context.Entry(busModel).Reference(b => b.BusManuFacturer).Load();
            }
            return busModel;
        }
        public void Add(BusModel model)
        {
            _context.BusModels.Add(model);
            _context.SaveChanges();
        }

        public void Remove(BusModel model)
        {
            _context.BusModels.Remove(model);
            _context.SaveChanges(true);
        }


        public void Update(BusModel model)
        {
            _context.BusModels.Update(model);
            _context.SaveChanges();
        }


    }
}
