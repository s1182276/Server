using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeuzeWijzerApi.DAL.Repositories
{
    public class StudyRouteRepo : IStudyRouteRepo
    {
        private readonly KeuzeWijzerContext _context;

        public StudyRouteRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Studyroute> GetById(int id)
        {
            return await _context.Studyroutes
                .Include(sr => sr.StudyrouteSemesters)
                .ThenInclude(ss => ss.Module)
                .Include(sr => sr.StudyrouteSemesters)
                .ThenInclude(ss => ss.SchoolYear)
                .FirstOrDefaultAsync(sr => sr.Id == id);
        }

        public async Task<IEnumerable<Studyroute>> GetAll()
        {
            return await _context.Studyroutes
                .Include(sr => sr.StudyrouteSemesters)
                .ThenInclude(ss => ss.Module)
                .Include(sr => sr.StudyrouteSemesters)
                .ThenInclude(ss => ss.SchoolYear)
                .ToListAsync();
        }

        public async Task Add(Studyroute entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Studyroutes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Studyroute entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Studyroutes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Studyroute entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Studyroutes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool DoesExist(int id)
        {
            return _context.Studyroutes.Any(lr => lr.Id == id);
        }
    }
}
