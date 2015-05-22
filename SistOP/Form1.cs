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
    public partial class Form1 : Form
    {
        string texto = "";
        private Arquivo dirAberto, FileAberto;
        Arvore FileSystem = new Arvore();
        Point localProximoArquivo;
        PictureBox Clicado;
        int Id = 0;
        public Form1()
        {
            InitializeComponent();
            FileSystem.recuperaArvore();
            dirAberto = FileSystem.Raiz;
            //ExibeArvore(dirAberto);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LimpaLayout(dirAberto, true);
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

                int countX = 0, countY = 0;
                foreach (Arquivo a in PastaAtual.Filhos)
                {
                    this.SuspendLayout();
                    var img1 = new System.Windows.Forms.PictureBox();
                    img1.Location = new System.Drawing.Point(12 + (82 + 12) * countX, 51 + (countY * (15 + 12 + 77)));
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
                    img1.Name = a.Nome;
                    img1.MouseClick += this.Abre;
                    img1.MouseEnter += img1_MouseEnter;
                    img1.MouseLeave += img1_MouseLeave;
                    img1.MouseDown += img1_MouseDown;
                    img1.MouseUp += img1_MouseUp;

                    this.Controls.Add(img1);

                    var lbl1 = new System.Windows.Forms.Label();

                    lbl1.Location = new System.Drawing.Point((img1.Location.X + 20), img1.Location.Y + img1.Size.Height + 10);

                    lbl1.Size = new System.Drawing.Size(82, 15);
                    lbl1.Text = a.Nome;
                    lbl1.Name = lbl1 + a.Nome;
                    lbl1.AutoSize = true;
                    this.Controls.Add(lbl1);
                    this.ResumeLayout(false);
                    if (img1.Location.X > this.Size.Width || img1.Location.X + img1.Size.Width > this.Size.Width)
                    {
                        countY++;
                        countX = 0;
                        img1.Location = new System.Drawing.Point(12 + (82 + 12) * countX, 51 + (countY * (15 + 12 + 77)));
                    }
                    countX++;

                }

                localProximoArquivo = new System.Drawing.Point(12 + (82 + 12) * countX, 51 + (countY * (15 + 12 + 77)));

                //this.SuspendLayout();
                //var img1 = new System.Windows.Forms.PictureBox();
                //img1.Location = new System.Drawing.Point(12, 51);
                //img1.Size = new System.Drawing.Size(82, 77);
                //img1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\folder.png");
                //img1.SizeMode = PictureBoxSizeMode.StretchImage; 
                //img1.BorderStyle = BorderStyle.Fixed3D;
                //this.Controls.Add(img1);

                //var lbl1 = new System.Windows.Forms.Label();

                //lbl1.Location = new System.Drawing.Point(img1.Size.Width/2, img1.Location.Y+img1.Size.Height+10);
                //lbl1.Size = new System.Drawing.Size(82, 15);
                //lbl1.Text = "Raiz1";
                //this.Controls.Add(lbl1);
                //this.ResumeLayout(false);
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
            if (pb.ImageLocation == Directory.GetCurrentDirectory() + @"\Resources\folder.png")
            {


                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(sender as Control, e.X, e.Y);
                    Clicado = sender as PictureBox;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    string nome = (sender as PictureBox).Name;
                    dirAberto = FileSystem.ProcuraFilho(nome, dirAberto);
                    LimpaLayout(dirAberto, true);
                    tsslabel.Text = FileSystem.CaminhoAteRaiz(dirAberto);
                }
            }
            else if (pb.ImageLocation == Directory.GetCurrentDirectory() + @"\Resources\file.png")
            {
                LimpaLayout(dirAberto, false);
                FileAberto = FileSystem.ProcuraFilho(pb.Name, dirAberto);
                GeraLayoutEdicao(FileAberto);
            }
        }

        private void GeraLayoutEdicao(Arquivo aberto)
        {
            this.SuspendLayout();
            var txtEdit = new TextBox();
            txtEdit.Name = aberto.Nome;
            txtEdit.Multiline = true;
            txtEdit.Size = new Size(600, 600);
            txtEdit.Location = new Point(12, 51);
            txtEdit.Text = aberto.Conteudo;
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
            btnSalvar.Click += btnSalvar_Click;
            Controls.Add(btnSalvar);

            var btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 20);
            btnCancelar.Location = new Point(btnSalvar.Location.X + 12 + btnSalvar.Size.Width, txtEdit.Size.Height + 12 + txtEdit.Location.Y);
            Controls.Add(btnCancelar);

            this.ResumeLayout(false);
        }

        void txtEdit_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            texto = txt.Text;
        }


        void btnSalvar_Click(object sender, EventArgs e)
        {
            BinaryChange BC = new BinaryChange();
            string teste = BC.toByte(texto);


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

        private void btnNovaPasta_Click(object sender, EventArgs e)
        {
            btnNovaPasta.Enabled = false;
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
                    btnNovaPasta.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Arquivo ou diretório já existente com esse nome");
                }
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Arquivo remove = FileSystem.ProcuraFilho(Clicado.Name, dirAberto);
            DataControl DC = new DataControl();
            DC.remove(remove.Nome, remove.IsDir, remove.Conteudo, remove, remove.DirID, remove.PaiID);
            LimpaLayout(dirAberto, true);
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
        //private void ExibeArvore(Arquivo raiz)
        //{
        //    treeView1.BeginUpdate();
        //    treeView1.Nodes.Add("Raiz");

        //    foreach (Arquivo a in raiz.Filhos)
        //    {
        //        treeView1.Nodes[0].Nodes.Add(a.Nome);
        //        ExibeArvore(treeView1.Nodes[0], a);
        //    }

        //    treeView1.EndUpdate();
        //}

        //private void ExibeArvore(TreeNode treeNode,Arquivo a)
        //{
        //    for (int i = 0; i < a.Filhos.Count; i++)
        //    {
        //        treeView1.Nodes[0].Nodes.Add(a.Nome);
        //        ExibeArvore(treeView1.Nodes[0], a.Filhos[i]);
        //    }           

        //}

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
            txt.KeyPress += txt_KeyPress;
            txt.Location = new System.Drawing.Point((img1.Location.X), img1.Location.Y + img1.Size.Height + 10);
            txt.Size = new System.Drawing.Size(img1.Size.Width, txt.Size.Height);
            this.Controls.Add(txt);
            txt.Focus();
            this.ResumeLayout(false);
        }





    }

}



