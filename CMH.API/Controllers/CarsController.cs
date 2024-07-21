using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CMH.Application.Contracts.Persistence;
using CMH.Application.DTOs;
using CMH.Application.Models;
using CMH.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CMH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public CarsController(IMapper mapper,ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PagedList<CarDto>>> GetCars(string? search,int page=1,int pageSize = 10)
        {
            try
            {
                var cars = await _carRepository.GetAllAsync<CarDto>();
                
                if (cars == null || cars.Count == 0) 
                {
                    return NoContent();
                }
                if (!string.IsNullOrWhiteSpace(search))
                {
                    cars = cars.Where(c => c.Make.Contains(search)).ToList();
                }

                var pagedCars = await PagedList<CarDto>.CreateAsync(cars.AsQueryable(), page,pageSize);
                return Ok(pagedCars);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCar([FromBody] CreateCarDto car, CancellationToken cancellationToken)
        {
            var carToAdd = _mapper.Map<Car>(car);
            await _carRepository.AddAsync(carToAdd);
            return NoContent();
        }
    }
}
