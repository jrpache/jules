using System.Data.SQLite;

namespace CajaRegistradora
{
    public class Database
    {
        private string connectionString;

        public Database()
        {
            connectionString = "Data Source=Data/CajaRegistradora.sqlite;Version=3;";
            if (!File.Exists("Data/CajaRegistradora.sqlite"))
            {
                SQLiteConnection.CreateFile("Data/CajaRegistradora.sqlite");
                CreateTables();
            }
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                    CREATE TABLE Articulos (
                        Codigo TEXT PRIMARY KEY,
                        Nombre TEXT NOT NULL,
                        Precio REAL NOT NULL,
                        IVA INTEGER NOT NULL
                    );

                    CREATE TABLE Tickets (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Fecha TEXT NOT NULL,
                        Total REAL NOT NULL,
                        Anulado INTEGER NOT NULL DEFAULT 0
                    );

                    CREATE TABLE TicketLineas (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        TicketId INTEGER NOT NULL,
                        ArticuloCodigo TEXT NOT NULL,
                        Cantidad INTEGER NOT NULL,
                        PrecioUnitario REAL NOT NULL,
                        IVA INTEGER NOT NULL,
                        FOREIGN KEY(TicketId) REFERENCES Tickets(Id),
                        FOREIGN KEY(ArticuloCodigo) REFERENCES Articulos(Codigo)
                    );
                ";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                // Insert sample data
                sql = @"
                    INSERT INTO Articulos (Codigo, Nombre, Precio, IVA) VALUES
                    ('A001', 'Coca-Cola 600ml', 1.5, 22),
                    ('A002', 'Pepsi 600ml', 1.4, 22),
                    ('A003', 'Agua Mineral 500ml', 1.0, 10),
                    ('A004', 'Papas Fritas Lays', 2.0, 22),
                    ('A005', 'Galletas Oreo', 1.8, 22),
                    ('B001', 'Remera Lisa', 15.0, 22),
                    ('B002', 'Pantalon Jean', 30.0, 22),
                    ('C001', 'Taza de Ceramica', 5.0, 10),
                    ('C002', 'Llavero de Metal', 2.5, 0);
                ";
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
