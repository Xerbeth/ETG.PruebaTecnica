#region Referencias
using ETG.Prueba.Core.Interfaces.Repository;
using ETG.Prueba.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Repositories
{
    public class UsuariosRepository : BaseRepository<Core.Entities.Usuarios>, IUsuariosRepository
    {
        private readonly ETG_DBContext _etg_DBContext;
        protected DbSet<Core.Entities.Usuarios> usuarios;
        public UsuariosRepository(ETG_DBContext etg_DBContext) : base(etg_DBContext)
        {
            this._etg_DBContext = etg_DBContext;
            this.usuarios = etg_DBContext.Set<Core.Entities.Usuarios>();
        }        

    }
}
