using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure
{
    class Arvore
    {

        private Arquivo raiz;
        private int countID = 0;
        private List<Arquivo> FileList = new List<Arquivo>();

        public int CountID
        {
            get { return countID; }
        }
        public Arquivo Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }

        public Arquivo CriaRaiz()
        {
            DataControl DC = new DataControl();
            Arquivo aux = new Arquivo("Raiz", null, DataControl.IsDirectory.D, countID++, -1);
            DC.Salva(aux.Nome, aux.IsDir, aux.Conteudo, null, aux.DirID, aux.PaiID);
            return aux;
        }
        public string CaminhoAteRaiz(Arquivo atual)
        {
            Arquivo aux;
            string retorno = atual.Nome;
            aux = atual;

            while (aux != raiz)
            {

                retorno = aux.Pai.Nome + "/" + retorno;
                aux = aux.Pai;
            }
            return retorno;
        }

        //Retorna o filho selecionado.
        public Arquivo ProcuraFilho(String NomeFilho, Arquivo Pai)
        {
            foreach (Arquivo arq in Pai.Filhos)
            {
                if (NomeFilho == arq.Nome)
                {
                    return arq;
                }

            }
            return null;
        }
        public Arquivo ProcuraID(long DirID)
        {
            foreach (Arquivo a in FileList)
            {
                if (a.DirID == DirID)
                    return a;
            }
            return null;
        }
        /// <summary>
        /// Insere um arquivo na árvore e salva no disco
        /// </summary>
        /// <param name="Nome">Nome do arquivo</param>
        /// <param name="Pai">Pai do arquivo</param>
        /// <param name="type">Se false: Arquivo. Se true: Diretório</param>
        public void Inserir(string Nome, Arquivo Pai, DataControl.IsDirectory type)
        {
            Arquivo aux = null;
            DataControl DC = new DataControl();
            //Se raiz não existir, cria uma nova raiz
            if (Pai == null)
            {

                Pai = CriaRaiz();
                Raiz = Pai;
                DC.Salva(Raiz.Nome, Raiz.IsDir, Raiz.Conteudo, null, Raiz.DirID, Raiz.PaiID);
            }
            //
            if (type == DataControl.IsDirectory.A)
            {
                aux = new Arquivo(Nome, Pai, DataControl.IsDirectory.A, -1);
                Pai.Filhos.Add(aux);
            }
            else if (type == DataControl.IsDirectory.D)
            {
                aux = new Arquivo(Nome, Pai, DataControl.IsDirectory.D, countID++);
                Pai.Filhos.Add(aux);
            }

            if (aux != null)
            {
                DC.Salva(aux.Nome, aux.IsDir, aux.Conteudo, Pai, aux.DirID, Pai.DirID);
            }
        }

        public Arquivo Inserir(string Nome, DataControl.IsDirectory type, long DirID, long PaiID)
        {
            Arquivo aux = null;
            DataControl DC = new DataControl();
            //Se raiz não existir, cria uma nova raiz

            aux = new Arquivo(Nome, null, type, DirID, PaiID);

            //
            if (type == DataControl.IsDirectory.A)
            {
                aux = new Arquivo(Nome, null, type, -1, PaiID);
                FileList.Add(aux);
            }
            else if (type == DataControl.IsDirectory.D)
            {
                aux = new Arquivo(Nome, null, type, countID++, PaiID);
                FileList.Add(aux);
            }

            return aux;
        }

        public void Deletar(Arquivo file)
        {
            //Remove a referencia para o arquivo filho
            file.Pai.Filhos.Remove(file);
            file = null;
        }
        /// <summary>
        /// Certifica se arquivo existe no diretorio espec
        /// 
        /// </summary>
        /// <param name="nome">Nome do arquivo</param>
        /// <param name="Pai">Arquivo pai</param>
        /// <returns></returns>
        public bool existeArquivo(string nome, Arquivo Pai)
        {
            foreach (Arquivo file in Pai.Filhos)
            {
                if (file.Nome == nome)
                    return true;
            }
            return false;
        }

        public void recuperaArvore()
        {

            DataControl DC = new DataControl();
            string Dados = DC.Recupera();
            string aux = "";
            string[] auxFiles;
            string[] aux1;

            bool novoArquivo = false;
            if (Dados == "")
            {
                Raiz = CriaRaiz();
                Dados = DC.Recupera();
            }
            if (Dados != "")
            {

                Dados = Dados.Trim('@');
                auxFiles = Dados.Split('@');

                foreach (string c in auxFiles)
                {
                    //if (novoArquivo && c != '@')
                    //{
                    //    aux += c;
                    //}
                    //if (c == '@' && !novoArquivo)
                    //{
                    //    novoArquivo = true;
                    //    aux = "";
                    //    //@|isdir|Nome|HashID|<conteudo>|

                    //}
                    //else if (c == '@' && novoArquivo)
                    if (c != "")
                    {
                        //novoArquivo = false;
                        aux = c.Trim('|');
                        aux1 = aux.Split('|');
                        DataControl.IsDirectory tip;
                        if (aux1[0] == DataControl.IsDirectory.D.ToString())
                        {
                            tip = DataControl.IsDirectory.D;

                        }
                        else
                        {
                            tip = DataControl.IsDirectory.A;

                        }

                        Arquivo arq = Inserir(aux1[1], tip, long.Parse(aux1[2]), long.Parse(aux1[3]));
                        if (arq.DirID == 0)
                        {
                            Raiz = arq;
                        }
                        foreach (Arquivo a in this.FileList)
                        {
                            if (a.DirID == arq.PaiID)
                            {
                                arq.Pai = a;
                                a.Filhos.Add(arq);
                            }
                        }
                    }
                }

            }
        }

    }
}
