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
            bytes1 = Encoding.ASCII.GetBytes(texto);
            return BitConverter.ToString(bytes1);
        }

        public string toStr(string bytes)
        {
            string[] aux = bytes.Split('-');
            string resultado = "";
            foreach (string s in aux)
            {
                if (s != "")
                {
                    resultado += Convert.ToChar(Int32.Parse(s, System.Globalization.NumberStyles.HexNumber));
                }
            }

            return resultado;
        }
    }
}
