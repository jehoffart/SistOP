using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure
{
    public class Arquivo
    {
        #region Atributos

        private string nome;
        private Permissions permissao;
        private DataControl.IsDirectory isDir;
        private string conteudo;
        private List<Arquivo> filhos;
        private Arquivo pai;
        private DateTime dataCriacao;
        private DateTime ultimaAlteracao;
        private long dirID;
        private long paiID;

        public DateTime UltimaAlteracao
        {
            get { return ultimaAlteracao; }
            set { ultimaAlteracao = value; }
        }
        public DateTime DataCriacao
        {
            get { return dataCriacao; }
            set { dataCriacao = value; }
        }
        public Permissions Permissao
        {
            get { return permissao; }
            set { permissao = value; }
        }

        /// <summary>
        /// Diretório onde se encontra o arquivo/Diretorio filho.
        /// </summary>
        public long PaiID
        {
            get { return paiID; }
            set { paiID = value; }
        }

        /// <summary>
        /// Identificador unico do diretório.
        /// </summary>
        public long DirID
        {
            get { return dirID; }
            set { dirID = value; }
        }

        /// <summary>
        /// Se diretório, informa quais os arquivos que existem neste nivel.
        /// </summary>
        public List<Arquivo> Filhos
        {
            get { return filhos; }
            set { filhos = value; }
        }

        /// <summary>
        /// Conteudo do arquivo.
        /// </summary>
        public string Conteudo
        {
            get { return conteudo; }
            set { conteudo = value; }
        }



        /// <summary>
        /// Arquivo pai (Diretório).
        /// </summary>
        public Arquivo Pai
        {
            get { return pai; }
            set { pai = value; }
        }

        /// <summary>
        /// Verfica se o arquivo é diretório.
        /// </summary>
        public DataControl.IsDirectory IsDir
        {
            get { return isDir; }
            set { isDir = value; }
        }

        /// <summary>
        /// Nome do arquivo.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        #endregion
        /// <summary>
        /// Inicializa o arquivo sem conteúdo
        /// </summary>
        /// <param name="Nome">Nome do arquivo</param>
        /// <param name="pai">Diretorio pai</param>
        /// <param name="Diretorio">verifica se é diretorio</param>
        public Arquivo(string Nome, Arquivo pai, DataControl.IsDirectory Diretorio, long dirID)
        {
            this.Nome = Nome;
            this.Pai = pai;
            this.isDir = Diretorio;
            this.Filhos = new List<Arquivo>();
            this.dirID = dirID;
            this.conteudo = "";

        }

        public Arquivo(string Nome, Arquivo pai, DataControl.IsDirectory Diretorio, long dirID, long paiID, string Conteudo)
        {
            this.Nome = Nome;
            this.Pai = pai;
            this.isDir = Diretorio;
            this.Filhos = new List<Arquivo>();
            this.dirID = dirID;
            this.paiID = paiID;
            this.conteudo = Conteudo;
        }
        public Arquivo(string Nome, Arquivo pai, DataControl.IsDirectory Diretorio, long dirID, long paiID, string Conteudo, Permissions permissao,DateTime Criacao, DateTime Alteracao)
        {
            this.Nome = Nome;
            this.Pai = pai;
            this.isDir = Diretorio;
            this.Filhos = new List<Arquivo>();
            this.dirID = dirID;
            this.paiID = paiID;
            this.conteudo = Conteudo;
            this.permissao = permissao;
            this.dataCriacao = Criacao;
            this.ultimaAlteracao = Alteracao;
        }
        public Arquivo(Arquivo Arquivo)
        {
            this.nome = Arquivo.Nome;
            this.Pai = Arquivo.Pai;
            this.isDir = Arquivo.isDir;
            this.Filhos = Arquivo.Filhos;
            this.dirID = Arquivo.dirID;
            this.paiID = Arquivo.paiID;
            this.conteudo = Arquivo.Conteudo;
            this.permissao = Arquivo.permissao;
            this.dataCriacao = Arquivo.DataCriacao;
            this.ultimaAlteracao = Arquivo.ultimaAlteracao;
            
        }


    }
}
