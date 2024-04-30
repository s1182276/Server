﻿using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.Repositories
{
    public class ModuleRepo : IModuleRepo
    {
        private readonly KeuzeWijzerContext _context; 

        public ModuleRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Module entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Modules.Add(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(Module entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Modules.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Module>> GetAll()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<Module> GetById(int id)
        {
            return await _context.Modules.FindAsync(id); 
        }

        public void Update(Module entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Modules.Update(entity);
            _context.SaveChangesAsync();
        }

        public bool DoesExist(int id)
        {
            return _context.Modules.Any(e => e.Id == id);
        }
    }
}