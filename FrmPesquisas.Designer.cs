namespace projeto_1
{
    partial class FrmPesquisas
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
            this.BtnPesquisarUsuarioP = new System.Windows.Forms.Button();
            this.dataGridViewUsuP = new System.Windows.Forms.DataGridView();
            this.MaskUsuarioP = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPesquisarPecas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maskePecaP = new System.Windows.Forms.MaskedTextBox();
            this.dataGridViewPecasP = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPecasP)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPesquisarUsuarioP
            // 
            this.BtnPesquisarUsuarioP.Location = new System.Drawing.Point(146, 92);
            this.BtnPesquisarUsuarioP.Name = "BtnPesquisarUsuarioP";
            this.BtnPesquisarUsuarioP.Size = new System.Drawing.Size(75, 23);
            this.BtnPesquisarUsuarioP.TabIndex = 0;
            this.BtnPesquisarUsuarioP.Text = "Pesquisar";
            this.BtnPesquisarUsuarioP.UseVisualStyleBackColor = true;
            this.BtnPesquisarUsuarioP.Click += new System.EventHandler(this.BtnPesquisarUsuarioP_Click);
            // 
            // dataGridViewUsuP
            // 
            this.dataGridViewUsuP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsuP.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsuP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuP.Location = new System.Drawing.Point(143, 117);
            this.dataGridViewUsuP.Name = "dataGridViewUsuP";
            this.dataGridViewUsuP.Size = new System.Drawing.Size(942, 234);
            this.dataGridViewUsuP.TabIndex = 1;
            this.dataGridViewUsuP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuP_CellContentClick);
            // 
            // MaskUsuarioP
            // 
            this.MaskUsuarioP.Location = new System.Drawing.Point(227, 95);
            this.MaskUsuarioP.Name = "MaskUsuarioP";
            this.MaskUsuarioP.Size = new System.Drawing.Size(100, 20);
            this.MaskUsuarioP.TabIndex = 2;
            this.MaskUsuarioP.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MaskUsuarioP_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "USUARIO";
            // 
            // BtnPesquisarPecas
            // 
            this.BtnPesquisarPecas.Location = new System.Drawing.Point(3, 92);
            this.BtnPesquisarPecas.Name = "BtnPesquisarPecas";
            this.BtnPesquisarPecas.Size = new System.Drawing.Size(75, 23);
            this.BtnPesquisarPecas.TabIndex = 4;
            this.BtnPesquisarPecas.Text = "Pesquisa";
            this.BtnPesquisarPecas.UseVisualStyleBackColor = true;
            this.BtnPesquisarPecas.Click += new System.EventHandler(this.BtnPesquisarPecas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(403, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "PEÇAS";
            // 
            // maskePecaP
            // 
            this.maskePecaP.Location = new System.Drawing.Point(84, 95);
            this.maskePecaP.Name = "maskePecaP";
            this.maskePecaP.Size = new System.Drawing.Size(100, 20);
            this.maskePecaP.TabIndex = 6;
            this.maskePecaP.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskePecaP_MaskInputRejected);
            // 
            // dataGridViewPecasP
            // 
            this.dataGridViewPecasP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPecasP.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPecasP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPecasP.Location = new System.Drawing.Point(143, 467);
            this.dataGridViewPecasP.Name = "dataGridViewPecasP";
            this.dataGridViewPecasP.Size = new System.Drawing.Size(942, 216);
            this.dataGridViewPecasP.TabIndex = 7;
            this.dataGridViewPecasP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPecasP_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.MaskUsuarioP);
            this.panel1.Controls.Add(this.BtnPesquisarUsuarioP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 118);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.BtnVoltar);
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 580);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.BtnPesquisarPecas);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.maskePecaP);
            this.panel3.Location = new System.Drawing.Point(143, 350);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(961, 118);
            this.panel3.TabIndex = 10;
            // 
            // BtnVoltar
            // 
            this.BtnVoltar.FlatAppearance.BorderSize = 0;
            this.BtnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVoltar.Location = new System.Drawing.Point(3, 500);
            this.BtnVoltar.Name = "BtnVoltar";
            this.BtnVoltar.Size = new System.Drawing.Size(138, 63);
            this.BtnVoltar.TabIndex = 0;
            this.BtnVoltar.Text = "VOLTAR";
            this.BtnVoltar.UseVisualStyleBackColor = true;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // FrmPesquisas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 681);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewPecasP);
            this.Controls.Add(this.dataGridViewUsuP);
            this.Name = "FrmPesquisas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPesquisas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPecasP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPesquisarUsuarioP;
        private System.Windows.Forms.DataGridView dataGridViewUsuP;
        private System.Windows.Forms.MaskedTextBox MaskUsuarioP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnPesquisarPecas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskePecaP;
        private System.Windows.Forms.DataGridView dataGridViewPecasP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnVoltar;
    }
}