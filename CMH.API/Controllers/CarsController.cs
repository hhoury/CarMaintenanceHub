using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CMH.Application.Contracts.Persistence;
using CMH.Application.DTOs;
using CMH.Application.Models;
using CMH.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public CarsController(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(Guid id)
        {
            try
            {
                var car = await _carRepository.GetAsync<CarDto>(id);
                if (car == null)
                {
                    return NotFound();
                }
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<CarDto>>> GetCars(string? search, int page = 1, int pageSize = 10)
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
                    cars = cars.Where(c => c.Make.ToLower().Contains(search.ToLower())).ToList();
                }

                var pagedCars = await PagedList<CarDto>.CreateAsync(cars.AsQueryable(), page, pageSize);
                return Ok(pagedCars);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar([FromBody] CarDto carDto)
        {

            try
            {
                var car = _mapper.Map<Car>(carDto);
                await _carRepository.UpdateAsync(car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CarExists(carDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult> CreateCar([FromBody] CreateCarDto car, CancellationToken cancellationToken)
        {
            var carToAdd = _mapper.Map<Car>(car);
            await _carRepository.AddAsync(carToAdd);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCar(string id)
        {
            if (!await CarExists(id))
            {
                return NotFound();
            }
            await _carRepository.DeleteAsync(id);
            return NoContent();
        }
        private async Task<bool> CarExists(string id)
        {
            return await _carRepository.Exists(id);
        }
    }
}
