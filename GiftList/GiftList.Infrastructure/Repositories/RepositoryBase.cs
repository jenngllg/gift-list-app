using GiftList.Models.Seedworks;
using Microsoft.EntityFrameworkCore;

namespace GiftList.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected GiftListContext Context { get; set; }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return Context;
            }
        }

        protected RepositoryBase(GiftListContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task<T> AddAsync(T aggregateRoot)
        {
            return (await Context.AddAsync<T>(aggregateRoot)).Entity;
        }

        public virtual Task DeleteAsync(T aggregateRoot)
        {
            return Task.Run(() =>
            {
                Context.Remove<T>(aggregateRoot);
            });
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await Context.FindAsync<T>(id);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await Context.Set<T>().ToArrayAsync();
        }

        public virtual T Update(T aggregateRoot)
        {
            return Context.Update<T>(aggregateRoot).Entity;
        }
    }
}
