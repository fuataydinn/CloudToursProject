using CloudTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Repositories
{
    public interface IBusManuFacturerRepository
    {
        IEnumerable<BusManuFacturer> GetAll();
        BusManuFacturer Find(int id);
        void Create(BusManuFacturer busManuFacturer);
        void Update(BusManuFacturer busManuFacturer);
        void Delete(BusManuFacturer busManuFacturer);
    }
}
