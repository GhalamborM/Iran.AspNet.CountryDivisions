﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Iran.AspNet.CountryDivisions.Data.DatabaseContext;
using Iran.AspNet.CountryDivisions.Data.Models;
using Iran.AspNet.CountryDivisions.Helpers;

using Microsoft.EntityFrameworkCore;

namespace Iran.AspNet.CountryDivisions
{
    public class IranCountryDivisions : IIranCountryDivisions
    {
        #region ctor
        private readonly LocationsDbContext _db;
        public IranCountryDivisions(LocationsDbContext db)
        {
            _db = db ?? new LocationsDbContext();
        }
        #endregion
        #region main
        public async Task UpdateDatabaseAsync()
        {
            var a = await _db.Abadis.ToListAsync();
            if (a.Any()) _db.Abadis.RemoveRange(a);

            var b = await _db.Bakhshs.ToListAsync();
            if (b.Any()) _db.Bakhshs.RemoveRange(b);

            var c = await _db.Dehestans.ToListAsync();
            if (c.Any()) _db.Dehestans.RemoveRange(c);

            var d = await _db.Ostans.ToListAsync();
            if (d.Any()) _db.Ostans.RemoveRange(d);

            var e = await _db.Shahrs.ToListAsync();
            if (e.Any()) _db.Shahrs.RemoveRange(e);

            var f = await _db.Shahrestans.ToListAsync();
            if (f.Any()) _db.Shahrestans.RemoveRange(f);

            var g = await _db.Keshvars.ToListAsync();
            if (g.Any()) _db.Keshvars.RemoveRange(g);

            await _db.SaveChangesAsync();


            var txt1 = System.IO.File.ReadAllText(JsonDataPath.AbadiJsonPath);
            var ostans1 = JsonToDataConvert.ToAbadiList(txt1);
            foreach (var item in ostans1.ToList())
            {
                await _db.Abadis.AddAsync(item);
            }

            var txt2 = System.IO.File.ReadAllText(JsonDataPath.BakhshJsonPath);
            var ostans2 = JsonToDataConvert.ToBakhshList(txt2);
            foreach (var item in ostans2.ToList())
            {
                await _db.Bakhshs.AddAsync(item);
            }
            var txt3 = System.IO.File.ReadAllText(JsonDataPath.DehestanJsonPath);
            var ostans3 = JsonToDataConvert.ToDehestanList(txt3);
            foreach (var item in ostans3.ToList())
            {
                await _db.Dehestans.AddAsync(item);
            }
            var txt4 = System.IO.File.ReadAllText(JsonDataPath.OstanJsonPath);
            var ostans4 = JsonToDataConvert.ToOstanList(txt4);
            foreach (var item in ostans4.ToList())
            {
                await _db.Ostans.AddAsync(item);
            }
            var txt5 = System.IO.File.ReadAllText(JsonDataPath.ShahrJsonPath);
            var ostans5 = JsonToDataConvert.ToShahrList(txt5);
            foreach (var item in ostans5.ToList())
            {
                await _db.Shahrs.AddAsync(item);
            }
            var txt6 = System.IO.File.ReadAllText(JsonDataPath.ShahrestanJsonPath);
            var ostans6 = JsonToDataConvert.ToShahrestanList(txt6);
            foreach (var item in ostans6.ToList())
            {
                await _db.Shahrestans.AddAsync(item);
            }
            var txt7 = System.IO.File.ReadAllText(JsonDataPath.KeshvarJsonPath);
            var ostans7 = JsonToDataConvert.ToKeshvarList(txt7);
            foreach (var item in ostans7.ToList())
            {
                await _db.Keshvars.AddAsync(item);
            }
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                var ee = ex;
            }

        }
        public IQueryable<TEntity> GetEntity<TEntity>(bool asTracking = false) where TEntity : class
        {
            if (asTracking)
            {
                return _db.Set<TEntity>().AsTracking();
            }
            else
            {
                return _db.Set<TEntity>().AsNoTracking();
            }
        }
        #endregion
        #region sync
        public IEnumerable<Ostan> GetOstans(Expression<Func<Ostan, bool>> filter = null,
Func<IQueryable<Ostan>, IOrderedQueryable<Ostan>> orderBy = null, int count = 0)
        {


            var query = _db.Ostans.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<Abadi> GetAbadis(Expression<Func<Abadi, bool>> filter = null,
              Func<IQueryable<Abadi>, IOrderedQueryable<Abadi>> orderBy = null, int count = 0)
        {

            var query = _db.Abadis.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }

        }
        public IEnumerable<Bakhsh> GetBakhshs(Expression<Func<Bakhsh, bool>> filter = null,
             Func<IQueryable<Bakhsh>, IOrderedQueryable<Bakhsh>> orderBy = null, int count = 0)
        {
            var query = _db.Bakhshs.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<Dehestan> GetDehestans(Expression<Func<Dehestan, bool>> filter = null,
             Func<IQueryable<Dehestan>, IOrderedQueryable<Dehestan>> orderBy = null, int count = 0)
        {
            var query = _db.Dehestans.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<Shahr> GetShahrs(Expression<Func<Shahr, bool>> filter = null,
             Func<IQueryable<Shahr>, IOrderedQueryable<Shahr>> orderBy = null, int count = 0)
        {
            var query = _db.Shahrs.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<Shahrestan> GetShahrestans(Expression<Func<Shahrestan, bool>> filter = null,
             Func<IQueryable<Shahrestan>, IOrderedQueryable<Shahrestan>> orderBy = null, int count = 0)
        {
            var query = _db.Shahrestans.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<Keshvar> GetKeshvars(Expression<Func<Keshvar, bool>> filter = null,
     Func<IQueryable<Keshvar>, IOrderedQueryable<Keshvar>> orderBy = null, int count = 0)
        {
            var query = _db.Keshvars.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        #endregion
        #region async
        public async Task<IEnumerable<Ostan>> GetOstansAsync(Expression<Func<Ostan, bool>> filter = null,
Func<IQueryable<Ostan>, IOrderedQueryable<Ostan>> orderBy = null, int count = 0)
        {


            var query = _db.Ostans.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async Task<IEnumerable<Abadi>> GetAbadisAsync(Expression<Func<Abadi, bool>> filter = null,
              Func<IQueryable<Abadi>, IOrderedQueryable<Abadi>> orderBy = null, int count = 0)
        {

            var query = _db.Abadis.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }

        }
        public async Task<IEnumerable<Bakhsh>> GetBakhshsAsync(Expression<Func<Bakhsh, bool>> filter = null,
                     Func<IQueryable<Bakhsh>, IOrderedQueryable<Bakhsh>> orderBy = null, int count = 0)
        {
            var query = _db.Bakhshs.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async Task<IEnumerable<Dehestan>> GetDehestansAsync(Expression<Func<Dehestan, bool>> filter = null,
                     Func<IQueryable<Dehestan>, IOrderedQueryable<Dehestan>> orderBy = null, int count = 0)
        {
            var query = _db.Dehestans.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async Task<IEnumerable<Shahr>> GetShahrsAsync(Expression<Func<Shahr, bool>> filter = null,
                     Func<IQueryable<Shahr>, IOrderedQueryable<Shahr>> orderBy = null, int count = 0)
        {
            var query = _db.Shahrs.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<Shahrestan>> GetShahrestansAsync(Expression<Func<Shahrestan, bool>> filter = null,
                     Func<IQueryable<Shahrestan>, IOrderedQueryable<Shahrestan>> orderBy = null, int count = 0)
        {
            var query = _db.Shahrestans.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<Keshvar>> GetKeshvarsAsync(Expression<Func<Keshvar, bool>> filter = null,
                   Func<IQueryable<Keshvar>, IOrderedQueryable<Keshvar>> orderBy = null, int count = 0)
        {
            var query = _db.Keshvars.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = Math.Abs(count);
            if (count > 0)
                query = query.Take(count);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        #endregion
        #region dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        ~IranCountryDivisions()
        {
            Dispose(false);
        }

        #endregion
    }
}
