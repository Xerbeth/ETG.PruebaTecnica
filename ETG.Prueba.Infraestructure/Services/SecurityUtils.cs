#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Services
{
    public static class SecurityUtils
    {
        public static string DesencriptarCadena(string key_General, string CadenaEncriptada)
        {
            string CadenaDesencriptada = String.Empty;

            if (String.IsNullOrEmpty(CadenaEncriptada))
            {
                return CadenaDesencriptada;
            }

            try
            {
                MemoryStream Memdata = new MemoryStream();
                RC2CryptoServiceProvider RC2 = new RC2CryptoServiceProvider();
                Byte[] Key_General_Byte = Encoding.ASCII.GetBytes(key_General);
                ICryptoTransform Transforma_Datos;

                //    'Metodo de encripcion RC2
                Byte[] Plain_Text = Convert.FromBase64String(CadenaEncriptada);
                RC2.Mode = CipherMode.CBC;
                Transforma_Datos = RC2.CreateDecryptor(Key_General_Byte, Encoding.ASCII.GetBytes(key_General));
                CryptoStream EncodeStream = new CryptoStream(Memdata, Transforma_Datos, CryptoStreamMode.Write);
                EncodeStream.Write(Plain_Text, 0, Plain_Text.Length);
                EncodeStream.FlushFinalBlock();
                EncodeStream.Close();

                CadenaDesencriptada = Encoding.ASCII.GetString(Memdata.ToArray());
            }
            catch (Exception e)
            {
                Exception ex = new Exception("Fallo en desencripción" + e.Message);
                throw ex;
            }

            return CadenaDesencriptada;
        }
    }
}
