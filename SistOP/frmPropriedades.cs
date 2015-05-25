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
using SistOp.DataStructure.Users;
namespace SistOp
{
    public partial class frmPropriedades : Form
    {
        private Arquivo Propriedades;
        private Arquivo atualizado;
        private Permissions PM;
        public Arquivo Atualizado
        {
            get { return atualizado; }
            set { atualizado = value; }
        }
        private Arvore FileSystem;

        private User user;
        private User SelectedUser;
        public frmPropriedades()
        {
            InitializeComponent();
        }

        public frmPropriedades(Arquivo Propriedades, Arvore FileSystem, User User)
        {
            InitializeComponent();
            this.Propriedades = Propriedades;
            this.atualizado = new Arquivo(Propriedades);
            PM = new Permissions(Propriedades.Permissao.ToString());
            this.atualizado.Permissao = PM;
            this.FileSystem = FileSystem;
            this.user = User;
            //AtivaChecksBox(user.isAdmin());
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
            CarregaUsers();

        }

        private void AtivaChecksBox(bool func)
        {
            chkUsrExec.Enabled = func;
            chkUsrRead.Enabled = func;
            chkUsrWrite.Enabled = func;
        }

        private void CarregaUsers()
        {
            Users Usr = new Users();
            foreach (User u in Usr.Usuarios)
            {
                lstUsers.Items.Add(u);
            }

        }
        private void CarregaPermissao()
        {
            chkUsrRead.Checked = Propriedades.Permissao.Permite(SelectedUser.Id, Permissions.TiposAcesso.R);
            chkUsrWrite.Checked = Propriedades.Permissao.Permite(SelectedUser.Id, Permissions.TiposAcesso.W);
            chkUsrExec.Checked = Propriedades.Permissao.Permite(SelectedUser.Id, Permissions.TiposAcesso.E);
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (user.isAdmin())
                Salva();
            this.Close();
        }

        private void Salva()
        {
            DataControl DC = new DataControl();
            atualizado.Permissao = PM;
            DC.Atualiza(Propriedades, atualizado);
            Propriedades = atualizado;
        }

        private void chkUsrRead_CheckedChanged(object sender, EventArgs e)
        {
            PM.AlteraPermissions(SelectedUser.Id, Permissions.TiposAcesso.R);
        }

        private void chkUsrWrite_CheckedChanged(object sender, EventArgs e)
        {
            PM.AlteraPermissions(SelectedUser.Id, Permissions.TiposAcesso.W);
        }

        private void chkUsrExec_CheckedChanged(object sender, EventArgs e)
        {
            PM.AlteraPermissions(SelectedUser.Id, Permissions.TiposAcesso.E);
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (atualizado.Permissao != null && user.isAdmin())
                Salva();
            SelectedUser = lstUsers.SelectedItem as User;
            CarregaPermissao();
            AtivaChecksBox(user.isAdmin());
        }




    }
}
