using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure
{
    class Permissions
    {
        /// <summary>
        /// Libera as permissões conforme abaixo:
        /// P0: ---
        /// P1: --x
        /// P2: -w-
        /// P3: -wx
        /// P4: r--
        /// P5: r-x
        /// P6: rw-
        /// P7: rwx
        /// </summary>
        public enum PermissionsType { P0= 0, P1 = 1, P2 =2, P3 = 3, P4 = 4, P5 = 5, P6 = 6, P7 = 7 };

        private PermissionsType user;
        private PermissionsType group;
        private PermissionsType others;
        public PermissionsType User
        {
            get { return user; }
            set { user = value; }
        }

        public PermissionsType Group
        {
            get { return group; }
            set { group = value; }
        }

        public PermissionsType Others
        {
            get { return others; }
            set { others = value; }
        }
        public Permissions(PermissionsType user, PermissionsType group, PermissionsType others)
        {
            this.user = user;
            this.group = group;
            this.others = others;
        }
        /// <summary>
        /// Todas Permissões liberadas
        /// </summary>
        public Permissions()
        {
            PermissionsType PT = PermissionsType.P7;
            AlteraPermissions(PT);
        }
        public Permissions(string permissao)
        {
            if (permissao != null)
            {
             
                User = ConvertToPermissionType(permissao[0]);
                Group = ConvertToPermissionType(permissao[1]);
                Others = ConvertToPermissionType(permissao[2]);
            }

        }
        public PermissionsType ConvertToPermissionType (char permission)
        {
            if (permission >'0' && permission <= '7')
            {
            return (PermissionsType)Enum.Parse(typeof(PermissionsType), permission.ToString());    
            }
            return PermissionsType.P0;
            
        }

        /// <summary>
        /// Altera as permissões de acordo com as permissoes de um ARQUIVO.
        /// </summary>
        /// <param name="File"></param>
        private void AlteraPermissions(Arquivo File)
        {
            AlteraPermissions(File.Permissao);
        }

        /// <summary>
        /// Altera permissoes de acordo com as permissoes passadas
        /// </summary>
        /// <param name="permit">Arquivo.Permissions</param>
        private void AlteraPermissions(Permissions permit)
        {
            this.user = permit.User;
            this.group = permit.Group;
            this.others = permit.Others;
        }
        /// <summary>
        /// Libera um acesso identico a todos.
        /// </summary>
        /// <param name="PT"></param>
        private void AlteraPermissions(PermissionsType PT)
        {
            this.user = PT;
            this.group = PT;
            this.others = PT;
        }
        /// <summary>
        /// Bloqueia todas as permissões do arquivo
        /// </summary>
        /// 
        public void AllDenied()
        {
            PermissionsType PT = PermissionsType.P0;
            AlteraPermissions(PT);
        }

        /// <summary>
        /// Permite todas as permissões de arquivo
        /// </summary>
        public void AllPermited()
        {
            PermissionsType PT = PermissionsType.P7;
            AlteraPermissions(PT);
        }


        /// <summary>
        /// Converte de Enum para '777' ou '645' por exemplo.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return User.ToString().Trim('P') + Group.ToString().Trim('P') + Others.ToString().Trim('P');
        }



    }
}
