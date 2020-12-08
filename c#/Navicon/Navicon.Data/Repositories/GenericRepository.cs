using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Navicon.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Repositories
{
    /// <inheritdoc cref="IGenericRepository{TEntity}"/>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Сервис CRM.
        /// </summary>
        protected readonly IOrganizationService service;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервис CRM.</param>
        public GenericRepository(IOrganizationService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
      
        /// <inheritdoc/>
        public Guid Create(TEntity entity)
        {
            return service.Create(entity);
        }

        /// <inheritdoc/>
        public void Delete(Guid Id)
        {
            service.Delete(typeof(TEntity).Name, Id);
        }

        /// <inheritdoc/>
        public void Delete(TEntity entity)
        {
            service.Delete(typeof(TEntity).Name, entity.Id);
        }

        /// <inheritdoc/>
        public List<TEntity> Get(FilterExpression filter=null, bool noLock=true, int? TopCount=5000,  params string[] cols)
        {
            var query = new QueryExpression(typeof(TEntity).Name);
            if (cols == null) query.ColumnSet = new ColumnSet(true);
            else query.ColumnSet = new ColumnSet(cols);
            if (filter != null) query.Criteria.AddFilter(filter);
            query.TopCount = TopCount;
            query.NoLock = noLock;
            return service.RetrieveMultiple(query).Entities.Select(s => s.ToEntity<TEntity>()).ToList();
        }

        /// <inheritdoc/>
        public TEntity GetById(Guid Id, params string[] cols)
        {
            ColumnSet columns;
            var query = new QueryExpression(typeof(TEntity).Name);
            if (cols == null) columns = new ColumnSet(true);
            else columns = new ColumnSet(cols);
            return  service.Retrieve(typeof(TEntity).Name, Id, columns).ToEntity<TEntity>();
        }

        /// <inheritdoc/>
        public void Update(TEntity entity)
        {
            service.Update(entity);
        }
    }
}
