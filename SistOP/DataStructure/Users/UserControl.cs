using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SistOp.DataStructure.Users
{
    class UserControl
    {
        private const string FILE_NAME = "FileSystemU.bin";
        //private const string COUNT_FILE_NAME = "count.dat";
        public enum UserType { U, A }
        private string dados = "";


        public bool FileExists()
        {
            if (File.Exists(FILE_NAME))
            {
                return true;
            }

            return false;
        }


        public string genStringFile(User user)
        {
            return genStringFile(user.Usuario, user.Senha, user.UserType, user.Acessos);
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
        public string genStringFile(string nome, string Senha, UserType UserType, List<long> Acessos)
        {
            string retorno = "";
            string permissoes = "";
            if (Acessos != null)
            {


                foreach (long acesso in Acessos)
                {
                    permissoes += acesso.ToString() + "-";
                }
                permissoes = permissoes.Trim('-');
            }
            //Indica inicio de arquivo.
             
            retorno += "@|";

            //Adiciona nome de usuario
            retorno += nome + "|";

            //Adiciona senha do usuario
            retorno += Senha + "|";

            //Adiciona permissoes
            retorno += permissoes + "|";

            //Tipo de Usuario
            retorno += UserType.ToString()+"|@";
            return retorno;

        }

        /// <summary>
        /// Salva o novo usuário no banco.
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <param name="Senha">Senha</param>
        /// <param name="TipoUsuario">A. Administrador, U. Usuario</param>
        /// <param name="acessos">Acessos permitidos ao usuário</param>
        public void Salva(string nome, string Senha, UserType TipoUsuario, List<long> acessos)
        {
            string dados = Recupera();

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

            dados += genStringFile(nome, Senha, TipoUsuario, acessos); ;
         
            //Salva a String de arquivo em disco
            w.Write(dados);


            fs.Close();
            w.Close();
        }
        public void Salva(User Aux)
        {
            Salva(Aux.Usuario, Aux.Senha, Aux.UserType, Aux.Acessos);
        }
        public void Atualiza(User Atual, User Atualizado)
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
        private List<long> RecuperaAcessos(string[] Acessos)
        {
            List<long> lista = new List<long>();
            foreach (string str in Acessos)
            {
                lista.Add(long.Parse(str));
            }

            return lista;
        }
        public List<User> RecuperaLista()
        {
            List<User> list = new List<User>();

            string dados = Recupera();
            string[] usuarios = dados.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            string[] aux;
            string str1;
            foreach (string str in usuarios)
            {
                str1 = str.Trim('|');
                aux = str1.Split(new char[] { '|' });
                string[] acesso = aux[2].Split(new char[] { '-' });
                list.Add(new User(aux[0], aux[1], (UserType)Enum.Parse(typeof(UserType), aux[3]), RecuperaAcessos(acesso)));
            }

            return list;

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
        public void remove(User Excluir)
        {
            this.dados = Recupera();

            Remover(dados, Excluir);

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

        private void Remover(string dados, User Excluir)
        {

            string aux = genStringFile(Excluir);
            int index = dados.IndexOf(aux, 0, StringComparison.CurrentCultureIgnoreCase);

            if (index != -1)
            {
                this.dados = this.dados.Remove(index, aux.Length);
            }
        }

       

    }
}
