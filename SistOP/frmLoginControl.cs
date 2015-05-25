using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistOp.DataStructure.Users;
namespace SistOp
{
    public partial class frmLoginControl : Form
    {
        private User isLoged;
        public string PermissaoPadrao;
        public User IsLoged
        {
            get { return isLoged; }
            set { isLoged = value; }
        }
        public frmLoginControl()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Users Usr = new Users();
            if (Usr.Login(txtUsuario.Text, txtSenha.Text))
            {
                IsLoged = Usr.Login(txtUsuario.Text);
                PermissaoPadrao = Usr.permissaoInicial();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha inválidos!");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void lnkNovoUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmGerenciaUsuarios().ShowDialog();
        }

        private void frmLoginControl_Load(object sender, EventArgs e)
        {

        }
    }
}
