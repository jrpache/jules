namespace CajaRegistradora
{
    partial class GestionArticulosForm
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
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.cmbIVA = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            //
            // dgvArticulos
            //
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(12, 12);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowTemplate.Height = 25;
            this.dgvArticulos.Size = new System.Drawing.Size(776, 200);
            this.dgvArticulos.TabIndex = 0;
            //
            // btnNuevo
            //
            this.btnNuevo.Location = new System.Drawing.Point(12, 220);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            //
            // btnEditar
            //
            this.btnEditar.Location = new System.Drawing.Point(93, 220);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            //
            // btnEliminar
            //
            this.btnEliminar.Location = new System.Drawing.Point(174, 220);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(697, 300);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            //
            // txtCodigo
            //
            this.txtCodigo.Location = new System.Drawing.Point(100, 250);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 23);
            this.txtCodigo.TabIndex = 5;
            //
            // txtNombre
            //
            this.txtNombre.Location = new System.Drawing.Point(100, 280);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 23);
            this.txtNombre.TabIndex = 6;
            //
            // txtPrecio
            //
            this.txtPrecio.Location = new System.Drawing.Point(100, 310);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(150, 23);
            this.txtPrecio.TabIndex = 7;
            //
            // cmbIVA
            //
            this.cmbIVA.FormattingEnabled = true;
            this.cmbIVA.Items.AddRange(new object[] {
            "0",
            "10",
            "22"});
            this.cmbIVA.Location = new System.Drawing.Point(100, 340);
            this.cmbIVA.Name = "cmbIVA";
            this.cmbIVA.Size = new System.Drawing.Size(150, 23);
            this.cmbIVA.TabIndex = 8;
            //
            // lblCodigo
            //
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 253);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 9;
            this.lblCodigo.Text = "Codigo";
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 283);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre";
            //
            // lblPrecio
            //
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(12, 313);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 15);
            this.lblPrecio.TabIndex = 11;
            this.lblPrecio.Text = "Precio";
            //
            // lblIVA
            //
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(12, 343);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(24, 15);
            this.lblIVA.TabIndex = 12;
            this.lblIVA.Text = "IVA";
            //
            // GestionArticulosForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.cmbIVA);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvArticulos);
            this.Name = "GestionArticulosForm";
            this.Text = "Gestion de Articulos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.ComboBox cmbIVA;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblIVA;
    }
}
