﻿namespace KeuzeWijzerApi.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        bool DoesExist(int id);
    }
}