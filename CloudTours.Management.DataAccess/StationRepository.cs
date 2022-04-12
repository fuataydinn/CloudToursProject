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
    public class StationRepository : IStationRepository
    {
        private readonly CloudToursDbContext _context;

        public StationRepository(CloudToursDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Station> GetAll(bool includeCity = false)
        {
            var dbQuery = _context.Stations.AsQueryable();
            if (includeCity)
            {
                dbQuery = dbQuery.Include(s => s.City);
            }
            return dbQuery.ToList();
        }

        public Station Find(int id, bool includeCity = false)
        {
            var station = _context.Stations.Find(id);
            if (station == null && includeCity)
            {
                //Explicit Loading
                _context.Entry(station).Reference(s => s.City).Load();
                //Include Yontemi
                //var stations = _context.Stations.Include(s => s.City).First(s => s.StationId == id);
            }
            return station;
        }
        public void Add(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
        }

        public void Remove(Station station)
        {
            _context.Stations.Remove(station);
            _context.SaveChanges();
        }

        public void Update(Station station)
        {
            _context.Stations.Update(station);
            _context.SaveChanges();
        }
    }
}
