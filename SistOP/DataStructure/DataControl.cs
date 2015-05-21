using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SistOp.DataStructure
{
    class DataControl
    {
        private const string FILE_NAME = "FileSystem.dat";
        //private const string COUNT_FILE_NAME = "count.dat";
        public enum IsDirectory { D, A }
        private string dados = "";
        public bool FileExists()
        {
            if (File.Exists(FILE_NAME))
            {
                return true;
            }

            return false;
        }
        public bool FileExists(string Arquivo)
        {
            if (File.Exists(Arquivo))
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
        public void Salva(string nome, IsDirectory Diretorio, string conteudo, Arquivo Pai, long dirID, long paiID)
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

            dados += genStringFile(nome, Diretorio, conteudo, Pai, dirID, paiID);
            //Salva a String de arquivo em disco
            w.Write(dados);


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
        public void remove(string nome, IsDirectory Diretorio, string conteudo, Arquivo Excluir, long dirID, long paiID)
        {
            this.dados = Recupera();

            Remover(dados, nome, Diretorio, conteudo, Excluir, dirID, paiID);
            Excluir.Pai.Filhos.Remove(Excluir);
            FileStream fs;
            BinaryWriter w;

            if (FileExists())
            {
                fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Write);
                w = new BinaryWriter(fs);
            }
            else
            {
                fs = new FileStream(FILE_NAME, FileMode.CreateNew);
                w = new BinaryWriter(fs);
            }


            //Salva a String de arquivo em disco
            w.Write(this.dados);


            fs.Close();
        }

        private void Remover(string dados, string nome, IsDirectory Diretorio, string conteudo, Arquivo Excluir, long dirID, long paiID)
        {

            string aux = genStringFile(nome, Diretorio, conteudo, Excluir, dirID, paiID);
            int index = dados.IndexOf(aux, 0, StringComparison.CurrentCultureIgnoreCase);

            if (index != -1)
            {
                this.dados = this.dados.Remove(index, aux.Length);
                foreach (Arquivo e in Excluir.Filhos)
                {

                    Remover(this.dados, e.Nome, e.IsDir, e.Conteudo, e, e.DirID, e.Pai.DirID);

                }
                if (Excluir.Filhos.Count > 0)
                {
                    Excluir.Filhos = new List<Arquivo>();
                }

            }


        }
    }
}
