using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Enums;

namespace DataAccess.Repository
{
    /// <summary>
    /// Model katmanımızda bulunan her T tipi için aşağıda tanımladığımız fonksiyonları
    /// gerçekleştirebilecek generic bir repository tanımlıyoruz.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Tüm veriyi getirir.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Veriyi Where Metodu ile getirir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Verilen sorguya göre adeti getirir.
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// istenilen veriyi where metodu ile getirir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Veriyi single(tek) getirir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Sorgu sonucunda seçili veritabanı kolonlarına göre liste döndürür.
        /// </summary>
        /// <param name="where">Veri kısıtlamaları</param>
        /// <param name="select">Seçilecek kolonlar</param>
        /// <returns></returns>
        IQueryable<dynamic> SelectList(Expression<Func<T, bool>> where, Expression<Func<T, dynamic>> select);

        /// <summary>
        /// Belirli aralıkta , sıralayarak istediğimiz verinin dönmesini sağlar.
        /// </summary>
        /// <param name="where">neye göre gelsin</param>
        /// <param name="sort">neye göre sıralansın</param>
        /// <param name="sortType">sıralama çeşidi ASC|DESC </param>
        /// <param name="skipCount">nereden başlasın</param>
        /// <param name="takeCount">kaç veri gelsin</param>
        /// <returns></returns>
        IQueryable<T> GetDataPart(Expression<Func<T, bool>> where, Expression<Func<T, dynamic>> sort,
            SortTypeEnum sortType, int skipCount, int takeCount);

        /// <summary>
        /// Sql sorgusu göndermeye yarar
        /// </summary>
        /// <param name="sqlQuery">gönderilecek sql sorgusu</param>
        /// <returns></returns>
        List<T> SendSql(string sqlQuery);

        /// <summary>
        /// Verilen entityi ekle.
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Verilen entity i güncelle.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// predicate göre veriler düzenlenir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="entity"></param>
        void Update(Expression<Func<T, bool>> predicate, T entity);


        /// <summary>
        /// Verilen entityi sil.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="forceDelete"></param>
        void Delete(T entity, bool forceDelete = false);

        /// <summary>
        /// predicate göre veriler silinir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="forceDelete"></param>
        void Delete(Expression<Func<T, bool>> predicate, bool forceDelete = false);

        /// <summary>
        /// Aynı kayıt eklememek için objeyi kontrol ederek true veya false dönderir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> predicate);
    }
}
