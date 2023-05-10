using BancoAPI.Data.Entitites;
using BancoAPI.Data.Factories;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Data.Repository
{
    public interface IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        IQueryable<TEntity> PrepareQuery();
        TEntity Find(int id);
        List<TEntity> FindByUserId(string userId); 
        List<TEntity> FindByUserIdAndTimeframe(string userId, TimeFrame timeFrame);
        void Update(TEntity entity);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        int Save();
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly BancoDbContext _dbContext;
        protected DbSet<TEntity> Entities { get; init; }

        public GenericRepository(BancoDbContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> PrepareQuery() =>
            Entities.AsQueryable();

        public TEntity Find(int id)
            => PrepareQuery().AsNoTracking().SingleOrDefault(x => x.id == id);

        public List<TEntity> FindByUserId(string userId)
            => PrepareQuery().AsNoTracking().Where(x => x.userId == userId).ToList();

        public List<TEntity> FindByUserIdAndTimeframe(string userId, TimeFrame timeFrame)
        {
            var minDate = DateTime.Now.AddDays(-(int)timeFrame);
            //TODO filtrar timeframe
            return PrepareQuery().AsNoTracking().Where(x => x.userId == userId).Where(i => i.created > minDate).ToList();
        }

        public void Add(TEntity entity) =>
            Entities.Add(entity);

        public void Update(TEntity entity) =>
           Entities.Update(entity);

        public void Delete(TEntity entity) =>
            Entities.Remove(entity);

        public int Save() => 
            _dbContext.SaveChanges();
    }
}
