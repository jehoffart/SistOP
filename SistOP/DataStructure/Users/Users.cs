using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SistOp.DataStructure.Users
{
    class Users
    {
        private List<User> usuarios;

        public Users()
        {
            UserControl DC = new UserControl();

            usuarios = DC.RecuperaLista();
            if (usuarios.Count == 0)
            {
                List<long> lista =  new List<long>();
                lista.Add(0);
                CadastrarNovoUser("Admin", "Admin", UserControl.UserType.A, lista);
            }
        }


        /// <summary>
        /// Criptografa a senha do usuário
        /// </summary>
        /// <param name="input">Senha para Criptografar</param>
        /// <returns>Retorna a senha Criptografada</returns>
        private string getMD5Hash(string input)
        {

            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Valida a senha
        /// </summary>
        /// <param name="user">Nome de usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>retorna user ou null caso user nao seja encontrado.</returns>
        private User procuraLogin(string user, string senha)
        {
            foreach (User usr in usuarios)
            {
                if (usr.Usuario == user && usr.Senha == getMD5Hash(senha))
                {
                    return usr;
                }

            }
            return null;
        }

        /// /// <summary>
        /// Verifica se NameUser já e usado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        private User procuraLogin(string user)
        {
            foreach (User usr in usuarios)
            {
                if (usr.Usuario == user)
                {
                    return usr;
                }
            }
            return null;
        }


        /// <summary>
        /// Realiza Login de usuário
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="senha">PassWord</param>
        /// <returns>retorna se login foi efetuado com sucesso.</returns>
        public bool Login(string user, string senha)
        {
            if (procuraLogin(user, senha) == null)
            {
                return false;
            }
            return true;

        }
        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <param name="senha">Senha</param>
        /// <returns>caso usuario ja exista, retorna false</returns>
        public bool CadastrarNovoUser(string user, string senha)
        {
            User Aux = procuraLogin(user);
            if (Aux == null)
            {
                Aux = new User(user, getMD5Hash(senha));
                usuarios.Add(Aux);
                UserControl UC = new UserControl();
                UC.Salva(Aux);
                return true;

            }
            else { return false; }
        }

        public bool CadastrarNovoUser(string user, string senha, UserControl.UserType UT, List<long> acessos)
        {
            User Aux = procuraLogin(user);
            if (Aux == null)
            {
                Aux = new User(user, getMD5Hash(senha), UT, acessos);
                usuarios.Add(Aux);
                UserControl UC = new UserControl();
                UC.Salva(Aux);
                return true;

            }
            else { return false; }
        }
        public void RemoveUsuario(string user)
        {
            UserControl UC = new UserControl();
            User Usr = procuraLogin(user);
            if (Usr != null)
            {
                UC.remove(Usr);
            }

        }

        public void AtualizaUsuario(string user, string NovaSenha, UserControl.UserType UserType, List<long> Acessos)
        {

            UserControl UC = new UserControl();
            User atualizar = procuraLogin(user);
            if (atualizar != null)
            {
                User Atualizado = new User(user, getMD5Hash(NovaSenha), UserType, Acessos);
                UC.Atualiza(atualizar, Atualizado);

                usuarios.Remove(atualizar);
                usuarios.Add(Atualizado);
            }

        }
    }


}
