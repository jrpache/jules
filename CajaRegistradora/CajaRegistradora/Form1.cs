using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CajaRegistradora
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=Data/CajaRegistradora.sqlite;Version=3;";
        private DataTable dtTicket;

        public Form1()
        {
            InitializeComponent();
            InicializarTicket();
            txtBusquedaArticulo.TextChanged += new EventHandler(txtBusquedaArticulo_TextChanged);
            lstSugerencias.DoubleClick += new EventHandler(lstSugerencias_DoubleClick);
            btnGestionArticulos.Click += new EventHandler(btnGestionArticulos_Click);
            btnNuevoTicket.Click += new EventHandler(btnNuevoTicket_Click);
            btnCobrar.Click += new EventHandler(btnCobrar_Click);
        }

        private void InicializarTicket()
        {
            dtTicket = new DataTable();
            dtTicket.Columns.Add("Codigo");
            dtTicket.Columns.Add("Nombre");
            dtTicket.Columns.Add("Cantidad", typeof(int));
            dtTicket.Columns.Add("Precio", typeof(decimal));
            dtTicket.Columns.Add("IVA", typeof(int));
            dtTicket.Columns.Add("Subtotal", typeof(decimal), "Cantidad * Precio");
            dgvTicket.DataSource = dtTicket;
        }

        private void txtBusquedaArticulo_TextChanged(object sender, EventArgs e)
        {
            if (txtBusquedaArticulo.Text.Length > 2)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Articulos WHERE Nombre LIKE @Busqueda OR Codigo LIKE @Busqueda";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);
                    da.SelectCommand.Parameters.AddWithValue("@Busqueda", "%" + txtBusquedaArticulo.Text + "%");
                    DataTable dtSugerencias = new DataTable();
                    da.Fill(dtSugerencias);
                    lstSugerencias.DataSource = dtSugerencias;
                    lstSugerencias.DisplayMember = "Nombre";
                    lstSugerencias.ValueMember = "Codigo";
                    lstSugerencias.Visible = true;
                }
            }
            else
            {
                lstSugerencias.Visible = false;
            }
        }

        private void lstSugerencias_DoubleClick(object sender, EventArgs e)
        {
            if (lstSugerencias.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)lstSugerencias.SelectedItem;
                DataRow dr = drv.Row;
                AgregarArticulo(dr["Codigo"].ToString(), dr["Nombre"].ToString(), 1, (decimal)dr["Precio"], (int)dr["IVA"]);
                txtBusquedaArticulo.Clear();
                lstSugerencias.Visible = false;
                CalcularTotal();
            }
        }

        private void AgregarArticulo(string codigo, string nombre, int cantidad, decimal precio, int iva)
        {
            foreach (DataRow row in dtTicket.Rows)
            {
                if (row["Codigo"].ToString() == codigo)
                {
                    row["Cantidad"] = (int)row["Cantidad"] + cantidad;
                    return;
                }
            }
            dtTicket.Rows.Add(codigo, nombre, cantidad, precio, iva);
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in dtTicket.Rows)
            {
                total += (decimal)row["Subtotal"];
            }
            lblTotal.Text = "Total: " + total.ToString("C");
        }

        private void btnGestionArticulos_Click(object sender, EventArgs e)
        {
            GestionArticulosForm form = new GestionArticulosForm();
            form.ShowDialog();
        }

        private void btnNuevoTicket_Click(object sender, EventArgs e)
        {
            InicializarTicket();
            CalcularTotal();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            // Guardar el ticket en la base de datos
            decimal total = 0;
            foreach (DataRow row in dtTicket.Rows)
            {
                total += (decimal)row["Subtotal"];
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Tickets (Fecha, Total) VALUES (@Fecha, @Total)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@Total", total);
                command.ExecuteNonQuery();
                long ticketId = connection.LastInsertRowId;

                foreach (DataRow row in dtTicket.Rows)
                {
                    sql = "INSERT INTO TicketLineas (TicketId, ArticuloCodigo, Cantidad, PrecioUnitario, IVA) VALUES (@TicketId, @ArticuloCodigo, @Cantidad, @PrecioUnitario, @IVA)";
                    command = new SQLiteCommand(sql, connection);
                    command.Parameters.AddWithValue("@TicketId", ticketId);
                    command.Parameters.AddWithValue("@ArticuloCodigo", row["Codigo"]);
                    command.Parameters.AddWithValue("@Cantidad", row["Cantidad"]);
                    command.Parameters.AddWithValue("@PrecioUnitario", row["Precio"]);
                    command.Parameters.AddWithValue("@IVA", row["IVA"]);
                    command.ExecuteNonQuery();
                }
            }

            // Imprimir el ticket
            ImprimirTicket();

            // Abrir el cajon de dinero
            AbrirCajon();

            // Limpiar el ticket
            InicializarTicket();
            CalcularTotal();
        }

        private void ImprimirTicket()
        {
            // This is a simplified printing method. In a real application, you would use a library like RawPrint.
            string ticketContent = "               TICKET DE VENTA\n";
            ticketContent += "------------------------------------------------\n";
            foreach (DataRow row in dtTicket.Rows)
            {
                ticketContent += string.Format("{0,-20} {1,5} {2,10} {3,10}\n", row["Nombre"], row["Cantidad"], ((decimal)row["Precio"]).ToString("C"), ((decimal)row["Subtotal"]).ToString("C"));
            }
            ticketContent += "------------------------------------------------\n";
            ticketContent += string.Format("{0,35} {1,10}\n", "TOTAL:", lblTotal.Text);

            // You can save this to a file and then send it to the printer
            File.WriteAllText("ticket.txt", ticketContent);
            MessageBox.Show("Ticket impreso (guardado en ticket.txt)");
        }

        private void AbrirCajon()
        {
            // This is a standard command to open a cash drawer.
            // You would send this to the printer.
            string openDrawerCommand = "" + (char)27 + (char)112 + (char)0 + (char)25 + (char)250;
            // In a real application, you would send this command to the printer port.
            MessageBox.Show("Cajon de dinero abierto (simulado)");
        }
    }
}
