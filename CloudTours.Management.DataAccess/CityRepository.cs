using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using CloudTours.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.DataAccess
{
    public class CityRepository : ICityRepository
    {
       private readonly CloudToursDbContext _context;

        public CityRepository(CloudToursDbContext context)
        {
            _context = context;
        }

        public City Find(int id)
        {
            return _context.Cities.Find(id);      
        }
        public IEnumerable<City> GetAll()
        {
            return _context.Cities.ToList();   
        }
        public void Add(City city)
        {
            _context.Add(city);
            _context.SaveChanges();
        }
        public void Remove(City city)
        {
            _context.Remove(city);
            _context.SaveChanges();
        }
        public void Update(City city)
        {
            _context.Update(city);
            _context.SaveChanges();
        }
    }
}
