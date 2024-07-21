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
    public class MaintenanceGarageRepository : GenericRepository<MaintenanceGarage>,IMaintenanceGarageRepository
    {
        private readonly IMapper _mapper;
        private readonly CMHDbContext _context;

        public MaintenanceGarageRepository(IMapper mapper, CMHDbContext context) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
