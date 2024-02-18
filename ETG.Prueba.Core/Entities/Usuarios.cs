#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Entities
{
    public class Usuarios : BaseEntity
    {
        public Usuarios()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int UsuId { get; set; }
        public int UsuNombre { get; set; }
        public string UsuPass { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
