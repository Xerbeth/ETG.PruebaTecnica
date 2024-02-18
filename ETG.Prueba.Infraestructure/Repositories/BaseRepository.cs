#region Referencias
using ETG.Prueba.Core.Entities;
using ETG.Prueba.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ETG.Prueba.Application.Exceptions;
using static System.Net.Mime.MediaTypeNames;
using ETG.Prueba.Core.Static;
using ETG.Prueba.Infraestructure.Data;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Repositories
{
    /// <summary>
    /// Clase repositorio base con la implementación de los métodos generales de cada repositorio
    /// </summary>
    /// <typeparam name="T"> Clase genericas </typeparam>
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region  Propiedades
        private readonly ETG_DBContext _etg_DBContext;
        protected DbSet<T> entities;
        #endregion Propiedades

        #region Métodos
        #region Constructores
        public BaseRepository(ETG_DBContext etg_DBContext)
        {
            this._etg_DBContext = etg_DBContext;
            this.entities = etg_DBContext.Set<T>();
        }

        #endregion Constructores
        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
        public async Task<T> GetById(int Id)
        {
            return await entities.FindAsync(Id);
        }

        /// <summary>
        /// Método para consultar por un criterio sobre la entidad
        /// </summary>
        /// <param name="predicate"> Criterio de consulta </param>
        /// <returns> Resultado de la consulta </returns>
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Método para no trackear la entidad al consultarla
        /// </summary>
        /// <param name="predicate"> Criterio de consulta </param>
        /// <returns> Resultado de la consulta </returns>
        public async Task<T> GetAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Add(T entity)
        {
            await entities.AddAsync(entity);
        }

        /// <summary>
        /// Método para agregar multiples registros
        /// </summary>
        /// <param name="entity"> Lista de la entidad </param>
        /// <returns></returns>
        public async Task AddRange(List<T> entity)
        {
            await entities.AddRangeAsync(entity);
        }

        /// <summary>
        /// Método para eliminar registros por criterios
        /// </summary>
        /// <param name="predicate"> Predicado de la consulta de los registros </param>
        /// <returns></returns>
        public async Task DeleteRecords(Expression<Func<T, bool>> predicate)
        {
            var records = await this.GetAll(predicate);
            if (records.Count == 1)
                this.entities.Remove(records.FirstOrDefault());
            else if (records.Count > 1)
                this.entities.RemoveRange(records);
        }

        public async Task Delete(int Id)
        {
            T entity = await GetById(Id);
            this.entities.Remove(entity);
        }

        public void Delete(List<T> entity)
        {
            this.entities.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            try
            {
                entities.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Application.Exceptions.BaseRepositoryException(BaseRepositoryMessages.ERRBSRPSTR01);
            }
        }

        /// <summary>
        /// Método para actualizar registros masivos
        /// </summary>
        /// <param name="entity"> Lista de entidades </param>
        public void UpdateRange(List<T> entity)
        {
            try
            {
                entities.UpdateRange(entity);
            }
            catch (Exception ex)
            {
                throw new Application.Exceptions.BaseRepositoryException(BaseRepositoryMessages.ERRBSRPSTR02);
            }
        }

        /// <summary>
        /// Método para obtener una lista de registros de la entidad por una expresión
        /// </summary>
        /// <param name="predicate"> Expresión para el filtro </param>
        /// <returns> Lista de resultados de la consulta </returns>
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Método para no trackear la entidad al consultarla
        /// </summary>
        /// <param name="predicate"> Criterio de consulta </param>
        /// <returns> Resultado de la consulta </returns>
        public async Task<List<T>> GetAllAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Método para obtener el número total de registross
        /// </summary>
        /// <returns> Cantidad de registros de la entidad </returns>
        public async Task<int> CountRecord()
        {
            return await entities.CountAsync();
        }
        #endregion Métodos
    }
}
