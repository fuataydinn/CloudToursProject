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
    public class BusManuFacturerRepository : IBusManuFacturerRepository
    {
        private readonly CloudToursDbContext _context;

        public BusManuFacturerRepository(CloudToursDbContext cloudToursDbContext)
        {
            _context = cloudToursDbContext;
        }

        public IEnumerable<BusManuFacturer> GetAll()
        {
            return _context.BusManuFacturers.ToList();
        }

        public BusManuFacturer Find(int id)
        {
           return _context.BusManuFacturers.Find(id);
        }
        public void Create(BusManuFacturer busManuFacturer)
        {
            _context.BusManuFacturers.Add(busManuFacturer);
            _context.SaveChanges();
        }

        public void Delete(BusManuFacturer busManuFacturer)
        {
            _context.BusManuFacturers.Remove(busManuFacturer);
            _context.SaveChanges();

        }

        public void Update(BusManuFacturer busManuFacturer)
        {
            _context.Update(busManuFacturer);
            _context.SaveChanges();
        }
      
    }
}
