using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure
{
    class BinaryChange
    {
        public string toByte(string texto)
        {
            byte[] bytes1;
            bytes1 = Encoding.UTF8.GetBytes(texto);
            return BitConverter.ToString(bytes1);
        }

        public string toStr(string bytes)
        {
            string[] aux = bytes.Split('-');
            int i = 0;
            byte[] bytes1 = new byte[aux.Length];
            string resultado = "";
            foreach (string s in aux)
            {
                if (s != "")
                {
                    // converter de texto p byte
                    bytes1[i++] = byte.Parse(s,System.Globalization.NumberStyles.HexNumber);
                }
            }
            resultado = Encoding.UTF8.GetString(bytes1);
            return resultado;
        }
    }
}
