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
        Arvore FileSystem = new Arvore();
        public Form1()
        {
            InitializeComponent();
            FileSystem.recuperaArvore();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileSystem.Inserir("Teste1", FileSystem.Raiz, DataControl.IsDirectory.D);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataControl DC = new DataControl();
            MessageBox.Show(DC.Recupera());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesenhaLayout(null);
        }

        private void DesenhaLayout(Arquivo PastaAtual)
        {
            this.SuspendLayout();
            var img1 = new System.Windows.Forms.PictureBox();
            img1.Location = new System.Drawing.Point(12, 51);
            img1.Size = new System.Drawing.Size(82, 77);
            img1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\folder.png");
            img1.SizeMode = PictureBoxSizeMode.StretchImage; 
            img1.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(img1);

            var lbl1 = new System.Windows.Forms.Label();

            lbl1.Location = new System.Drawing.Point(img1.Size.Width/2, img1.Location.Y+img1.Size.Height+10);
            lbl1.Size = new System.Drawing.Size(82, 15);
            lbl1.Text = "Raiz";
            this.Controls.Add(lbl1);
            this.ResumeLayout(false);
        }

    }
}



