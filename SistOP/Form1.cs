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

        private Arquivo dirAberto;
        Arvore FileSystem = new Arvore();
        int Id = 0;
        public Form1()
        {
            InitializeComponent();
            FileSystem.recuperaArvore();
            dirAberto = FileSystem.Raiz;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LimpaLayout(dirAberto);
        }
        private void LimpaLayout(Arquivo PastaAtual)
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
            DesenhaLayout(PastaAtual);
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
                    if (img1.Location.X > this.Size.Width || img1.Location.X + img1.Size.Width > this.Size.Width)
                    {
                        countY++;
                        countX = 0;
                        img1.Location = new System.Drawing.Point(12 + (82 + 12) * countX, 51 + (countY * (15 + 12 + 77)));
                    }
                    img1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\folder.png");
                    img1.SizeMode = PictureBoxSizeMode.StretchImage;
                    img1.BorderStyle = BorderStyle.Fixed3D;
                    img1.Name = a.Nome;
                    img1.Click += new System.EventHandler(this.AbrePasta);
                    this.Controls.Add(img1);

                    var lbl1 = new System.Windows.Forms.Label();

                    lbl1.Location = new System.Drawing.Point((img1.Location.X + 20), img1.Location.Y + img1.Size.Height + 10);
                    lbl1.Size = new System.Drawing.Size(82, 15);
                    lbl1.Text = a.Nome;
                    lbl1.Name = lbl1 + a.Nome;
                    this.Controls.Add(lbl1);
                    this.ResumeLayout(false);
                    countX++;

                }


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
        public void AbrePasta(object sender, System.EventArgs e)
        {
            string nome = (sender as PictureBox).Name;
            dirAberto = FileSystem.ProcuraFilho(nome, dirAberto);
            LimpaLayout(dirAberto);
            tsslabel.Text = FileSystem.CaminhoAteRaiz(dirAberto);
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            LimpaLayout(dirAberto);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //    LimpaLayout(dirAberto);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (dirAberto.Pai != null)
            {
                dirAberto = dirAberto.Pai;
                LimpaLayout(dirAberto);
            }

        }

        private void btnNovaPasta_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            var txt = new System.Windows.Forms.TextBox();
            txt.Name = "txtNovaPasta";
            txt.KeyUp += txt_KeyUp;

            this.Controls.Add(txt);

            this.ResumeLayout(false);
        }

        void txt_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (e.KeyCode== Keys.Enter)
            
           {
                
                FileSystem.Inserir(txt.Text, dirAberto, DataControl.IsDirectory.D);
                this.SuspendLayout();
                this.Controls.Remove(txt);
                txt.Dispose();
                this.ResumeLayout(false);
                LimpaLayout(dirAberto);
            }

        }

    }

}



