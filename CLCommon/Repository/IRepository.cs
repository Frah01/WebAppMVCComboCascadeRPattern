using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLCommon.Repository
{
    // https://medium.com/@kerimkkara/implementing-the-repository-pattern-in-c-and-net-5fdd91950485
    public interface IRepositoryAsync<T>
    {
        Task<T> GetByIdAsync(int Id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddSync(T entity);

        Task<Boolean> UpdateAsync(T entity);
        Task<Boolean> DeleteAsync(T entity);

        Task<T> GetAndEnsureExistAsync(int id);
        Task<T> GetAndEnsureExistAsync(Guid id);


    }

    public interface IRepositorySyncronous<T>
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
