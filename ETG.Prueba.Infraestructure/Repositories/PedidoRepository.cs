#region Referencias
using ETG.Prueba.Core.Interfaces.Repository;
using ETG.Prueba.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Repositories
{
    public class PedidoRepository : BaseRepository<Core.Entities.Pedido>, IPedidoRepository
    {
        private readonly ETG_DBContext _etg_DBContext;
        protected DbSet<Core.Entities.Pedido> pedido;
        public PedidoRepository(ETG_DBContext etg_DBContext) : base(etg_DBContext)
        {
            this._etg_DBContext = etg_DBContext;
            this.pedido = etg_DBContext.Set<Core.Entities.Pedido>();
        }        

    }
}
