namespace projeto_1
{
    partial class FrmCadastro
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnome = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtcargo = new System.Windows.Forms.TextBox();
            this.txtcpf = new System.Windows.Forms.MaskedTextBox();
            this.txttelefone = new System.Windows.Forms.MaskedTextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtendereco = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.AskCpf = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSair = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Desligar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOME";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "E-MAIL";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(456, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "TELEFONE";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(311, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CPF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(311, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CARGO";
            // 
            // txtnome
            // 
            this.txtnome.Location = new System.Drawing.Point(12, 28);
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(262, 20);
            this.txtnome.TabIndex = 5;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(15, 80);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(262, 20);
            this.txtemail.TabIndex = 6;
            // 
            // txtcargo
            // 
            this.txtcargo.Location = new System.Drawing.Point(314, 28);
            this.txtcargo.Name = "txtcargo";
            this.txtcargo.Size = new System.Drawing.Size(100, 20);
            this.txtcargo.TabIndex = 9;
            // 
            // txtcpf
            // 
            this.txtcpf.Location = new System.Drawing.Point(314, 80);
            this.txtcpf.Mask = "000.000.000.-00";
            this.txtcpf.Name = "txtcpf";
            this.txtcpf.Size = new System.Drawing.Size(100, 20);
            this.txtcpf.TabIndex = 10;
            // 
            // txttelefone
            // 
            this.txttelefone.Location = new System.Drawing.Point(459, 28);
            this.txttelefone.Mask = "(99) 00000-0000";
            this.txttelefone.Name = "txttelefone";
            this.txttelefone.Size = new System.Drawing.Size(94, 20);
            this.txttelefone.TabIndex = 11;
            this.txttelefone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txttelefone_MaskInputRejected);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Location = new System.Drawing.Point(0, 470);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(121, 42);
            this.btnEntrar.TabIndex = 12;
            this.btnEntrar.Text = "VOLTAR";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // txtsenha
            // 
            this.txtsenha.Location = new System.Drawing.Point(459, 80);
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.Size = new System.Drawing.Size(94, 20);
            this.txtsenha.TabIndex = 14;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(0, 0);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(121, 49);
            this.btnCadastrar.TabIndex = 15;
            this.btnCadastrar.Text = "CADASTRAR";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(592, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "ENDEREÇO";
            // 
            // txtendereco
            // 
            this.txtendereco.Location = new System.Drawing.Point(595, 28);
            this.txtendereco.Name = "txtendereco";
            this.txtendereco.Size = new System.Drawing.Size(100, 20);
            this.txtendereco.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(123, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(962, 572);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(819, 90);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(91, 23);
            this.btnPesquisar.TabIndex = 19;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(916, 56);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 20;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.Location = new System.Drawing.Point(997, 54);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 21;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // AskCpf
            // 
            this.AskCpf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AskCpf.Location = new System.Drawing.Point(916, 91);
            this.AskCpf.Name = "AskCpf";
            this.AskCpf.Size = new System.Drawing.Size(156, 20);
            this.AskCpf.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(456, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "SENHA";
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnSair);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.btnDeletar);
            this.panel1.Controls.Add(this.AskCpf);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Controls.Add(this.txtnome);
            this.panel1.Controls.Add(this.txtcargo);
            this.panel1.Controls.Add(this.txtendereco);
            this.panel1.Controls.Add(this.txtcpf);
            this.panel1.Controls.Add(this.txttelefone);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtemail);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtsenha);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 118);
            this.panel1.TabIndex = 23;
            // 
            // BtnSair
            // 
            this.BtnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSair.FlatAppearance.BorderSize = 0;
            this.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSair.Location = new System.Drawing.Point(985, 3);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(87, 39);
            this.BtnSair.TabIndex = 16;
            this.BtnSair.Text = "LOGIN";
            this.BtnSair.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(595, 80);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(729, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "DATA DE ADMISSÃO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(592, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "DATA DE NASCIMENTO";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(732, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Desligar);
            this.panel2.Controls.Add(this.btnCadastrar);
            this.panel2.Controls.Add(this.btnEntrar);
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 572);
            this.panel2.TabIndex = 24;
            // 
            // Desligar
            // 
            this.Desligar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Desligar.FlatAppearance.BorderSize = 0;
            this.Desligar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Desligar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Desligar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Desligar.Image = global::projeto_1.Properties.Resources.off1;
            this.Desligar.Location = new System.Drawing.Point(-1, 513);
            this.Desligar.Name = "Desligar";
            this.Desligar.Size = new System.Drawing.Size(122, 54);
            this.Desligar.TabIndex = 25;
            this.Desligar.UseVisualStyleBackColor = true;
            this.Desligar.Click += new System.EventHandler(this.Desligar_Click);
            // 
            // FrmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 690);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtcargo;
        private System.Windows.Forms.MaskedTextBox txtcpf;
        private System.Windows.Forms.MaskedTextBox txttelefone;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtendereco;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.MaskedTextBox AskCpf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button Desligar;
    }
}

