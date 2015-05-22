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
        public enum PermissionsType { P0, P1, P2, P3, P4, P5, P6, P7 };

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


    }
}
