using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure.Users
{
   public class User
    {
        private string usuario;
        private string senha;
        private List<long> acessos;
        private UserControl.UserType uT;
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }


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

        public User(string usuario, string senha, long ID)
        {

            this.usuario = usuario;
            this.senha = senha;
            this.Acessos = new List<long>();
            this.Acessos.Add(0);
            this.uT = UserControl.UserType.U;
            this.id = ID;
        }
        public User(string Usuario, string senha, UserControl.UserType Type, List<long> Acessos, long ID)
        {
            this.usuario = Usuario;
            this.senha = senha;
            this.uT = Type;
            this.acessos = Acessos;
            this.id = ID;
        }
        public bool isAdmin()
        {
            if (this.uT == UserControl.UserType.A)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Usuario;
        }
    }
}
