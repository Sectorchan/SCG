using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using static SCG.Ssql;

namespace PL;
public class Utils
{
    public class Sql
    {
        public static List<string> SqlSelect(string database, string column, SQLTable table)
        {
            using var connection = new SqliteConnection(database);
            string _table = "ca";
            connection.Open();
            var sql = $"SELECT {column} FROM {_table}";
            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                List<string> columns = new List<string>();
                while (reader.Read())
                {
                    var name = reader.GetString(0);
                    columns.Add(reader.GetString(0));
                }
                return columns;
            }
            else
            {
                MessageBox.Show("No Server found", "", MessageBoxButtons.OK);
                return null;
            }
        }
    }
}
