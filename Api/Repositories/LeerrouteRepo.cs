using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.Repositories
{
    public class LeerrouteRepo : ILeerrouteRepo
    {
        private readonly KeuzeWijzerContext _context;

        public LeerrouteRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(LearningRoute entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Leerroutes.Add(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(LearningRoute entity)
        {
            throw new NotImplementedException();
        }

        public bool DoesExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LearningRoute>> GetAll()
        {

            return await _context.Leerroutes.ToListAsync();
        }

        public Task<LearningRoute> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(LearningRoute entity)
        {
            throw new NotImplementedException();
        }
    }
}