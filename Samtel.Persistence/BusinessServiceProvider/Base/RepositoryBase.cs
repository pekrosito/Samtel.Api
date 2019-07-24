using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DapperExtensions;
using Samtel.Application;
using Samtel.Domain.Models.Base;
using Samtel.Application.BusinessService.Base;

namespace Samtel.Persistence.BusinessServiceProvider.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        public readonly RequestContext RequestContext;
        public IDbConnection Conn { get; private set; }
        public IContext Context { get; private set; }

        protected RepositoryBase(IContext context, RequestContext requestContext)
        {
            RequestContext = requestContext;
            Context = context;
            Conn = context.Connection;
        }

        public void ExecuteStoreProcedure(string storeProcedureName, object param)
        {
            Conn.Execute(storeProcedureName, param, Context.CurrentTransaction, null, CommandType.StoredProcedure);
        }

        public T Save(T obj)
        {
            if (obj is IAuditableEntity)
                obj = (T)AuditableEntityAddDataInsert((IAuditableEntity)obj);
            //obj.Id = Int32.MaxValue;
            Conn.Insert(obj, Context.CurrentTransaction);
            return obj;
        }

        public TEntity Save<TEntity>(TEntity obj) where TEntity : class, IEntity
        {
            if (obj is IAuditableEntity)
                obj = (TEntity)AuditableEntityAddDataInsert((IAuditableEntity)obj);
            //obj.Id = Int32.MaxValue;
            Conn.Insert(obj, Context.CurrentTransaction);
            return obj;
        }

        public T Update(T obj)
        {
            if (obj is IAuditableEntity)
                obj = (T)AuditableEntityAddDataUpdate((IAuditableEntity)obj);
            Conn.Update(obj, Context.CurrentTransaction);
            return obj;
        }

        public TEntity Update<TEntity>(TEntity obj) where TEntity : class, IEntity
        {
            if (obj is IAuditableEntity)
                obj = (TEntity)AuditableEntityAddDataUpdate((IAuditableEntity)obj);
            Conn.Update(obj, Context.CurrentTransaction);
            return obj;
        }

        public T Delete(T obj)
        {
            if (obj is IAuditableEntity)
                obj = (T)AuditableEntityAddDataUpdate((IAuditableEntity)obj);
            Conn.Delete(obj, Context.CurrentTransaction);
            return obj;
        }

        public TEntity Delete<TEntity>(TEntity obj) where TEntity : class, IEntity
        {
            if (obj is IAuditableEntity)
                obj = (TEntity)AuditableEntityAddDataUpdate((IAuditableEntity)obj);
            Conn.Delete(obj, Context.CurrentTransaction);
            return obj;
        }

        public IEnumerable<TEntity> ExecuteStoreProcedure<TEntity>(string storeProcedureName)
        {
            return Conn.Query<TEntity>(storeProcedureName, null, Context.CurrentTransaction, true, null, CommandType.StoredProcedure);
        }

        public IEnumerable<TEntity> ExecuteStoreProcedure<TEntity>(string storeProcedureName, object param)
        {
            return Conn.Query<TEntity>(storeProcedureName, param, Context.CurrentTransaction, true, null, CommandType.StoredProcedure);
        }

        public SqlMapper.GridReader ExecuteMultiple(string storeProcedureName, object param)
        {
            return Conn.QueryMultiple(storeProcedureName, param, Context.CurrentTransaction, null, CommandType.StoredProcedure);
        }

        public IEnumerable<TResponse> Query<TResponse>(string sql, object param = null)
        {
            return Conn.Query<TResponse>(sql, param, Context.CurrentTransaction);
        }

        public int Execute(string sql, object param)
        {
            return Conn.Execute(sql, param, Context.CurrentTransaction);
        }

        public void AuditableEntityAddDataInsert<TEntity>(IEnumerable<TEntity> objs) where TEntity : IAuditableEntity
        {
            foreach (var obj in objs)
            {
                AuditableEntityAddDataInsert(obj);
            }
        }

        public TEntity AuditableEntityAddDataInsert<TEntity>(TEntity obj) where TEntity : IAuditableEntity
        {
            obj.CreatedDate = DateTime.Now;
            obj.UpdatedDate = obj.CreatedDate;
            //obj.CreatedById = RequestContext.CurrentSession?.UserId;
            //obj.UpdatedById = RequestContext.CurrentSession?.UserId;
            return obj;
        }

        public TEntity AuditableEntityAddDataUpdate<TEntity>(TEntity obj) where TEntity : IAuditableEntity
        {
            obj.UpdatedDate = DateTime.Now;
            //obj.UpdatedById = RequestContext.CurrentSession?.UserId;
            return obj;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
