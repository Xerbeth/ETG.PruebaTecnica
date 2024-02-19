#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Static
{
    public static class PedidoMessages
    {        
        public const string ERRPED01 = "ERRPED01 - Ocurrió un error al momento de registrar la información del pedido.";
        public const string ERRPED02 = "ERRPED02 - Ocurrió un error actualizando la información del pedido.";
        public const string ERRPED03 = "ERRPED03 - Ocurrió un error eliminando el pedido. Existen registros de pedidos del producto.";
        public const string ERRPED04 = "ERRPED04 - Ocurrió un error eliminando la información del pedido.";
        public const string ERRPED05 = "ERRPED05 - No existe información del pedido.";
        public const string ERRPED06 = "ERRPED06 - Ocurrió un error consultando la información de los pedidos.";
        public const string ERRPED07 = "ERRPED07 - Ocurrió un error consultando la información del pedido.";
    }
}
