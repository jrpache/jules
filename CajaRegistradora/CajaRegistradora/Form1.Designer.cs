namespace CajaRegistradora
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBusquedaArticulo = new System.Windows.Forms.TextBox();
            this.lstSugerencias = new System.Windows.Forms.ListBox();
            this.dgvTicket = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnNuevoTicket = new System.Windows.Forms.Button();
            this.btnAnularTicket = new System.Windows.Forms.Button();
            this.btnGestionArticulos = new System.Windows.Forms.Button();
            this.btnCierreCaja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicket)).BeginInit();
            this.SuspendLayout();
            //
            // txtBusquedaArticulo
            //
            this.txtBusquedaArticulo.Location = new System.Drawing.Point(12, 12);
            this.txtBusquedaArticulo.Name = "txtBusquedaArticulo";
            this.txtBusquedaArticulo.Size = new System.Drawing.Size(300, 23);
            this.txtBusquedaArticulo.TabIndex = 0;
            //
            // lstSugerencias
            //
            this.lstSugerencias.FormattingEnabled = true;
            this.lstSugerencias.ItemHeight = 15;
            this.lstSugerencias.Location = new System.Drawing.Point(12, 41);
            this.lstSugerencias.Name = "lstSugerencias";
            this.lstSugerencias.Size = new System.Drawing.Size(300, 94);
            this.lstSugerencias.TabIndex = 1;
            //
            // dgvTicket
            //
            this.dgvTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicket.Location = new System.Drawing.Point(12, 141);
            this.dgvTicket.Name = "dgvTicket";
            this.dgvTicket.RowTemplate.Height = 25;
            this.dgvTicket.Size = new System.Drawing.Size(776, 250);
            this.dgvTicket.TabIndex = 2;
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(600, 400);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 37);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total: ";
            //
            // btnCobrar
            //
            this.btnCobrar.Location = new System.Drawing.Point(688, 12);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(100, 50);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            //
            // btnNuevoTicket
            //
            this.btnNuevoTicket.Location = new System.Drawing.Point(350, 12);
            this.btnNuevoTicket.Name = "btnNuevoTicket";
            this.btnNuevoTicket.Size = new System.Drawing.Size(100, 50);
            this.btnNuevoTicket.TabIndex = 5;
            this.btnNuevoTicket.Text = "Nuevo Ticket";
            this.btnNuevoTicket.UseVisualStyleBackColor = true;
            //
            // btnAnularTicket
            //
            this.btnAnularTicket.Location = new System.Drawing.Point(460, 12);
            this.btnAnularTicket.Name = "btnAnularTicket";
            this.btnAnularTicket.Size = new System.Drawing.Size(100, 50);
            this.btnAnularTicket.TabIndex = 6;
            this.btnAnularTicket.Text = "Anular Ticket";
            this.btnAnularTicket.UseVisualStyleBackColor = true;
            //
            // btnGestionArticulos
            //
            this.btnGestionArticulos.Location = new System.Drawing.Point(350, 70);
            this.btnGestionArticulos.Name = "btnGestionArticulos";
            this.btnGestionArticulos.Size = new System.Drawing.Size(100, 50);
            this.btnGestionArticulos.TabIndex = 7;
            this.btnGestionArticulos.Text = "Gestion Articulos";
            this.btnGestionArticulos.UseVisualStyleBackColor = true;
            //
            // btnCierreCaja
            //
            this.btnCierreCaja.Location = new System.Drawing.Point(460, 70);
            this.btnCierreCaja.Name = "btnCierreCaja";
            this.btnCierreCaja.Size = new System.Drawing.Size(100, 50);
            this.btnCierreCaja.TabIndex = 8;
            this.btnCierreCaja.Text = "Cierre de Caja";
            this.btnCierreCaja.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCierreCaja);
            this.Controls.Add(this.btnGestionArticulos);
            this.Controls.Add(this.btnAnularTicket);
            this.Controls.Add(this.btnNuevoTicket);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvTicket);
            this.Controls.Add(this.lstSugerencias);
            this.Controls.Add(this.txtBusquedaArticulo);
            this.Name = "Form1";
            this.Text = "Caja Registradora";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusquedaArticulo;
        private System.Windows.Forms.ListBox lstSugerencias;
        private System.Windows.Forms.DataGridView dgvTicket;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnNuevoTicket;
        private System.Windows.Forms.Button btnAnularTicket;
        private System.Windows.Forms.Button btnGestionArticulos;
        private System.Windows.Forms.Button btnCierreCaja;
    }
}
