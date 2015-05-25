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
    public partial class frmGerenciaUsuarios : Form
    {
        Users Us = new Users();
        User Selected;
        
        public bool Novo { get; set; }
        public frmGerenciaUsuarios()
        {
            InitializeComponent();
        }

        private void frmGerenciaUsuarios_Load(object sender, EventArgs e)
        {
            CarregaLista();

        }
        private void CarregaLista()
        {
            lstCadastrados.Items.Clear();
            foreach (User user in Us.Usuarios)
            {
                lstCadastrados.Items.Add(user);
            }
        }
        private void CarregaCampos()
        {
            txtLogin.Text = Selected.Usuario;
            chkAdmin.Checked = Selected.isAdmin();

        }
        private void lstCadastrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected = (User)lstCadastrados.SelectedItem;
            CarregaCampos();
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            txtNovaSenha.Enabled = true;
            txtSenhaAtual.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Novo)
            {


                if (Us.Login(Selected.Usuario, txtSenhaAtual.Text))
                {

                    Us.AtualizaUsuario(Selected, txtNovaSenha.Text);
                    CarregaLista();
                }
                else
                { MessageBox.Show("Senha Atual não é valida."); }
            }
            else
            {
                if (!Us.CadastrarNovoUser(txtLogin.Text, txtNovaSenha.Text))
                {
                    MessageBox.Show("Usuário já cadastrado");

                }
                else
                {
                    MessageBox.Show("Usuario Cadastrado com sucesso.");
                    CarregaLista();

                }


            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Novo = true;
            txtNovaSenha.Enabled = true;
            txtNovaSenha.Text = "";
            txtLogin.Text = "";
            txtLogin.Focus();


        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
