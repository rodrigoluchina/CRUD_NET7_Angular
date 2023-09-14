using System.Data.SqlClient;

namespace pokemonApi.AdoNet.DataBases
{
    public class dbPokemon
    {
        string ConnectionString { get; set; }

        public dbPokemon() 
        {
            ConnectionString = "Server=.\\SQLEXPRESS;Database=pokemon;Trusted_Connection=true;TrustServerCertificate=true;";
        }

        public SqlConnection CreateConnetion()
        {
            try
            {
                return new SqlConnection(ConnectionString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
