using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMH.Application.Contracts.Persistence;
using CMH.Application.Exceptions;
using CMH.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        protected readonly DbContext _context;
        private readonly IMapper _mapper;
        public GenericRepository(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
        {
            var entity = _mapper.Map<T>(source);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TResult>(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetAsync(id);

            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }



        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await _context.Set<T>()
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


        public async Task<T> GetAsync(string? id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result is null)
            {
                throw new NotFoundException(typeof(T).Name, !string.IsNullOrEmpty(id) ? id : "No Key Provided");
            }

            return result;
        }

        public async Task<TResult> GetAsync<TResult>(string? id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result is null)
            {
                throw new NotFoundException(typeof(T).Name, !string.IsNullOrEmpty(id) ? id : "No Key Provided");
            }

            return _mapper.Map<TResult>(result);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<TSource>(string id, TSource source) where TSource : IBaseDto
        {
            if (id != source.Id)
            {
                throw new BadRequestException("Invalid Id used in request");
            }

            var entity = await GetAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            _mapper.Map(source, entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
