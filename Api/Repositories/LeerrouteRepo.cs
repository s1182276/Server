using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeuzeWijzerApi.Repositories
{
    public class LeerrouteRepo : ILeerrouteRepo
    {
        private readonly KeuzeWijzerContext _context;

        public LeerrouteRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<LearningRoute> GetById(int id)
        {
            return await _context.Leerroutes.FindAsync(id);
        }

        public async Task<IEnumerable<LearningRoute>> GetAll()
        {
            return await _context.Leerroutes.Include(x => x.LearningYears).ToListAsync();
        }

        public void Add(LearningRoute entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Leerroutes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(LearningRoute entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Leerroutes.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(LearningRoute entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Leerroutes.Remove(entity);
            _context.SaveChanges();
        }

        public bool DoesExist(int id)
        {
            return _context.Leerroutes.Any(lr => lr.Id == id);
        }
    }
}
