using FluentNHibernate.Data;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISession = NHibernate.ISession;

namespace PatikaPaycoreBootcampFinalProject.Context
{
    public class MapperSession<Entity> : IMapperSession<Entity> where Entity : class
    
    {
        private readonly ISession session;
        private ITransaction transaction;

        public MapperSession(ISession session)
        {
            this.session = session;
        }

        
        public IQueryable<Entity> Entities => session.Query<Entity>();
        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }
        public Entity GetById(long id)
        {
           
                var entity = session.Get<Entity>(id);
                return entity;
            
            
        }
        public void Save(Entity entity)
        {
            session.Save(entity);
        }

        public void Update(Entity entity)
        {
            session.Update(entity);
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                session.Delete(entity);
            }
        }
        public List<Entity> GetAll()
        {
            return session.Query<Entity>().ToList();
        }
        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where)
        {
            return session.Query<Entity>().Where(where).AsQueryable();
        }

    }
}
