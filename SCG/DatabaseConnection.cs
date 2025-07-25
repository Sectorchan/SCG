using System.Linq.Expressions;
using Microsoft.Data.Sqlite;
using static SCG.Forms.Server;

public class DatabaseConnection
{
    private static DatabaseConnection _instance;
    private SqliteConnection _connection;
    private static readonly object _lock = new();
    private string _database = Global.database;



    private DatabaseConnection()
    {
        try
        {
            SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
            _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
            _connectionString.DataSource = _database;
            _connectionString.Password = null;
            string connectionString = _connectionString.ToString();

            _connection = new SqliteConnection(connectionString);
            _connection.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
                    }
            }

    public static DatabaseConnection GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }
            }
        }
        return _instance;
    }

    public SqliteConnection GetConnection() => _connection;

    public void CloseConnection()
    {
        _connection?.Close();
        _connection = null;
        _instance = null;
    }
}
