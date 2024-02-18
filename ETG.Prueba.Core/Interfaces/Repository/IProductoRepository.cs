#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Interfaces.Repository
{
    public interface IProductoRepository : IRepository<Entities.Producto>
    {
        // Declara métodos personalizados para la entidad        
    }
}
