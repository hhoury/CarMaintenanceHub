using CMH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Application.Contracts.Persistence
{
    public interface ICarRepository : IGenericRepository<Car>
    {
    }
}
