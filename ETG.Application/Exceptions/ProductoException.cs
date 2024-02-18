#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Application.Exceptions
{
    /// <summary>
    /// Clase personalizada para el manejo de excepciones sobre la entidad de ususarios
    /// </summary>
    public class ProductoException : Exception
    {
        #region Métodos 
        #region Constructores
        public ProductoException() { }
        public ProductoException(string message) : base(message)
        {

        }
        #endregion Constructores
        #endregion Métodos
    }
}
