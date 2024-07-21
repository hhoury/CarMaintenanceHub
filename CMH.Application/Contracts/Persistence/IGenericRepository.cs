using CMH.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string? id);
        Task<TResult> GetAsync<TResult>(string? id);
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();
        Task<T> AddAsync(T entity);
        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        Task DeleteAsync(string id);
        Task UpdateAsync(T entity);
        Task UpdateAsync<TSource>(string id, TSource source) where TSource : IBaseDto;
        Task<bool> Exists(string id);
    }
}
