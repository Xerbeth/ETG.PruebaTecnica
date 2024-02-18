#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.DTOs
{
    public class ProductoDTO
    {
        public int ProID { get; set; }
        public string? ProDesc { get; set; }
        public System.Decimal ProValor { get; set; }
        public ProductoDTO() { }

    }
}
