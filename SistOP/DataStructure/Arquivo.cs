﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistOp.DataStructure
{
    class Arquivo
    {
        #region Atributos

        private string nome;
        
        private DataControl.IsDirectory isDir;
         private string conteudo;
        private List<Arquivo> filhos;
        private Arquivo pai;

        private long dirID;
        private long paiID;

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
        /// Inicializa o arquivo
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
        }
        public Arquivo(string Nome, Arquivo pai, DataControl.IsDirectory Diretorio, long dirID, long paiID)
        {
            this.Nome = Nome;
            this.Pai = pai;
            this.isDir = Diretorio;
            this.Filhos = new List<Arquivo>();
            this.dirID = dirID;
            this.paiID = paiID;
        }
    }
}