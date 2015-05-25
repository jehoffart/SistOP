using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure
{
    public class Permissions
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
        public enum PermissionsType { P0 = 0, P1 = 1, P2 = 2, P3 = 3, P4 = 4, P5 = 5, P6 = 6, P7 = 7 };
        public enum TiposAcesso { R, W, E };
        //private PermissionsType user;
        //private PermissionsType group;
        //private PermissionsType others;

        private List<long> leitura = new List<long>();
        private List<long> escrita = new List<long>();
        private List<long> execucao = new List<long>();
        public List<long> Leitura
        {
            get { return leitura; }
            set { leitura = value; }
        }

        //public PermissionsType User
        //{
        //    get { return user; }
        //    set { user = value; }
        //}

        //public PermissionsType Group
        //{
        //    get { return group; }
        //    set { group = value; }
        //}

        //public PermissionsType Others
        //{
        //    get { return others; }
        //    set { others = value; }
        //}
        public Permissions()
        {

        }

        public Permissions(string permissao)
        {
            if (permissao != null)
            {
                string[] aux = permissao.Split(new char[] { ',' });
                InicializaPermissoes(aux[0], TiposAcesso.R);
                InicializaPermissoes(aux[1], TiposAcesso.W);
                InicializaPermissoes(aux[2], TiposAcesso.E);
            }

        }

        private void InicializaPermissoes(string aux, TiposAcesso TA)
        {
            string[] perm = aux.Split('-');

            foreach (string s in perm)
            {

                if (s != "")
                {


                    switch (TA)
                    {
                        case TiposAcesso.R:
                            {
                                leitura.Add(long.Parse(s));
                                break;
                            }
                        case TiposAcesso.W:
                            {
                                escrita.Add(long.Parse(s));
                                break;
                            }
                        case TiposAcesso.E:
                            {
                                execucao.Add(long.Parse(s));
                                break;
                            }
                    }
                }
            }
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
            this.escrita = permit.escrita;
            this.execucao = permit.execucao;
            this.leitura = permit.leitura;
        }

        public void AllDenied()
        {
            this.leitura = new List<long>();
            this.escrita = new List<long>();
            this.execucao = new List<long>();
        }


        public void AlteraPermissions(long id, TiposAcesso TA)
        {
            bool Bloqueado = Permite(id, TA);
            if (!Bloqueado)
            {
                switch (TA)
                {
                    case TiposAcesso.R:
                        {
                            leitura.Add(id);
                            break;
                        }
                    case TiposAcesso.W:
                        {
                            escrita.Add(id);
                            break;
                        }
                    case TiposAcesso.E:
                        {
                            execucao.Add(id);
                            break;
                        }
                }
            }
            else
            {
                switch (TA)
                {
                    case TiposAcesso.R:
                        {
                            leitura.Remove(id);
                            break;
                        }
                    case TiposAcesso.W:
                        {
                            escrita.Remove(id);
                            break;
                        }
                    case TiposAcesso.E:
                        {
                            execucao.Remove(id);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Converte de Enum para '7-7-7,7-4-2,6-5-4' onde cada numero é o id de um user (Leitura,Escrita,Execucao).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string aux = "";
            foreach (long l in leitura)
            {
                aux += l.ToString() + "-";
            }
            aux = aux.Trim(new char[] { '-' });
            aux += ",";

            foreach (long l in escrita)
            {
                aux += l.ToString() + "-";
            }
            aux = aux.Trim(new char[] { '-' });
            aux += ",";

            foreach (long l in execucao)
            {
                aux += l.ToString() + "-";
            }
            aux = aux.Trim(new char[] { '-' });

            return aux;
        }


        public bool Permite(long id, TiposAcesso TA)
        {
            switch (TA)
            {
                case TiposAcesso.R:
                    {
                        return leitura.Contains(id);

                    }
                case TiposAcesso.E:
                    {
                        return execucao.Contains(id);
                    }
                case TiposAcesso.W:
                    {
                        return escrita.Contains(id);
                    }
            }

            return false;
        }
    }
}
