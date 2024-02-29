using Application.Interfaces;
using Infrastructure.Context;
using System.Collections;

namespace Infrastructure.Repos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDBContext _context;
        private Hashtable _repositries;
        public UnitOfWork(AppDBContext context)
        {
            _context = context;
        }

        public IBaseRepo<T> Repository<T>() where T : class
        {
            if (_repositries == null)
                _repositries = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositries.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepo<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                _repositries.Add(type, repositoryInstance);
            }

            return (IBaseRepo<T>)_repositries[type]!;
        }
        public void Dispose()
        {

            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

