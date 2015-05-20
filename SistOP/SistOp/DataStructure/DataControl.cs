using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SistOp.DataStructure
{
    class DataControl
    {
        private const string FILE_NAME = "Teste.dat";
        public enum IsDirectory { D, A }
        public bool FileExists()
        {
            if (File.Exists(FILE_NAME))
            {
                return true;
            }

            return false;
        }

        private string addSeparadordeConteudo(string conteudo)
        {
            return "<" + conteudo + ">";

        }
        public string genStringFile(string nome, IsDirectory diretorio, string conteudo, Arquivo Pai, long dirID, long paiID)
        {
            
            string isDir = "";
            string retorno = "";
            if (diretorio == IsDirectory.D)
            {
                isDir = IsDirectory.D.ToString();
            }
            else
            {
                isDir = IsDirectory.A.ToString();
            }
            //Indica inicio de arquivo.
            //@|isdir|Nome|HashDirID|HashPai|<conteudo>|
            retorno += "@|";

            //Adiciona validador de diretório
            retorno += isDir + "|";

            //Adiciona nome do arquivo
            retorno += nome + "|";

            //Adiciona hashID do arquivo
            retorno += dirID + "|";

            //Adiciona hashID do pai do arquivo
            retorno += paiID + "|";

            //Adiciona conteudo entre <>
            retorno += addSeparadordeConteudo(conteudo) + "|@";
            return retorno;
        }
        public void Salva(string nome, IsDirectory Diretorio, string conteudo, Arquivo Pai,long dirID, long paiID)
        {
            string dados = Recupera();
            //MessageBox.Show(HashNome);
            FileStream fs;
            BinaryWriter w;
            if (FileExists())
            {
                fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.ReadWrite);
                w = new BinaryWriter(fs);
            }
            else
            {
                fs = new FileStream(FILE_NAME, FileMode.CreateNew);
                w = new BinaryWriter(fs);
            }


            //Salva a String de arquivo em disco
            w.Write(dados + genStringFile(nome, Diretorio, conteudo, Pai,dirID, paiID));


            fs.Close();
        }

        public string Recupera()
        {
            string t = "";
            //Abre arquivo para leitura
            if (FileExists())
            {
                FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(fs);


                t += r.ReadString();
                //MessageBox.Show(t);

                r.Close();
                fs.Close();
            }
            return t;
        }
    }
}
