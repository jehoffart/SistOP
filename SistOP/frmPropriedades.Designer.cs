namespace SistOp
{
    partial class frmPropriedades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDiretorio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCriacao = new System.Windows.Forms.Label();
            this.lblAlteracao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkUsrExec = new System.Windows.Forms.CheckBox();
            this.chkUsrWrite = new System.Windows.Forms.CheckBox();
            this.chkUsrRead = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(242, 427);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(80, 33);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do Arquivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diretório:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(110, 18);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(0, 13);
            this.lblNome.TabIndex = 1;
            // 
            // lblDiretorio
            // 
            this.lblDiretorio.AutoSize = true;
            this.lblDiretorio.Location = new System.Drawing.Point(110, 46);
            this.lblDiretorio.Name = "lblDiretorio";
            this.lblDiretorio.Size = new System.Drawing.Size(0, 13);
            this.lblDiretorio.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Data Criação";
            // 
            // lblCriacao
            // 
            this.lblCriacao.AutoSize = true;
            this.lblCriacao.Location = new System.Drawing.Point(110, 70);
            this.lblCriacao.Name = "lblCriacao";
            this.lblCriacao.Size = new System.Drawing.Size(0, 13);
            this.lblCriacao.TabIndex = 1;
            // 
            // lblAlteracao
            // 
            this.lblAlteracao.AutoSize = true;
            this.lblAlteracao.Location = new System.Drawing.Point(110, 98);
            this.lblAlteracao.Name = "lblAlteracao";
            this.lblAlteracao.Size = new System.Drawing.Size(0, 13);
            this.lblAlteracao.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Data Alteração";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstUsers);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(15, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 289);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissões do Arquivo";
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(6, 103);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(123, 173);
            this.lstUsers.TabIndex = 1;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkUsrExec);
            this.groupBox2.Controls.Add(this.chkUsrWrite);
            this.groupBox2.Controls.Add(this.chkUsrRead);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 62);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permissões do Usuario";
            // 
            // chkUsrExec
            // 
            this.chkUsrExec.AutoSize = true;
            this.chkUsrExec.Enabled = false;
            this.chkUsrExec.Location = new System.Drawing.Point(215, 29);
            this.chkUsrExec.Name = "chkUsrExec";
            this.chkUsrExec.Size = new System.Drawing.Size(74, 17);
            this.chkUsrExec.TabIndex = 0;
            this.chkUsrExec.Text = "Execução";
            this.chkUsrExec.UseVisualStyleBackColor = true;
            this.chkUsrExec.Click += new System.EventHandler(this.chkUsrExec_CheckedChanged);
            // 
            // chkUsrWrite
            // 
            this.chkUsrWrite.AutoSize = true;
            this.chkUsrWrite.Enabled = false;
            this.chkUsrWrite.Location = new System.Drawing.Point(103, 29);
            this.chkUsrWrite.Name = "chkUsrWrite";
            this.chkUsrWrite.Size = new System.Drawing.Size(73, 17);
            this.chkUsrWrite.TabIndex = 0;
            this.chkUsrWrite.Text = "Gravação";
            this.chkUsrWrite.UseVisualStyleBackColor = true;
            this.chkUsrWrite.Click += new System.EventHandler(this.chkUsrWrite_CheckedChanged);
            // 
            // chkUsrRead
            // 
            this.chkUsrRead.AutoSize = true;
            this.chkUsrRead.Enabled = false;
            this.chkUsrRead.Location = new System.Drawing.Point(6, 29);
            this.chkUsrRead.Name = "chkUsrRead";
            this.chkUsrRead.Size = new System.Drawing.Size(58, 17);
            this.chkUsrRead.TabIndex = 0;
            this.chkUsrRead.Text = "Leitura";
            this.chkUsrRead.UseVisualStyleBackColor = true;
            this.chkUsrRead.Click += new System.EventHandler(this.chkUsrRead_CheckedChanged);
            // 
            // frmPropriedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAlteracao);
            this.Controls.Add(this.lblDiretorio);
            this.Controls.Add(this.lblCriacao);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPropriedades";
            this.Text = "Propriedades do Arquivo";
            this.Load += new System.EventHandler(this.frmPropriedades_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDiretorio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCriacao;
        private System.Windows.Forms.Label lblAlteracao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkUsrExec;
        private System.Windows.Forms.CheckBox chkUsrWrite;
        private System.Windows.Forms.CheckBox chkUsrRead;
        private System.Windows.Forms.ListBox lstUsers;
    }
}