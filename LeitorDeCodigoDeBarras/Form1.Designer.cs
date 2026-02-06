namespace LeitorDeCodigoDeBarras
{
    partial class Form1
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.picDebug = new System.Windows.Forms.PictureBox();
            this.TxCodBarra = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picDebug)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(13, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 31);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Cod Barra";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // picDebug
            // 
            this.picDebug.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDebug.Location = new System.Drawing.Point(13, 56);
            this.picDebug.Name = "picDebug";
            this.picDebug.Size = new System.Drawing.Size(947, 120);
            this.picDebug.TabIndex = 2;
            this.picDebug.TabStop = false;
            // 
            // TxCodBarra
            // 
            this.TxCodBarra.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TxCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxCodBarra.Location = new System.Drawing.Point(114, 16);
            this.TxCodBarra.Name = "TxCodBarra";
            this.TxCodBarra.ReadOnly = true;
            this.TxCodBarra.Size = new System.Drawing.Size(805, 28);
            this.TxCodBarra.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(925, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(972, 188);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.TxCodBarra);
            this.Controls.Add(this.picDebug);
            this.Controls.Add(this.btnSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Captura de codigo de barras";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picDebug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.PictureBox picDebug;
        private System.Windows.Forms.TextBox TxCodBarra;
        private System.Windows.Forms.Button btnClose;
    }
}

