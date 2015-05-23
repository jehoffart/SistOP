using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistOp.DataStructure;
namespace SistOp
{
    public partial class frmPropriedades : Form
    {
        private Arquivo Propriedades;
        private Arvore FileSystem;
        private int Usr, Grp, Oth;
        public frmPropriedades()
        {
            InitializeComponent();
        }

        public frmPropriedades(Arquivo Propriedades, Arvore FileSystem)
        {
            InitializeComponent();
            Usr = Grp = Oth = 0;
            this.Propriedades = Propriedades;
            this.FileSystem = FileSystem;
        }
        public void CarregaDados()
        {
            this.Text += ": " + Propriedades.Nome;
            lblNome.Text = Propriedades.Nome;
            lblDiretorio.Text = FileSystem.CaminhoAteRaiz(Propriedades);
            lblAlteracao.Text = Propriedades.UltimaAlteracao.ToString("dd/MM/yyyy - HH:mm");
            lblCriacao.Text = Propriedades.UltimaAlteracao.ToString("dd/MM/yyyy - HH:mm");

        }
        private void frmPropriedades_Load(object sender, EventArgs e)
        {
            CarregaDados();
            CarregaPermissao(this.Propriedades);
        }
        private void CarregaPermissao(Arquivo Propriedades)
        {
            int i = 0, j = 0;
            string Perm = Propriedades.Permissao.ToString();
            string bin = "";
            while (j < 3)
            {
                i = int.Parse(Perm[j].ToString());
                while (i >= 2)
                {
                    bin = i % 2 + bin;
                    i /= 2;

                }
                bin = i + bin;
                j++;
            }
            if (bin[0] == '1') { chkUsrRead.Checked = true; } else { chkUsrRead.Checked = false; }
            if (bin[1] == '1') { chkUsrWrite.Checked = true; } else { chkUsrWrite.Checked = false; }
            if (bin[2] == '1') { chkUsrExec.Checked = true; } else { chkUsrExec.Checked = false; }

            if (bin[3] == '1') { chkGroupRead.Checked = true; } else { chkGroupRead.Checked = false; }
            if (bin[4] == '1') { chkGroupWrite.Checked = true; } else { chkGroupWrite.Checked = false; }
            if (bin[5] == '1') { chkGroupExec.Checked = true; } else { chkGroupExec.Checked = false; }

            if (bin[3] == '1') { chkOthersRead.Checked = true; } else { chkOthersRead.Checked = false; }
            if (bin[4] == '1') { chkOthersWrite.Checked = true; } else { chkOthersWrite.Checked = false; }
            if (bin[5] == '1') { chkOthersExec.Checked = true; } else { chkOthersExec.Checked = false; }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void chkUsrRead_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsrRead.Checked == true)
                Usr += 4;
            else
                Usr -= 4;

        }

        private void chkUsrWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsrWrite.Checked == true)
                Usr += 2;
            else
                Usr -= 2;

        }

        private void chkUsrExec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsrExec.Checked == true)
                Usr += 1;
            else
                Usr -= 1;
        }

        private void chkGroupRead_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGroupRead.Checked == true)
                Grp += 4;
            else
                Grp -= 4;

        }

        private void chkGroupWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGroupWrite.Checked == true)
                Grp += 2;
            else
                Grp -= 2;
        }

        private void chkGroupExec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGroupExec.Checked == true)
                Grp += 1;
            else
                Grp -= 1;
        }

        private void chkOthersRead_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOthersRead.Checked == true)
                Oth += 4;
            else
                Oth -= 4;
        }

        private void chkOthersWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOthersWrite.Checked == true)
                Oth += 2;
            else
                Oth -= 2;
        }

        private void chkOthersExec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOthersExec.Checked == true)
                Oth += 1;
            else
                Oth -= 1;
        }
        
    }
}
