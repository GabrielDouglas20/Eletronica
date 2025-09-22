namespace projeto_1
{
    partial class FrmMovimentacao
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
            this.cmbDeposito = new System.Windows.Forms.ComboBox();
            this.cmbPeca = new System.Windows.Forms.ComboBox();
            this.cmbTipMov = new System.Windows.Forms.ComboBox();
            this.dgvMovimentacoes = new System.Windows.Forms.DataGridView();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentacoes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDeposito
            // 
            this.cmbDeposito.FormattingEnabled = true;
            this.cmbDeposito.Location = new System.Drawing.Point(12, 22);
            this.cmbDeposito.Name = "cmbDeposito";
            this.cmbDeposito.Size = new System.Drawing.Size(121, 21);
            this.cmbDeposito.TabIndex = 0;
            // 
            // cmbPeca
            // 
            this.cmbPeca.FormattingEnabled = true;
            this.cmbPeca.Location = new System.Drawing.Point(192, 22);
            this.cmbPeca.Name = "cmbPeca";
            this.cmbPeca.Size = new System.Drawing.Size(121, 21);
            this.cmbPeca.TabIndex = 1;
            // 
            // cmbTipMov
            // 
            this.cmbTipMov.FormattingEnabled = true;
            this.cmbTipMov.Location = new System.Drawing.Point(356, 22);
            this.cmbTipMov.Name = "cmbTipMov";
            this.cmbTipMov.Size = new System.Drawing.Size(121, 21);
            this.cmbTipMov.TabIndex = 2;
            // 
            // dgvMovimentacoes
            // 
            this.dgvMovimentacoes.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimentacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentacoes.Location = new System.Drawing.Point(123, 117);
            this.dgvMovimentacoes.Name = "dgvMovimentacoes";
            this.dgvMovimentacoes.Size = new System.Drawing.Size(970, 569);
            this.dgvMovimentacoes.TabIndex = 3;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(926, 92);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(1007, 92);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 5;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Deposito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Peças";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Entrada/Saída";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(12, 79);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(121, 20);
            this.txtReferencia.TabIndex = 9;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(192, 79);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(121, 20);
            this.txtMotivo.TabIndex = 10;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(356, 79);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(121, 20);
            this.txtQuantidade.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Referencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Motivo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Quantidade";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.cmbDeposito);
            this.panel1.Controls.Add(this.cmbPeca);
            this.panel1.Controls.Add(this.btnRegistrar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.cmbTipMov);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtQuantidade);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMotivo);
            this.panel1.Controls.Add(this.txtReferencia);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 118);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 572);
            this.panel2.TabIndex = 16;
            // 
            // FrmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvMovimentacoes);
            this.Name = "FrmMovimentacao";
            this.Text = "FrmMovimentacao";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentacoes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDeposito;
        private System.Windows.Forms.ComboBox cmbPeca;
        private System.Windows.Forms.ComboBox cmbTipMov;
        private System.Windows.Forms.DataGridView dgvMovimentacoes;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}