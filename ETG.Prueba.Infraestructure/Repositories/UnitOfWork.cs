#region Referencias
using ETG.Prueba.Core.Interfaces;
using ETG.Prueba.Core.Interfaces.Repository;
using ETG.Prueba.Infraestructure.Data;
using ETG.Prueba.Infraestructure.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Repositories
{
    /// <summary>
    /// Unidad de trabajo (unit of work) es el patrón que permite manejar transacciones durante la manipulación de datos utilizando el patrón repositorio
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Dependencias
        private readonly ETG_DBContext _etg_DBContext;
        private readonly string _connectionString;
        #endregion Dependencias
        public UnitOfWork(ETG_DBContext etg_DBContext, IConfiguration configuration)
        {
            this._etg_DBContext = etg_DBContext;
            _connectionString = SecurityUtils.DesencriptarCadena(configuration.GetConnectionString("EncryptionKey"), configuration.GetConnectionString("db_sga"));
        }

        #region Repositorios Seguridad
        public IUsuariosRepository UsuariosRepository => new UsuariosRepository(_etg_DBContext);
        public IProductoRepository ProductoRepository => new ProductoRepository(_etg_DBContext);
        public IPedidoRepository PedidoRepository => new PedidoRepository(_etg_DBContext);        
        #endregion Repositorios Seguridad

        public void Dispose()
        {
            if (_etg_DBContext != null)
                _etg_DBContext.Dispose();
        }

        public void SaveChanges()
        {
            this._etg_DBContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this._etg_DBContext.SaveChangesAsync();
        }

        /// <summary>
        /// Método para validar la conexión a la base de datos
        /// </summary>
        /// <returns> Respuesta de bandera de conexión </returns>
        public string GetConnection()
        {
            SqlConnection cnn = new SqlConnection(this._connectionString);
            cnn.Open();
            cnn.Close();
            return this._connectionString;
        }
        public DatabaseFacade Database
        {
            get { return _etg_DBContext.Database; }
        }
    }
}
