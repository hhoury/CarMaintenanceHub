using AutoMapper;
using CMH.Application.DTOs;
using CMH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<MaintenanceGarage, MaintenanceGarageDto>().ReverseMap();
            CreateMap<CarMaintenanceGarage, CarMaintenanceGarageDto>().ReverseMap();
        }
    }
}
