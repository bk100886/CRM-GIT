using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Core.IRepositories
{
    /// <summary>
    /// Репозиторий операций CRUD.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IGenericRepository<TEntity>
        where TEntity:Entity
    {
        /// <summary>
        /// Получить запись по идентификатору.
        /// </summary>
        /// <param name="Id">Идентификатор.</param>
        /// <param name="cols">Выбираемые поля.</param>
        /// <returns>Запись.</returns>
        TEntity GetById(Guid Id, params string[] cols);

        /// <summary>
        /// Получить записи.
        /// </summary>
        /// <param name="filter">Фильтр.</param>
        /// <param name="noLock">Не блокировать.</param>
        /// <param name="TopCount">Максимальное количество возвращаемых записей.</param>
        /// <param name="cols">Выбираемые поля.</param>
        /// <returns>Список записей.</returns>
        List<TEntity> Get(FilterExpression filter = null, bool noLock = true, int? TopCount = 5000, params string[] cols);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="entity">Объект.</param>
        /// <returns>Идентификатор.</returns>
        Guid Create(TEntity entity);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="entity">Объект.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Удалить запись.
        /// </summary>
        /// <param name="Id">Идентификатор.</param>
        void Delete(Guid Id);

        /// <summary>
        /// Удалить запись.
        /// </summary>
        /// <param name="entity">Объект.</param>
        void Delete(TEntity entity);

    }
}
