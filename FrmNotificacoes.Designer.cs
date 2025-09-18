namespace projeto_1
{
    partial class FrmNotificacoes
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
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnMarcarLida = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.dgvNotificacoes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(552, 123);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 0;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnMarcarLida
            // 
            this.btnMarcarLida.Location = new System.Drawing.Point(552, 198);
            this.btnMarcarLida.Name = "btnMarcarLida";
            this.btnMarcarLida.Size = new System.Drawing.Size(75, 23);
            this.btnMarcarLida.TabIndex = 1;
            this.btnMarcarLida.Text = "Marcar lida";
            this.btnMarcarLida.UseVisualStyleBackColor = true;
            this.btnMarcarLida.Click += new System.EventHandler(this.btnMarcarLida_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(552, 268);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // dgvNotificacoes
            // 
            this.dgvNotificacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotificacoes.Location = new System.Drawing.Point(68, 123);
            this.dgvNotificacoes.Name = "dgvNotificacoes";
            this.dgvNotificacoes.Size = new System.Drawing.Size(478, 168);
            this.dgvNotificacoes.TabIndex = 3;
            // 
            // FrmNotificacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 450);
            this.Controls.Add(this.dgvNotificacoes);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnMarcarLida);
            this.Controls.Add(this.btnAtualizar);
            this.Name = "FrmNotificacoes";
            this.Text = "FrmNotificacoes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnMarcarLida;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dgvNotificacoes;
    }
}