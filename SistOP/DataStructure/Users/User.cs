using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure.Users
{
    class User
    {
        private string usuario;
        private string senha;
        private List<long> acessos;
        private UserControl.UserType uT;

        public UserControl.UserType UserType
        {
            get { return uT; }
            set { uT = value; }
        }


        public List<long> Acessos
        {
            get { return acessos; }
            set { acessos = value; }
        }




        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }


        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public User(string usuario, string senha)
        {

            this.usuario = usuario;
            this.senha = senha;
            this.Acessos = new List<long>();
            this.Acessos.Add(0);
            this.uT = UserControl.UserType.U;
        }
        public User(string Usuario, string senha, UserControl.UserType Type, List<long> Acessos)
        {
            this.usuario = Usuario;
            this.senha = senha;
            this.uT = Type;
            this.acessos = Acessos;

        }
    }
}
