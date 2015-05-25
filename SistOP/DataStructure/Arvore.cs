
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure
{
    public class Arvore
    {

        private Arquivo raiz;
        private int countID = 0;
        private List<Arquivo> FileList = new List<Arquivo>();

        internal List<Arquivo> FileList1
        {
            get { return FileList; }
            set { FileList = value; }
        }

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
            Arquivo aux = new Arquivo("Raiz", null, DataControl.IsDirectory.D, countID++, -1, "",new Permissions(",,"),DateTime.Now,DateTime.Now);
            DC.Salva(aux);
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
        /// Verifica se arquivo já existe, insere nó na arvore e salva em disco
        /// </summary>
        /// <param name="Nome">Nome dado ao arquivo</param>
        /// <param name="Pai">Pai do arquivo</param>
        /// <param name="type">Tipo de arquivo criado, D - Diretorio e A - Arquivo</param>
        /// <returns>retorna true para arquivo criado e false para arquivo já existente com o mesmo nome.</returns>
        public bool Inserir(string Nome, Arquivo Pai, DataControl.IsDirectory type)
        {
            Arquivo aux = null;
            DataControl DC = new DataControl();
            //Se raiz não existir, cria uma nova raiz

            if (existeArquivo(Nome, Pai))
            {
                return false;
            }
            if (Pai == null)
            {
                Pai = CriaRaiz();
                Raiz = Pai;
//                DC.Salva(Raiz.Nome, Raiz.IsDir, Raiz.Conteudo, null, Raiz.DirID, Raiz.PaiID, DateTime.Now, DateTime.Now);
            }
            //
            if (type == DataControl.IsDirectory.A)
            {
                aux = new Arquivo(Nome, Pai, DataControl.IsDirectory.A,countID++, Pai.DirID, "", new Permissions(), DateTime.Now, DateTime.Now);
                Pai.Filhos.Add(aux);
            }
            else if (type == DataControl.IsDirectory.D)
            {
                aux = new Arquivo(Nome, Pai, DataControl.IsDirectory.D, countID++, Pai.DirID, "", new Permissions(), DateTime.Now, DateTime.Now);
                Pai.Filhos.Add(aux);
            }

            if (aux != null)
            {
                FileList.Add(aux);
                DC.Salva(aux);
            }
            return true;
        }
        /// <summary>
        /// Inserção para recuperar a arvore de arquivos.
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="type"></param>
        /// <param name="DirID"></param>
        /// <param name="PaiID"></param>
        /// <param name="conteudo"></param>
        /// <param name="permissions"></param>
        /// <param name="Criacao"></param>
        /// <param name="Alteracao"></param>
        /// <returns></returns>
        public Arquivo Inserir(string Nome, DataControl.IsDirectory type, long DirID, long PaiID, string conteudo, Permissions permissions, DateTime Criacao, DateTime Alteracao)
        {
            Arquivo aux = null;
            DataControl DC = new DataControl();
            //Se raiz não existir, cria uma nova raiz

            //
            if (type == DataControl.IsDirectory.A)
            {
                aux = new Arquivo(Nome, null, type, DirID, PaiID, conteudo, permissions, Criacao, Alteracao);
                FileList.Add(aux);
            }
            else if (type == DataControl.IsDirectory.D)
            {
                aux = new Arquivo(Nome, null, type, DirID, PaiID, conteudo, permissions, Criacao, Alteracao);
                FileList.Add(aux);

            }
            if (countID < DirID)
                countID = (int)DirID;
            return aux;
        }
        //public Arvore PesquisaArquivos(Arquivo dirAtual)
        //{
        //    Arvore aux = new Arvore();



   
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

            if (Dados == "")
            {
                Raiz = CriaRaiz();
                Dados = DC.Recupera();
            }
            if (Dados != "")
            {
                Dados = Dados.Trim('@');
                auxFiles = Dados.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string c in auxFiles)
                {
                    aux = c.Trim('|');
                    aux1 = aux.Split('|');

                    Arquivo arq = Inserir(aux1[1], (DataControl.IsDirectory)Enum.Parse(typeof(DataControl.IsDirectory), 
                        aux1[0]), long.Parse(aux1[2]), long.Parse(aux1[3]), aux1[4].Trim(new char[] { '<', '>' }), 
                            new Permissions(aux1[5]),DateTime.Parse(aux1[6]),DateTime.Parse(aux1[7]));

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
                countID++;
            }
        }

    }
}
