#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.DTOs
{
    public class PedidoDTO
    {
        public int PedID { get; set; }
        public int PedUsu { get; set; }
        public int PedProd { get; set; }
        public System.Decimal PedVrUnit { get; set; }
        public float PedCant { get; set; }
        public System.Decimal PedSubTot { get; set; }
        public float PedIVA { get; set; }
        public System.Decimal PedTotal { get; set; }
        public PedidoDTO() { }
    }
}
