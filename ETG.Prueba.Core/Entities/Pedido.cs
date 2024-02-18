#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Entities
{
    public class Pedido : BaseEntity
    {
        public int PedId { get; set; }
        public int PedUsu { get; set; }
        public int PedProd { get; set; }
        public decimal PedVrUnit { get; set; }
        public double PedCant { get; set; }
        public decimal PedSubTot { get; set; }
        public double? PedIva { get; set; }
        public decimal PedTotal { get; set; }

        public virtual Producto PedProdNavigation { get; set; } = null!;
        public virtual Usuarios PedUsuNavigation { get; set; } = null!;
    }
}
