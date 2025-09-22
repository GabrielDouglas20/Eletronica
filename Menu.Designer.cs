namespace projeto_1
{
    partial class Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Desligar = new System.Windows.Forms.Button();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.BtnCadUsu = new System.Windows.Forms.Button();
            this.BtnCadPeca = new System.Windows.Forms.Button();
            this.BtnMovi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBemVindo = new System.Windows.Forms.Label();
            this.btnNotificacoes = new System.Windows.Forms.Button();
            this.rtbRelatorio = new System.Windows.Forms.RichTextBox();
            this.BtnSair = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.BtnSair);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.Desligar);
            this.panel2.Controls.Add(this.BtnPesquisar);
            this.panel2.Controls.Add(this.BtnCadUsu);
            this.panel2.Controls.Add(this.BtnCadPeca);
            this.panel2.Controls.Add(this.BtnMovi);
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 580);
            this.panel2.TabIndex = 1;
            // 
            // Desligar
            // 
            this.Desligar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Desligar.FlatAppearance.BorderSize = 0;
            this.Desligar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Desligar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Desligar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Desligar.Image = global::projeto_1.Properties.Resources.off1;
            this.Desligar.Location = new System.Drawing.Point(3, 523);
            this.Desligar.Name = "Desligar";
            this.Desligar.Size = new System.Drawing.Size(137, 54);
            this.Desligar.TabIndex = 0;
            this.Desligar.UseVisualStyleBackColor = true;
            this.Desligar.Click += new System.EventHandler(this.Desligar_Click);
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.FlatAppearance.BorderSize = 0;
            this.BtnPesquisar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPesquisar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPesquisar.Location = new System.Drawing.Point(3, 183);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(137, 54);
            this.BtnPesquisar.TabIndex = 0;
            this.BtnPesquisar.Text = "Pesquisar / Filtrar";
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // BtnCadUsu
            // 
            this.BtnCadUsu.FlatAppearance.BorderSize = 0;
            this.BtnCadUsu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnCadUsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCadUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCadUsu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCadUsu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCadUsu.Location = new System.Drawing.Point(3, 123);
            this.BtnCadUsu.Name = "BtnCadUsu";
            this.BtnCadUsu.Size = new System.Drawing.Size(137, 54);
            this.BtnCadUsu.TabIndex = 0;
            this.BtnCadUsu.Text = "Cadastro - Usuário / Cliente";
            this.BtnCadUsu.UseVisualStyleBackColor = true;
            this.BtnCadUsu.Click += new System.EventHandler(this.BtnCadUsu_Click);
            // 
            // BtnCadPeca
            // 
            this.BtnCadPeca.FlatAppearance.BorderSize = 0;
            this.BtnCadPeca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnCadPeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCadPeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCadPeca.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCadPeca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCadPeca.Location = new System.Drawing.Point(3, 63);
            this.BtnCadPeca.Name = "BtnCadPeca";
            this.BtnCadPeca.Size = new System.Drawing.Size(137, 54);
            this.BtnCadPeca.TabIndex = 0;
            this.BtnCadPeca.Text = "Cadastro de Peças";
            this.BtnCadPeca.UseVisualStyleBackColor = true;
            this.BtnCadPeca.Click += new System.EventHandler(this.BtnCadPeca_Click);
            // 
            // BtnMovi
            // 
            this.BtnMovi.FlatAppearance.BorderSize = 0;
            this.BtnMovi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnMovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMovi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnMovi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMovi.Location = new System.Drawing.Point(3, 3);
            this.BtnMovi.Name = "BtnMovi";
            this.BtnMovi.Size = new System.Drawing.Size(137, 54);
            this.BtnMovi.TabIndex = 0;
            this.BtnMovi.Text = "Movimentação";
            this.BtnMovi.UseVisualStyleBackColor = true;
            this.BtnMovi.Click += new System.EventHandler(this.BtnMovi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "SISTEMA DE ELETRONICA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBemVindo
            // 
            this.lblBemVindo.AutoSize = true;
            this.lblBemVindo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblBemVindo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBemVindo.Location = new System.Drawing.Point(2, 15);
            this.lblBemVindo.Name = "lblBemVindo";
            this.lblBemVindo.Size = new System.Drawing.Size(299, 33);
            this.lblBemVindo.TabIndex = 2;
            this.lblBemVindo.Text = "Bem-vindo, Usuário.";
            this.lblBemVindo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNotificacoes
            // 
            this.btnNotificacoes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNotificacoes.FlatAppearance.BorderSize = 0;
            this.btnNotificacoes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNotificacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotificacoes.Location = new System.Drawing.Point(143, 99);
            this.btnNotificacoes.Name = "btnNotificacoes";
            this.btnNotificacoes.Size = new System.Drawing.Size(90, 23);
            this.btnNotificacoes.TabIndex = 3;
            this.btnNotificacoes.Text = "Notificações";
            this.btnNotificacoes.UseVisualStyleBackColor = false;
            this.btnNotificacoes.Click += new System.EventHandler(this.btnNotificacoes_Click);
            // 
            // rtbRelatorio
            // 
            this.rtbRelatorio.Location = new System.Drawing.Point(143, 121);
            this.rtbRelatorio.Name = "rtbRelatorio";
            this.rtbRelatorio.ReadOnly = true;
            this.rtbRelatorio.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbRelatorio.Size = new System.Drawing.Size(292, 238);
            this.rtbRelatorio.TabIndex = 4;
            this.rtbRelatorio.Text = "";
            // 
            // BtnSair
            // 
            this.BtnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSair.FlatAppearance.BorderSize = 0;
            this.BtnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSair.Location = new System.Drawing.Point(1125, 3);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(57, 32);
            this.BtnSair.TabIndex = 0;
            this.BtnSair.Text = "Sair";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.BtnSair.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.btnNotificacoes);
            this.Controls.Add(this.rtbRelatorio);
            this.Controls.Add(this.lblBemVindo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmmenu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Desligar;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Button BtnCadUsu;
        private System.Windows.Forms.Button BtnCadPeca;
        private System.Windows.Forms.Button BtnMovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBemVindo;
        private System.Windows.Forms.Button btnNotificacoes;
        private System.Windows.Forms.RichTextBox rtbRelatorio;
        private System.Windows.Forms.Button BtnSair;
    }
}