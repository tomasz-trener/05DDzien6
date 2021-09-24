
namespace P04AplikacjaOkienkowa
{
    partial class Form1
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
            this.btnWykonajPolecenie = new System.Windows.Forms.Button();
            this.txtPolecenieSQL = new System.Windows.Forms.TextBox();
            this.dgvDane = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWykonajPolecenie
            // 
            this.btnWykonajPolecenie.Location = new System.Drawing.Point(12, 12);
            this.btnWykonajPolecenie.Name = "btnWykonajPolecenie";
            this.btnWykonajPolecenie.Size = new System.Drawing.Size(138, 23);
            this.btnWykonajPolecenie.TabIndex = 0;
            this.btnWykonajPolecenie.Text = "Wykonaj Polecenie SQL";
            this.btnWykonajPolecenie.UseVisualStyleBackColor = true;
            this.btnWykonajPolecenie.Click += new System.EventHandler(this.btnWykonajPolecenie_Click);
            // 
            // txtPolecenieSQL
            // 
            this.txtPolecenieSQL.Location = new System.Drawing.Point(156, 12);
            this.txtPolecenieSQL.Name = "txtPolecenieSQL";
            this.txtPolecenieSQL.Size = new System.Drawing.Size(502, 20);
            this.txtPolecenieSQL.TabIndex = 1;
            // 
            // dgvDane
            // 
            this.dgvDane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDane.Location = new System.Drawing.Point(12, 41);
            this.dgvDane.Name = "dgvDane";
            this.dgvDane.Size = new System.Drawing.Size(646, 440);
            this.dgvDane.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 497);
            this.Controls.Add(this.dgvDane);
            this.Controls.Add(this.txtPolecenieSQL);
            this.Controls.Add(this.btnWykonajPolecenie);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWykonajPolecenie;
        private System.Windows.Forms.TextBox txtPolecenieSQL;
        private System.Windows.Forms.DataGridView dgvDane;
    }
}

