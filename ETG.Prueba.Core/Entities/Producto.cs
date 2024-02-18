#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Entities
{
    public class Producto : BaseEntity
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ProId { get; set; }
        public string? ProDesc { get; set; }
        public decimal ProValor { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
