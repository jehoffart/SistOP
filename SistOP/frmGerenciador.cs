using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistOp.DataStructure;

namespace SistOp
{
    public partial class frmGerenciador : Form
    {
        string texto = "";
        private Arquivo dirAberto, FileAberto, ArquivoPesquisa;
        Arvore FileSystem = new Arvore();
        Point localProximoArquivo;
        PictureBox Clicado;
        ImageList IL = new ImageList();

        bool emPesquisa=false;


        public frmGerenciador()
        {
            InitializeComponent();
            FileSystem.recuperaArvore();
            dirAberto = FileSystem.Raiz;
            IL.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\file.png"));
            IL.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\folder.png"));
            twvListaPastas.ImageList = IL;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLoginControl frm = new frmLoginControl();
            frm.ShowDialog();
            LimpaLayout(dirAberto, true);
            CriaTree(FileSystem.Raiz);
        }

        private void CriaTree(Arquivo arquivo)
        {
            twvListaPastas.Nodes.Clear();
            twvListaPastas.Nodes.Add(arquivo.Nome);

            Tree(twvListaPastas.Nodes[0], arquivo);
        }

        private void Tree(TreeNode treeNode, Arquivo arquivo)
        {
            int count = 0;


            foreach (Arquivo a in arquivo.Filhos)
            {
                if (a.IsDir == DataControl.IsDirectory.D)
                {
                    treeNode.Nodes.Add(a.Nome, a.Nome, 1, 1);
                }
                else
                {
                    treeNode.Nodes.Add(a.Nome, a.Nome, 0, 0);
                }
                Tree(treeNode.Nodes[count++], a);
            }

        }


        private void LimpaLayout(Arquivo PastaAtual, bool redesenha)
        {
            bool Tiroutodos = false;
            this.SuspendLayout();
            while (!Tiroutodos)
            {
                Tiroutodos = true;
                foreach (Control c in this.Controls)
                {

                    if (c.GetType() == typeof(System.Windows.Forms.PictureBox))
                    {
                        this.Controls.Remove(c);
                        c.Dispose();
                        Tiroutodos = false;
                    }
                    else if (c.GetType() == typeof(System.Windows.Forms.Label))
                    {
                        this.Controls.Remove(c);
                        c.Dispose();
                        Tiroutodos = false;
                    }

                }
            }

            this.ResumeLayout(true);
            if (redesenha) DesenhaLayout(PastaAtual);
        }

        private void DesenhaLayout(Arquivo PastaAtual)
        {
            if (PastaAtual != null)
            {

                int countX = 0, countY = 0, minLoc = 212;
                foreach (Arquivo a in PastaAtual.Filhos)
                {
                    this.SuspendLayout();
                    var img1 = new System.Windows.Forms.PictureBox();
                    img1.Location = new System.Drawing.Point(minLoc + (82 + 12) * countX, 51 + (countY * (30 + 12 + 77)));
                    img1.Size = new System.Drawing.Size(82, 77);

                    if (a.IsDir == DataControl.IsDirectory.D)
                    {
                        img1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\folder.png");
                        img1.ImageLocation = (Directory.GetCurrentDirectory() + @"\Resources\folder.png");
                    }
                    else
                    {
                        img1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\file.png");
                        img1.ImageLocation = (Directory.GetCurrentDirectory() + @"\Resources\file.png");
                    }
                    img1.SizeMode = PictureBoxSizeMode.StretchImage;
                    img1.BorderStyle = BorderStyle.None;
                    if (emPesquisa)
                    {
                        img1.Name = "p" + a.DirID;
                    }
                    else
                    {
                        img1.Name = a.Nome;
                    }
                    img1.MouseClick += this.Abre;
                    img1.MouseEnter += img1_MouseEnter;
                    img1.MouseLeave += img1_MouseLeave;
                    img1.MouseDown += img1_MouseDown;
                    img1.MouseUp += img1_MouseUp;

                    this.Controls.Add(img1);

                    var lbl1 = new System.Windows.Forms.Label();



                    lbl1.Size = new System.Drawing.Size(82, 30);
                    lbl1.Text = a.Nome;
                    lbl1.Name = lbl1 + a.Nome;
                    lbl1.AutoSize = false;
                    lbl1.TextAlign = ContentAlignment.TopCenter;

                    this.Controls.Add(lbl1);
                    this.ResumeLayout(false);
                    if (img1.Location.X > this.Size.Width || img1.Location.X + img1.Size.Width > this.Size.Width)
                    {
                        countY++;
                        countX = 0;
                        img1.Location = new System.Drawing.Point(minLoc + (82 + 12) * countX, 51 + (countY * (30 + 12 + 77)));
                    }
                    countX++;
                    lbl1.Location = new System.Drawing.Point((img1.Location.X), img1.Location.Y + img1.Size.Height + 2);
                }

                localProximoArquivo = new System.Drawing.Point(minLoc + (82 + 12) * countX, 51 + (countY * (30 + 12 + 77)));

            }
        }

