using CLCommon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CLCommon.Repository
{
    public class EntityFrameworkRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityFrameworkRepositoryAsync()
        {
            _context = new CorsoAcademyContext();
            _dbSet = _context.Set<T>();
        }
        /* public async Task<T> GetByIdAsync(int Id, string includeProperties)
         {
             var listElements = _dbSet.Include(includeProperties).ToListAsync().Result.Select(T,);
             var element = listElements.Result.Find(x => x.Id.GetType() == id);
             return element.Result;
         }*/

        public async Task<IEnumerable<T>> GetAllAsync(string includeProperties)
        {
            return await _dbSet.Include(includeProperties).ToListAsync();

        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Boolean> UpdateAsync(T entity)
        {
            Boolean isUpdated = false;
            try
            {
                _context.Update(entity);
                int ret = await _context.SaveChangesAsync();
                isUpdated = Convert.ToBoolean(ret);
            }
            catch (Exception ex)
            {
                string sErr = string.Empty;
                if (ex.InnerException != null)
                {
                    sErr = string.Format("Source : {0}{4}Message : {1}{4}StackTrace: {2}{4}InnerException: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException.Message, System.Environment.NewLine);
                }
                else
                {
                    sErr = string.Format("Source : {0}{3}Message : {1}{3}StackTrace: {2}{3}", ex.Source, ex.Message, ex.StackTrace, System.Environment.NewLine);

                }
                // _logger.LogError(sErr);
            }

            return isUpdated;

        }

        public async Task<Boolean> DeleteAsync(T entity)
        {
            Boolean isDeleted = false;
            // DELETE
            _dbSet.Remove(entity);
            int ret = await _context.SaveChangesAsync();
            isDeleted = Convert.ToBoolean(ret);
            throw new NotImplementedException();
        }

        public Task<T> GetAndEnsureExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAndEnsureExistAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
