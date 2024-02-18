#region Referencias
using ETG.Prueba.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //DatabaseFacade Database { get; }
        /// <summary>
        /// Método para validar la conexión a la base de datos
        /// </summary>
        /// <returns> Respuesta de bandera de conexión </returns>
        string GetConnection();
        void SaveChanges();
        Task SaveChangesAsync();

        //aqui vienen todos los repositorios de la aplicación
        IUsuariosRepository UsuariosRepository { get; }
        IProductoRepository ProductoRepository { get; }
        IPedidoRepository PedidoRepository { get; }
    }
}
