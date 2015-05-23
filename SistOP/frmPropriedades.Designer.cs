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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkUsrRead = new System.Windows.Forms.CheckBox();
            this.chkUsrWrite = new System.Windows.Forms.CheckBox();
            this.chkUsrExec = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkGroupExec = new System.Windows.Forms.CheckBox();
            this.chkGroupWrite = new System.Windows.Forms.CheckBox();
            this.chkGroupRead = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkOthersExec = new System.Windows.Forms.CheckBox();
            this.chkOthersWrite = new System.Windows.Forms.CheckBox();
            this.chkOthersRead = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(15, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 289);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissões do Arquivo";
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
            // chkUsrRead
            // 
            this.chkUsrRead.AutoSize = true;
            this.chkUsrRead.Location = new System.Drawing.Point(6, 29);
            this.chkUsrRead.Name = "chkUsrRead";
            this.chkUsrRead.Size = new System.Drawing.Size(58, 17);
            this.chkUsrRead.TabIndex = 0;
            this.chkUsrRead.Text = "Leitura";
            this.chkUsrRead.UseVisualStyleBackColor = true;
            this.chkUsrRead.CheckedChanged += new System.EventHandler(this.chkUsrRead_CheckedChanged);
            // 
            // chkUsrWrite
            // 
            this.chkUsrWrite.AutoSize = true;
            this.chkUsrWrite.Location = new System.Drawing.Point(103, 29);
            this.chkUsrWrite.Name = "chkUsrWrite";
            this.chkUsrWrite.Size = new System.Drawing.Size(73, 17);
            this.chkUsrWrite.TabIndex = 0;
            this.chkUsrWrite.Text = "Gravação";
            this.chkUsrWrite.UseVisualStyleBackColor = true;
            this.chkUsrWrite.CheckedChanged += new System.EventHandler(this.chkUsrWrite_CheckedChanged);
            // 
            // chkUsrExec
            // 
            this.chkUsrExec.AutoSize = true;
            this.chkUsrExec.Location = new System.Drawing.Point(215, 29);
            this.chkUsrExec.Name = "chkUsrExec";
            this.chkUsrExec.Size = new System.Drawing.Size(74, 17);
            this.chkUsrExec.TabIndex = 0;
            this.chkUsrExec.Text = "Execução";
            this.chkUsrExec.UseVisualStyleBackColor = true;
            this.chkUsrExec.CheckedChanged += new System.EventHandler(this.chkUsrExec_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkGroupExec);
            this.groupBox3.Controls.Add(this.chkGroupWrite);
            this.groupBox3.Controls.Add(this.chkGroupRead);
            this.groupBox3.Location = new System.Drawing.Point(6, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 62);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permissões do Grupo";
            // 
            // chkGroupExec
            // 
            this.chkGroupExec.AutoSize = true;
            this.chkGroupExec.Location = new System.Drawing.Point(215, 29);
            this.chkGroupExec.Name = "chkGroupExec";
            this.chkGroupExec.Size = new System.Drawing.Size(74, 17);
            this.chkGroupExec.TabIndex = 0;
            this.chkGroupExec.Text = "Execução";
            this.chkGroupExec.UseVisualStyleBackColor = true;
            this.chkGroupExec.CheckedChanged += new System.EventHandler(this.chkGroupExec_CheckedChanged);
            // 
            // chkGroupWrite
            // 
            this.chkGroupWrite.AutoSize = true;
            this.chkGroupWrite.Location = new System.Drawing.Point(103, 29);
            this.chkGroupWrite.Name = "chkGroupWrite";
            this.chkGroupWrite.Size = new System.Drawing.Size(73, 17);
            this.chkGroupWrite.TabIndex = 0;
            this.chkGroupWrite.Text = "Gravação";
            this.chkGroupWrite.UseVisualStyleBackColor = true;
            this.chkGroupWrite.CheckedChanged += new System.EventHandler(this.chkGroupWrite_CheckedChanged);
            // 
            // chkGroupRead
            // 
            this.chkGroupRead.AutoSize = true;
            this.chkGroupRead.Location = new System.Drawing.Point(6, 29);
            this.chkGroupRead.Name = "chkGroupRead";
            this.chkGroupRead.Size = new System.Drawing.Size(58, 17);
            this.chkGroupRead.TabIndex = 0;
            this.chkGroupRead.Text = "Leitura";
            this.chkGroupRead.UseVisualStyleBackColor = true;
            this.chkGroupRead.CheckedChanged += new System.EventHandler(this.chkGroupRead_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkOthersExec);
            this.groupBox4.Controls.Add(this.chkOthersWrite);
            this.groupBox4.Controls.Add(this.chkOthersRead);
            this.groupBox4.Location = new System.Drawing.Point(6, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(295, 62);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Permissões  de Outros";
            // 
            // chkOthersExec
            // 
            this.chkOthersExec.AutoSize = true;
            this.chkOthersExec.Location = new System.Drawing.Point(215, 29);
            this.chkOthersExec.Name = "chkOthersExec";
            this.chkOthersExec.Size = new System.Drawing.Size(74, 17);
            this.chkOthersExec.TabIndex = 0;
            this.chkOthersExec.Text = "Execução";
            this.chkOthersExec.UseVisualStyleBackColor = true;
            this.chkOthersExec.CheckedChanged += new System.EventHandler(this.chkOthersExec_CheckedChanged);
            // 
            // chkOthersWrite
            // 
            this.chkOthersWrite.AutoSize = true;
            this.chkOthersWrite.Location = new System.Drawing.Point(103, 29);
            this.chkOthersWrite.Name = "chkOthersWrite";
            this.chkOthersWrite.Size = new System.Drawing.Size(73, 17);
            this.chkOthersWrite.TabIndex = 0;
            this.chkOthersWrite.Text = "Gravação";
            this.chkOthersWrite.UseVisualStyleBackColor = true;
            this.chkOthersWrite.CheckedChanged += new System.EventHandler(this.chkOthersWrite_CheckedChanged);
            // 
            // chkOthersRead
            // 
            this.chkOthersRead.AutoSize = true;
            this.chkOthersRead.Location = new System.Drawing.Point(6, 29);
            this.chkOthersRead.Name = "chkOthersRead";
            this.chkOthersRead.Size = new System.Drawing.Size(58, 17);
            this.chkOthersRead.TabIndex = 0;
            this.chkOthersRead.Text = "Leitura";
            this.chkOthersRead.UseVisualStyleBackColor = true;
            this.chkOthersRead.CheckedChanged += new System.EventHandler(this.chkOthersRead_CheckedChanged);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkOthersExec;
        private System.Windows.Forms.CheckBox chkOthersWrite;
        private System.Windows.Forms.CheckBox chkOthersRead;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkGroupExec;
        private System.Windows.Forms.CheckBox chkGroupWrite;
        private System.Windows.Forms.CheckBox chkGroupRead;
    }
}