#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Static
{
    public static class ProductoMessages
    {        
        public const string ERRPRODC01 = "ERRPRODC01 - Ocurrió un error al momento de registrar la información del producto.";
        public const string ERRPRODC02 = "ERRPRODC02 - Ocurrió un error actualizando la información del producto.";
        public const string ERRPRODC03 = "ERRPRODC03 - Ocurrió un error eliminando el producto. Existen registros de pedidos del producto.";
        public const string ERRPRODC04 = "ERRPRODC04 - Ocurrió un error eliminando la información del producto.";
        public const string ERRPRODC05 = "ERRPRODC05 - No existe información del producto.";
        public const string ERRPRODC06 = "ERRPRODC06 - Ocurrió un error consultando la información de los productos.";
        public const string ERRPRODC07 = "ERRPRODC07 - Ocurrió un error consultando la información del producto.";
    }
}
