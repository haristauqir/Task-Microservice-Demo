using System;
using System.Linq;
using System.Threading.Tasks;
using User.Data.Database;

namespace User.Data.Repository.v1
{
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly UserContext _userContext;

        public Repository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _userContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Could not get entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity is null");
            }

            try
            {
                await _userContext.AddAsync(entity);
                await _userContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity is null");
            }

            try
            {
                _userContext.Update(entity);
                await _userContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} couldn't be updated");
            }
        }
    }
}