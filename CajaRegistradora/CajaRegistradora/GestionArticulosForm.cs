using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CajaRegistradora
{
    public partial class GestionArticulosForm : Form
    {
        private string connectionString;
        private DataTable dtArticulos;

        public GestionArticulosForm()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "CajaRegistradora.sqlite");
            connectionString = $"Data Source={dbPath};Version=3;";
            InitializeComponent();
            CargarArticulos();
            ConfigurarControles(false);
        }

        private void CargarArticulos()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Articulos";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);
                dtArticulos = new DataTable();
                da.Fill(dtArticulos);
                dgvArticulos.DataSource = dtArticulos;
            }
        }

        private void ConfigurarControles(bool enabled)
        {
            txtCodigo.Enabled = enabled;
            txtNombre.Enabled = enabled;
            txtPrecio.Enabled = enabled;
            cmbIVA.Enabled = enabled;
            btnGuardar.Enabled = enabled;
        }

        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            cmbIVA.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ConfigurarControles(true);
            LimpiarControles();
            txtCodigo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                ConfigurarControles(true);
                txtCodigo.Text = dgvArticulos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                txtNombre.Text = dgvArticulos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvArticulos.SelectedRows[0].Cells["Precio"].Value.ToString();
                cmbIVA.Text = dgvArticulos.SelectedRows[0].Cells["IVA"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un articulo para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar este articulo?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string codigo = dgvArticulos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "DELETE FROM Articulos WHERE Codigo = @Codigo";
                        SQLiteCommand command = new SQLiteCommand(sql, connection);
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        command.ExecuteNonQuery();
                    }
                    CargarArticulos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un articulo para eliminar.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                    INSERT OR REPLACE INTO Articulos (Codigo, Nombre, Precio, IVA)
                    VALUES (@Codigo, @Nombre, @Precio, @IVA)
                ";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text));
                command.Parameters.AddWithValue("@IVA", int.Parse(cmbIVA.Text));
                command.ExecuteNonQuery();
            }
            CargarArticulos();
            ConfigurarControles(false);
            LimpiarControles();
        }
    }
}
