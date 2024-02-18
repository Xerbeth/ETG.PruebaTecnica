#region Referencias
using ETG.Prueba.Core.Entities;
using System.Linq.Expressions;
#endregion Referencias

namespace ETG.Prueba.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        /// <summary>
        /// Método para consultar por un criterio sobre la entidad
        /// </summary>
        /// <param name="predicate"> Criterio de connsulta </param>
        /// <returns> Resultado de la consulta </returns>
        Task<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Método para no trackear la entidad al consultarla
        /// </summary>
        /// <param name="predicate"> Criterio de connsulta </param>
        /// <returns> Resultado de la consulta </returns>
        Task<T> GetAsNoTracking(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        /// <summary>
        /// Método para agregar multiples registros
        /// </summary>
        /// <param name="entity"> Lista de la entidad </param>
        /// <returns></returns>
        Task AddRange(List<T> entity);
        void Update(T entity);
        /// <summary>
        /// Método para actualizar registros masivos
        /// </summary>
        /// <param name="entity"> Lista de entidades </param>
        void UpdateRange(List<T> entity);
        /// <summary>
        /// Método para eliminar registros por criterios
        /// </summary>
        /// <param name="predicate"> Predicado de la consulta de los registros </param>
        /// <returns></returns>
        Task DeleteRecords(Expression<Func<T, bool>> predicate);
        Task Delete(int Id);
        void Delete(List<T> entity);

        /// <summary>
        /// Método para obtener una lista de registros de la entidad por una expresión
        /// </summary>
        /// <param name="predicate"> Expresión para el filtro </param>
        /// <returns> Lista de resultados de la consulta </returns>
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Método para obtener el número total de registross
        /// </summary>
        /// <returns> Cantidad de registros de la entidad </returns>
        Task<int> CountRecord();
        Task<List<T>> GetAllAsNoTracking(Expression<Func<T, bool>> predicate);

    }
}
