using AutoMapper;
using CMH.Application.Contracts.Persistence;
using CMH.Domain.Entities;
using CMH.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Persistence.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly IMapper _mapper;
        private readonly CMHDbContext _context;

        public CarRepository(IMapper mapper, CMHDbContext context) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
