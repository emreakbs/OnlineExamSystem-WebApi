using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Tüm verileri getirir.
        /// SELECT * FROM T
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            IQueryable<T> iQueryable = _dbSet;
            return iQueryable;
        }

        /// <summary>
        /// Şarta göre tüm verileri getirir.
        /// SELECT * FROM T WHERE PREDICATE
        /// </summary>
        /// <param name="predicate">Veri şartı</param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> iQueryable = _dbSet
                .Where(predicate);
            return iQueryable;
        }

        public int Count()
        {
            IQueryable<T> iQueryable = _dbSet;
            return iQueryable.Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> iQueryable = _dbSet
                .Where(predicate);
            return iQueryable.Count();
        }

        /// <summary>
        /// Şarta göre tek veri getirir
        /// SELECT TOP 1 * FROM T WHERE PREDICATE
        /// </summary>
        /// <param name="predicate">Veri şartı</param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> iQueryable = _dbSet.Where(predicate);
            return iQueryable.ToList().FirstOrDefault();
        }

        /// <summary>
        /// Verileri kolonlarını seçerek getirir
        /// SELECT TOP 1 A,B,C,D FROM T WHERE PREDICATE
        /// </summary>
        /// <param name="where"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public IQueryable<dynamic> SelectList (Expression<Func<T, bool>> @where, Expression<Func<T, dynamic>> @select)
        {
            return _dbSet
                .AsNoTracking()
                .Where(@where)
                .Select(@select);
        }
        /// <summary>
        /// Verileri kolonlarını seçerek getirir Skip ve Limit dahil eder.
        /// SELECT TOP TAKECOUNT * FROM T WHERE PREDICATE ORDER BY SORT SORTTYPE
        /// </summary>
        /// <param name="where">Veri şartı</param>
        /// <param name="sort">Sıralama şartı</param>
        /// <param name="sortType">Sıralama tipi</param>
        /// <param name="skipCount">Getirilen verilerde atlanacak veri sayısı</param>
        /// <param name="takeCount">Getirilen verilerde alınacak veri sayısı</param>
        /// <returns></returns>
        public IQueryable<T> GetDataPart(Expression<Func<T, bool>> @where, Expression<Func<T, dynamic>> sort, SortTypeEnum sortType, int skipCount, int takeCount)
        {
            if (sortType == SortTypeEnum.DESC)
            {
                return _dbSet
                    .AsNoTracking()
                    .Where(@where)
                    .Skip(skipCount)
                    .Take(takeCount);
            }

            return _dbSet
                .AsNoTracking()
                .OrderBy(sort)
                .Where(@where)
                .Skip(skipCount)
                .Take(takeCount);
        }

        /// <summary>
        /// Entity ile sql sorgusu göndermek için kullanılır.
        /// </summary>
        /// <param name="sqlQuery">Gönderilecek sql</param>
        /// <returns></returns>
        public List<T> SendSql(string sqlQuery)
        {
            return _dbSet.FromSql(sqlQuery).AsNoTracking().ToList();
        }
        /// <summary>
        /// Verilen veriyi context üzerine ekler.
        /// </summary>
        /// <param name="entity">Eklenecek entity</param>
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Verilen veriyi context üzerinde günceller.
        /// </summary>
        /// <param name="entity">Güncellenecek entity</param>
        public void Update(T entity)
        {

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Verilen veriyi context üzerinden siler.
        /// </summary>
        /// <param name="entity">Delete entity</param>
        /// <param name="forceDelete">nesneyi veritabanından gerçekten sil. (HARD-DELETE)</param>
        public void Delete(T entity, bool forceDelete)
        {

            // Önce entity'nin state'ini kontrol etmeliyiz.
            EntityEntry<T> dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }


        /// <summary>
        /// Aynı kayıt eklememek için objeyi kontrol ederek true veya false dönderir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate) != null;
        }
  
        public void Delete(Expression<Func<T, bool>> predicate, bool forceDelete = false)
        {
            Delete(_dbSet.First(predicate), forceDelete);
        }

        public void Update(Expression<Func<T, bool>> predicate, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
