using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repository;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Services.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWorks _unitOfWorks;

        public Service(IGenericRepository<T> repository, IUnitOfWorks unitOfWorks)
        {
            _repository = repository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<T> AddAsync(T Entity)
        {
            await _repository.AddAsync(Entity);
            await _unitOfWorks.CommitAsync();
            return Entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWorks.CommitAsync();
            return entities;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);

            if (hasProduct==null)
            {
                throw new ClientSideException($"{typeof(T).Name}({id}) not found");
            }
            return hasProduct;
        }

        public async Task RemoveAsync(T Entity)
        {
            _repository.Remove(Entity);
            await _unitOfWorks.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWorks.CommitAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
            _repository.Update(Entity);
            await _unitOfWorks.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);

        }
    }
}
