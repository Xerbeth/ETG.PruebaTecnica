#region Referencias
using ETG.Prueba.Core.Interfaces.Repository;
using ETG.Prueba.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Repositories
{
    public class ProductoRepository : BaseRepository<Core.Entities.Producto>, IProductoRepository
    {
        private readonly ETG_DBContext _etg_DBContext;
        protected DbSet<Core.Entities.Producto> producto;
        public ProductoRepository(ETG_DBContext etg_DBContext) : base(etg_DBContext)
        {
            this._etg_DBContext = etg_DBContext;
            this.producto = etg_DBContext.Set<Core.Entities.Producto>();
        }        

    }
}
