namespace SistOp
{
    partial class frmGerenciador
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
            this.components = new System.ComponentModel.Container();
            this.btnNovaPasta = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.sstrip = new System.Windows.Forms.StatusStrip();
            this.tsslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contxtMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.twvListaPastas = new System.Windows.Forms.TreeView();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.propriedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sstrip.SuspendLayout();
            this.contxtMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNovaPasta
            // 
            this.btnNovaPasta.Location = new System.Drawing.Point(693, 12);
            this.btnNovaPasta.Name = "btnNovaPasta";
            this.btnNovaPasta.Size = new System.Drawing.Size(75, 23);
            this.btnNovaPasta.TabIndex = 0;
            this.btnNovaPasta.Text = "Nova Pasta";
            this.btnNovaPasta.UseVisualStyleBackColor = true;
            this.btnNovaPasta.Click += new System.EventHandler(this.btnNovaPasta_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(867, 12);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 0;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(12, 12);
            this.txtCaminho.MaxLength = 32171;
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(638, 20);
            this.txtCaminho.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(656, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // sstrip
            // 
            this.sstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslabel});
            this.sstrip.Location = new System.Drawing.Point(0, 486);
            this.sstrip.Name = "sstrip";
            this.sstrip.Size = new System.Drawing.Size(1189, 22);
            this.sstrip.TabIndex = 3;
            this.sstrip.Text = "statusStrip1";
            // 
            // tsslabel
            // 
            this.tsslabel.Name = "tsslabel";
            this.tsslabel.Size = new System.Drawing.Size(33, 17);
            this.tsslabel.Text = "Raiz/";
            // 
            // contxtMenuStrip
            // 
            this.contxtMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirToolStripMenuItem,
            this.toolStripMenuItem1,
            this.propriedadesToolStripMenuItem});
            this.contxtMenuStrip.Name = "contextMenuStrip1";
            this.contxtMenuStrip.Size = new System.Drawing.Size(144, 54);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.excluirToolStripMenuItem_Click);
            // 
            // twvListaPastas
            // 
            this.twvListaPastas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.twvListaPastas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.twvListaPastas.Location = new System.Drawing.Point(12, 38);
            this.twvListaPastas.Name = "twvListaPastas";
            this.twvListaPastas.Size = new System.Drawing.Size(200, 432);
            this.twvListaPastas.TabIndex = 4;
            this.twvListaPastas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnNewFile
            // 
            this.btnNewFile.Location = new System.Drawing.Point(774, 12);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(87, 23);
            this.btnNewFile.TabIndex = 5;
            this.btnNewFile.Text = "Novo Arquivo";
            this.btnNewFile.UseVisualStyleBackColor = true;
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // propriedadesToolStripMenuItem
            // 
            this.propriedadesToolStripMenuItem.Name = "propriedadesToolStripMenuItem";
            this.propriedadesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.propriedadesToolStripMenuItem.Text = "Propriedades";
            this.propriedadesToolStripMenuItem.Click += new System.EventHandler(this.propriedadesToolStripMenuItem_Click);
            // 
            // frmGerenciador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 508);
            this.Controls.Add(this.btnNewFile);
            this.Controls.Add(this.twvListaPastas);
            this.Controls.Add(this.sstrip);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtCaminho);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnNovaPasta);
            this.Name = "frmGerenciador";
            this.Text = "Gerenciador de Arquivos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximumSizeChanged += new System.EventHandler(this.Form1_ResizeEnd);
            this.MinimumSizeChanged += new System.EventHandler(this.Form1_ResizeEnd);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGerenciador_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.sstrip.ResumeLayout(false);
            this.sstrip.PerformLayout();
            this.contxtMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNovaPasta;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.StatusStrip sstrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel;
        private System.Windows.Forms.ContextMenuStrip contxtMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TreeView twvListaPastas;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propriedadesToolStripMenuItem;
    }
}

