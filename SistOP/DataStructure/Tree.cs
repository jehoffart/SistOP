using System;
using System.Windows.Forms;

namespace SistOp
{
    // Classe com o nó
    public class Node
    {
        private int info;
        private Node esq, dir, pai;
        private Node[] filhos;

        public Node[] Filhos
        {
            get { return filhos; }
            set { filhos = value; }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="x">Info</param>
        /// <param name="p">Pai</param>
        public Node(int x, Node p)
        {
            info = x;
            pai = p;
            esq = null;
            dir = null;
        }

        // Properties
        public int Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }
        public Node Esq
        {
            get
            {
                return esq;
            }
            set
            {
                esq = value;
            }
        }
        public Node Dir
        {
            get
            {
                return dir;
            }
            set
            {
                dir = value;
            }
        }
        public Node Pai
        {
            get
            {
                return pai;
            }
            set
            {
                pai = value;
            }
        }
    }

    // Classe com a árvore
    public class BTree
    {
        // Nó raiz
        private Node raiz;
        public Node Raiz
        {
            get
            {
                return raiz;
            }
            set
            {
                raiz = value;
            }
        }
        private Node[] Filhos;

        public Node[] Filhos1
        {
            get { return Filhos; }
            set { Filhos = value; }
        }


        // Construtor
        public BTree()
        {
            raiz = null;
        }

        // Inserindo na árvore
        public void Insert(int x)
        {
            if (raiz == null)
                raiz = new Node(x, null);
            else
                Insert(raiz, x);

        }
        private void Insert(Node n, int x)
        {
            if (x < n.Info)
            {
                if (n.Esq == null)
                    n.Esq = new Node(x, n);
                else
                    Insert(n.Esq, x);

            }
            else
            {
                if (n.Dir == null)
                    n.Dir = new Node(x, n);
                else
                    Insert(n.Dir, x);

            }
        }

        // Pesquisa na árvore
        public Node Find(int x)
        {
            return Find(raiz, x);
        }
        private Node Find(Node n, int x)
        {
            if (n == null || n.Info == x) return n;
            if (x < n.Info)
                return Find(n.Esq, x);
            else
                return Find(n.Dir, x);
        }
        // Função para excluir nó
        public void Remove(int x)
        {
        }
        public String PasseioNivelNAria()
        {

            return PasseioNivelNAria(raiz).Trim();
        }
        private String PasseioNivelNAria(Node n)
        {
            string retorno = "";
            if (n.Filhos != null)
            {



                int qtdefilhos = n.Filhos.Length;
                if (n == raiz)
                {
                    retorno += n.Info + " ";
                }

                for (int i = 0; i < qtdefilhos; i++)
                {
                    retorno += n.Filhos[i].Info + " ";
                }
                for (int i = 0; i < qtdefilhos; i++)
                {
                    retorno += PasseioNivelNAria(n.Filhos[i]);
                }
            }
            return retorno;
        }
        public int AlturaArvoreNAria(Node n)
        {
            int alt = 1;

            if (n.Filhos != null)
            {
                int elementos = n.Filhos.Length;

                int maior = 0;
                for (int i = 0; i < elementos; i++)
                {
                    maior = AlturaArvoreNAria(n.Filhos[i]) + 1;
                    if (maior > alt)
                        alt = maior;

                }

            }

            return alt;
        }

        public int GrauArvoreNAria(Node n)
        {
            int grau = 1;

            if (n.Filhos != null)
            {
                int elementos = n.Filhos.Length;

                int maior = 0;
                for (int i = 0; i < elementos; i++)
                {
                    maior = GrauArvoreNAria(n.Filhos[i]);
                    if (maior > elementos)
                        grau = maior;
                    else
                    {
                        grau = elementos;
                    }

                }

            }

            return grau;


        }



        public int Nos(Node n)
        {
            int aux = 0;
            if (n == raiz)
            {
                aux++;
            }

            if (n.Esq != null)
            {
                aux += Nos(n.Esq) + 1;
            }
            if (n.Dir != null)
            {
                aux += Nos(n.Dir) + 1;
            }

            return aux;

        }
        public int ContaFolhas(Node n)
        {
            int folha = 0;
            if (n.Dir == null && n.Esq == null)
            {
                folha++;
            }
            if (n.Esq != null)
            {
                folha += ContaFolhas(n.Esq);

            }
            if (n.Dir != null)
            {
                folha += ContaFolhas(n.Dir);
            }

            return folha;
        }

        public int AlturaArvore(Node n)
        {
            int altesq = 0;
            int altdir = 0;
            
            if (n.Esq != null){
                altesq += AlturaArvore(n.Esq) + 1;
            }
            
            if (n.Dir != null){
                altdir += AlturaArvore(n.Dir) + 1;
            }
            if (altesq>altdir)
            {
                return altesq;
            }
            return altdir;
        }
        public bool ArvoreCompleta(Node n)
        {
            if (Nos(n) == Math.Pow(2, AlturaArvore(n)+1)-1)
            {
                return true;
            }

            MessageBox.Show(AlturaArvore(n).ToString());


            return false;
        }

    }
}
