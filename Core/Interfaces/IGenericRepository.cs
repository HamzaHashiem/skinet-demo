using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecifcation<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecifcation<T> spec);
        Task<int> CountAsync(ISpecifcation<T> spec);
        void DeleteAsync(T entity);
        void Add(T entity);
    }
}