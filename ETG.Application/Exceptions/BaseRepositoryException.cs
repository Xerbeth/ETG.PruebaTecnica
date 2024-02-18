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
    /// Clase personalizada para el manejo de excepciones sobre la entidad de tipo de usuario
    /// </summary>
    public class BaseRepositoryException : Exception
    {
        #region Métodos 
        #region Constructores
        public BaseRepositoryException() { }
        public BaseRepositoryException(string message) : base(message)
        {

        }

        #endregion Constructores
        #endregion Métodos
    }
}
