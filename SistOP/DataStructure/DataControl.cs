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
    public class DataControl
    {
        private const string FILE_NAME = "FileSystem.bin";
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

        private string addSeparadordeConteudo(string conteudo)
        {
            return "<" + conteudo + ">";

        }
        public string genStringFile(Arquivo Atual)
        {
            return genStringFile(Atual.Nome, Atual.IsDir, Atual.Conteudo, Atual.Pai, Atual.DirID, Atual.PaiID, Atual.Permissao,Atual.DataCriacao,Atual.UltimaAlteracao);
        }
        //public string genStringFile(string nome, IsDirectory diretorio, string conteudo, Arquivo Pai, long dirID, long paiID)
        //{


        //    string retorno = "";

        //    //Indica inicio de arquivo.
        //    //@|isdir|Permissao|Nome|DirID|PaiID|<conteudo>|@
        //    retorno += "@|";

        //    //Adiciona validador de diretório
        //    retorno += diretorio.ToString() + "|";

        //    //Adiciona nome do arquivo
        //    retorno += nome + "|";

        //    //Adiciona hashID do arquivo
        //    retorno += dirID + "|";

        //    //Adiciona hashID do pai do arquivo
        //    retorno += paiID + "|";

        //    //Adiciona conteudo entre <>
        //    retorno += addSeparadordeConteudo(conteudo) + "|@";
        //    return retorno;
        //}
        public string genStringFile(string nome, IsDirectory diretorio, string conteudo, Arquivo Pai, long dirID, long paiID, Permissions permissao, DateTime Criacao, DateTime Alteracao)
        {
string retorno = "";

            //Indica inicio de arquivo.
            //@|isdir|Permissao|Nome|DirID|PaiID|<conteudo>|@
            retorno += "@|";

            //Adiciona validador de diretório
            retorno += diretorio.ToString() + "|";

            //Adiciona nome do arquivo
            retorno += nome + "|";

            //Adiciona hashID do arquivo
            retorno += dirID + "|";

            //Adiciona hashID do pai do arquivo
            retorno += paiID + "|";

            //Adiciona conteudo entre <>
            retorno += addSeparadordeConteudo(conteudo) + "|";
            //
            retorno += permissao.ToString() + "|";

            //Adiciona a data de Criação
            retorno += Criacao.ToString() + "|";
            //Adiciona a data de Alteração
            retorno += Alteracao.ToString() + "|@";


            return retorno;

        }
        public void Salva(Arquivo aux)
        {
            Salva(aux.Nome, aux.IsDir, aux.Conteudo, aux.Pai, aux.DirID, aux.PaiID, aux.DataCriacao, aux.UltimaAlteracao);
        }
        public void Salva(string nome, IsDirectory Diretorio, string conteudo, Arquivo Pai, long dirID, long paiID, DateTime Criacao, DateTime Alteracao)
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

            dados += genStringFile(nome, Diretorio, conteudo, Pai, dirID, paiID, new Permissions(),Criacao,Alteracao);
            //Salva a String de arquivo em disco
            w.Write(dados);


            fs.Close();
            w.Close();
        }
        public void Atualiza(Arquivo Atual, Arquivo Atualizado)
        {

            this.dados = Recupera();
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

            string at = genStringFile(Atual);
            string atual = genStringFile(Atualizado);

            this.dados = this.dados.Replace(at, atual);

            w.Write(this.dados);

            w.Close();
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
        public void remove(Arquivo Excluir)
        {
            this.dados = Recupera();

            Remover(dados, Excluir);
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

            w.Close();
            fs.Close();
        }

        private void Remover(string dados, Arquivo Excluir)
        {

            string aux = genStringFile(Excluir);
            int index = dados.IndexOf(aux, 0, StringComparison.CurrentCultureIgnoreCase);

            if (index != -1)
            {
                this.dados = this.dados.Remove(index, aux.Length);
                foreach (Arquivo e in Excluir.Filhos)
                {

                    Remover(this.dados, e);

                }
                if (Excluir.Filhos.Count > 0)
                {
                    Excluir.Filhos.Clear();
                }

            }


        }
    }
}
