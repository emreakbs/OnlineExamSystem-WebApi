using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    /// <summary>
    /// UnitOfWork sınıfı tarafından kullanılacak arayüz.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
