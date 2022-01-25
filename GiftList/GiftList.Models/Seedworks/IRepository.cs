using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftList.Models.Seedworks
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> AddAsync(T aggregateRoot);
        T Update(T aggregateRoot);
        Task DeleteAsync(T aggregateRoot);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync();
    }
}
