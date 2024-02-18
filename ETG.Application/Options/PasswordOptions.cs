#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Application.Options
{
    public class PasswordOptions
    {
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
        public PasswordOptions() { }
    }
}
