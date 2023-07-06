using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MainProject.Controller
{
    internal class dbConnection
    {
        //const string ConnectionString = "server=localhost;port=5432;database=OrderSwift_DB;Username=Postgres;password=1651382@Msh2003";
       //const string ConnectionString = "Host=localhost;Username=iugy;Password=1651382@Msh2003;Database=OrderSwift_DB";
      const  string ConnectionString = "Server=localhost;Port=5432;Database=OrderSwift_DB;User Id=postgres;Password=1651382@Msh2003;";
        NpgsqlConnection Tunnel;
        NpgsqlCommand Command;



        public dbConnection()
        {
            Tunnel = CreateTunnel();
        }
        NpgsqlConnection CreateTunnel()
        {
            NpgsqlConnection tunnel = new NpgsqlConnection(ConnectionString);
            tunnel.Open();
            return tunnel;
        }
        public NpgsqlDataReader ExecuteQuery(string query)
        {
            Command = new NpgsqlCommand(query, Tunnel);
            NpgsqlDataReader reader = Command.ExecuteReader();
            return reader;
        }
        public void ExecuteNoneQuery(string query)
        {
            Command = new NpgsqlCommand(query, Tunnel);
            Command.ExecuteNonQuery();
        }
        public void CloseTunnel()
        {
            Command.Dispose();
            Tunnel.Close();
        }
    }
}