        void img1_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
        }

        void img1_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.Fixed3D;

        }

        void img1_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
        }

        void img1_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.FixedSingle;
        }
        public void Abre(object sender, MouseEventArgs e)
        {


            PictureBox pb = sender as PictureBox;
            if (!emPesquisa)
            {
                if (e.Button == MouseButtons.Right)
                {
                    contxtMenuStrip.Show(sender as Control, e.X, e.Y);
                    Clicado = sender as PictureBox;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (pb.ImageLocation == Directory.GetCurrentDirectory() + @"\Resources\folder.png")
                    {
                                           string nome = pb.Name;
                        dirAberto = FileSystem.ProcuraFilho(nome, dirAberto);
                        LimpaLayout(dirAberto, true);
                        tsslabel.Text = FileSystem.CaminhoAteRaiz(dirAberto);
                    }

                    else if (pb.ImageLocation == Directory.GetCurrentDirectory() + @"\Resources\file.png")
                    {
                        twvListaPastas.Visible = false;
                        LimpaLayout(dirAberto, false);
                        FileAberto = FileSystem.ProcuraFilho(pb.Name, dirAberto);
                        GeraLayoutEdicao(FileAberto);
                    }
                }
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    //contxtMenuStrip.Show(sender as Control, e.X, e.Y);
                    //Clicado = sender as PictureBox;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    string nome = (sender as PictureBox).Name;
                    long PesquisaID = long.Parse(nome.Trim(new char[] {'p'}));
                    bool isDir = false;
                    if (pb.ImageLocation == Directory.GetCurrentDirectory() + @"\Resources\folder.png")
                    {
                        

                        dirAberto = FileSystem.ProcuraID(PesquisaID);
                        isDir = true;
                        tsslabel.Text = FileSystem.CaminhoAteRaiz(dirAberto);
                    }

                    else if (pb.ImageLocation == Directory.GetCurrentDirectory() + @"\Resources\file.png")
                    {
                        twvListaPastas.Visible = false;
                        
                        FileAberto = FileSystem.ProcuraID(PesquisaID);
                        GeraLayoutEdicao(FileAberto);

                    }
                    emPesquisa = false;
                    LimpaLayout(dirAberto, isDir);
                }

            }
        }

        private void GeraLayoutEdicao(Arquivo aberto)
        {
            BinaryChange BC = new BinaryChange();
            this.SuspendLayout();
            var txtEdit = new TextBox();
            txtEdit.Name = aberto.Nome;
            txtEdit.Multiline = true;
            txtEdit.Size = new Size(600, 600);
            txtEdit.Name = "EditorTexto";
            txtEdit.Location = new Point(12, 51);
            txtEdit.Text = BC.toStr(aberto.Conteudo);
            txtEdit.TextChanged += txtEdit_TextChanged;
            this.Controls.Add(txtEdit);
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Enabled = false;
                }

            }


            var btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Size = new Size(100, 20);
            btnSalvar.Location = new Point(12, txtEdit.Size.Height + 12 + txtEdit.Location.Y);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Click += btnSalvar_Click;
            Controls.Add(btnSalvar);

            var btnFechar = new Button();
            btnFechar.Text = "Fechar";
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(100, 20);
            btnFechar.Location = new Point(btnSalvar.Location.X + 12 + btnSalvar.Size.Width, txtEdit.Size.Height + 12 + txtEdit.Location.Y);
            btnFechar.Click += btnFechar_Click;
            Controls.Add(btnFechar);

            this.ResumeLayout(false);
        }

        void btnFechar_Click(object sender, EventArgs e)
        {
            bool removeutodos = false;
            LimpaLayout(dirAberto, true);
            SuspendLayout();


            while (!removeutodos)
            {
                removeutodos = true;
                foreach (Control c in Controls)
                {


                    if (c.GetType() == typeof(Button) || c.GetType() == typeof(TextBox))
                    {
                        c.Enabled = true;
                        if (c.Name == "btnFechar" || c.Name == "btnSalvar" || c.Name == "EditorTexto")
                        {

                            Controls.Remove(c);
                            removeutodos = false;
                        }
                    }
                }
            }
            twvListaPastas.Visible = true;
        }




        void txtEdit_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            texto = txt.Text;
        }


        void btnSalvar_Click(object sender, EventArgs e)
        {
            DataControl DC = new DataControl();
            BinaryChange BC = new BinaryChange();
            string Hex = BC.toByte(texto);
            Arquivo aux = new Arquivo(FileAberto);
            FileAberto.Conteudo = Hex;
            FileAberto.UltimaAlteracao = DateTime.Now;
            DC.Atualiza(aux, FileAberto);


        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            LimpaLayout(dirAberto, true);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //    LimpaLayout(dirAberto,true);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (dirAberto.Pai != null)
            {
                dirAberto = dirAberto.Pai;
                tsslabel.Text = FileSystem.CaminhoAteRaiz(dirAberto);
                LimpaLayout(dirAberto, true);
            }

        }
        /// <summary>
        /// Ativa ou desativa os botões de comando
        /// </summary>
        /// <param name="Comando">False - Desativa; True - Ativa.</param>
        private void AtivaDesativaControls(bool Comando)
        {
            btnNovaPasta.Enabled = Comando;
            btnNewFile.Enabled = Comando;
            btnPesquisa.Enabled = Comando;
            btnVoltar.Enabled = Comando;
        }
        private void btnNovaPasta_Click(object sender, EventArgs e)
        {
            AtivaDesativaControls(false);
            this.SuspendLayout();

            var img1 = new System.Windows.Forms.PictureBox();
            img1.Location = new System.Drawing.Point(localProximoArquivo.X, localProximoArquivo.Y);
            img1.Size = new System.Drawing.Size(82, 77);

            img1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\folder.png");
            img1.SizeMode = PictureBoxSizeMode.StretchImage;
            img1.BorderStyle = BorderStyle.None;

            this.Controls.Add(img1);

            var txt = new System.Windows.Forms.TextBox();
            txt.Name = "txtNovaPasta";
            txt.KeyUp += txt_KeyUp;
            txt.KeyPress += txt_KeyPress;
            txt.Text = "Nova Pasta";

            txt.Location = new System.Drawing.Point((img1.Location.X), img1.Location.Y + img1.Size.Height + 10);
            txt.Size = new System.Drawing.Size(img1.Size.Width, txt.Size.Height);
            this.Controls.Add(txt);
            txt.Focus();
            this.ResumeLayout(false);
        }

        void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '@' || e.KeyChar == '|' || e.KeyChar == '<' || e.KeyChar == '>')
            {
                e.Handled = true;
                toolTip1.Show("Os Caracteres @ | < > não são permitidos", sender as Control);
            }
            else
            {
                toolTip1.Hide(sender as Control);
            }
        }

        void txt_KeyUp(object sender, KeyEventArgs e)
        {
            DataControl.IsDirectory isDir = DataControl.IsDirectory.D;
            TextBox txt = sender as TextBox;
            if (txt.Name == "txtNovoArquivo")
            {
                isDir = DataControl.IsDirectory.A;
            }
            else if (txt.Name == "txtNovaPasta")
            {
                isDir = DataControl.IsDirectory.D;
            }
            if (e.KeyCode == Keys.Enter)
            {

                if (FileSystem.Inserir(txt.Text, dirAberto, isDir))
                {
                    this.SuspendLayout();
                    this.Controls.Remove(txt);
                    txt.Dispose();
                    this.ResumeLayout(false);

                    LimpaLayout(dirAberto, true);
                    AtivaDesativaControls(true);
                    CriaTree(FileSystem.Raiz);
                }
                else
                {
                    MessageBox.Show("Arquivo ou diretório já existente com esse nome");
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.SuspendLayout();
                this.Controls.Remove(txt);
                txt.Dispose();
                this.ResumeLayout(false);
                LimpaLayout(dirAberto, true);
                AtivaDesativaControls(true);
                CriaTree(FileSystem.Raiz);

            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Arquivo remove = FileSystem.ProcuraFilho(Clicado.Name, dirAberto);
            DataControl DC = new DataControl();
            DC.remove(remove);
            LimpaLayout(dirAberto, true);
            CriaTree(FileSystem.Raiz);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                btnVoltar_Click(sender, e);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void btnNewFile_Click(object sender, EventArgs e)
        {
            btnNovaPasta.Enabled = false;
            this.SuspendLayout();

            var img1 = new System.Windows.Forms.PictureBox();
            img1.Location = new System.Drawing.Point(localProximoArquivo.X, localProximoArquivo.Y);
            img1.Size = new System.Drawing.Size(82, 77);

            img1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\file.png");
            img1.SizeMode = PictureBoxSizeMode.StretchImage;
            img1.BorderStyle = BorderStyle.None;

            this.Controls.Add(img1);

            var txt = new System.Windows.Forms.TextBox();
            txt.Name = "txtNovoArquivo";
            txt.KeyUp += txt_KeyUp;
            txt.MaxLength = 900000;
            txt.KeyPress += txt_KeyPress;
            txt.Location = new System.Drawing.Point((img1.Location.X), img1.Location.Y + img1.Size.Height + 10);
            txt.Size = new System.Drawing.Size(img1.Size.Width, txt.Size.Height);
            this.Controls.Add(txt);
            txt.Focus();
            this.ResumeLayout(false);
        }

        private void propriedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pb = Clicado;
            Arquivo Propriedades = FileSystem.ProcuraFilho(pb.Name, dirAberto);
            frmPropriedades frm = new frmPropriedades(Propriedades, FileSystem);
            frm.ShowDialog();
        }

        private void frmGerenciador_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            emPesquisa = true;
            ArquivoPesquisa = PesquisaArvore(dirAberto, txtPesquisa.Text);

            LimpaLayout(ArquivoPesquisa, true);
        }

        private Arquivo PesquisaArvore(Arquivo dirAberto, string p)
        {
            Arquivo aux = new Arquivo(dirAberto.Nome, null, dirAberto.IsDir, dirAberto.DirID, dirAberto.PaiID, dirAberto.Conteudo);

            pesquisar(dirAberto, p, aux);

            return aux;


        }

        private void pesquisar(Arquivo dirAberto, string p, Arquivo aux)
        {
            foreach (Arquivo a in dirAberto.Filhos)
            {
                if (a.Nome.Contains(p))
                {
                    aux.Filhos.Add(a);
                }

                pesquisar(a, p, aux);
            }

        }


    }

}



