using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Transactions;
using Data;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UnitOfWork
{
       /// <summary>
    /// EntityFramework için oluşturmuş olduğumuz UnitOfWork.
    /// EFRepository'de olduğu gibi bu şekilde tasarlamamızın ana sebebi ise veritabanına independent(bağımsız) bir durumda kalabilmek. Örneğin MongoDB için ise ilgili provider'ı aracılığı ile MongoDBOfWork tasarlayabiliriz.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Members

        private DbContext _dbContext;
        private bool _disposed;

        /// <summary>
        /// İşlemlerde hata oluşusa bu liste doldurulur.
        /// </summary>
        private readonly List<string> _errorMessageList = new List<string>();

        #endregion

        #region Properties

        /// <summary>
        /// Açılan veri bağlantısı.
        /// </summary>
        public DbContext DbContext
        {
            get => _dbContext ?? (_dbContext = new MasterContext());
            set => _dbContext = value;
        }

        #endregion

        #region Constructre

        public UnitOfWork()
        {
        }

        #endregion

        #region IUnitOfWork Members

        /// <summary>
        /// Repository instance'ı başlatmak için kullanılır.
        /// </summary>
        /// <typeparam name="T">Veri Tabanı Tür Nesnesi</typeparam>
        /// <returns>Tür nesnesi ile ilgili Repository</returns>
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(DbContext);
        }

        /// <summary>
        /// Değişiklikleri kaydet.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            try
            {
                int result;
                using (TransactionScope tScope = new TransactionScope())
                {
                    result = DbContext.SaveChanges();
                    tScope.Complete();
                }
                return result;
            }
            catch (ValidationException ex)
            {
                string errorString = ex.Message;
                return -1;
            }
            catch (DbUpdateException ex)
            {
                string errorString = ex.Message;
                if (ex.InnerException != null)
                {
                    errorString += ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        errorString += ex.InnerException.InnerException.Message;
                        _errorMessageList.Add(ex.InnerException.InnerException.Message);
                    }
                    else
                    {
                        _errorMessageList.Add(ex.InnerException.Message);
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                _errorMessageList.Add(ex.Message);
                return -1;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Nesneyi bellekten atmadan önce bağlantıyı kapatır.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                    DbContext = null;
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// IDisposable Design Pattern instance'ı
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
