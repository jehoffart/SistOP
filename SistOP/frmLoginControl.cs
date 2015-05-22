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
        public frmLoginControl()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Users Usr = new Users();
            if (Usr.Login(txtUsuario.Text, txtSenha.Text))
            {
                MessageBox.Show("Login Ok");
                new frmGerenciador().Show();
                
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
            new frmGerenciaUsuarios().Show();
        }
    }
}
