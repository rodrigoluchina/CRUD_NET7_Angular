using pokemonApi.AdoNet.DataBases;
using pokemonApi.AdoNet.Models;
using System.Data.SqlClient;

namespace pokemonApi.AdoNet.Repositores
{
    public class PokemonRepository
    {
        public PokemonRepository() { }

        public List<Pokemon> Select() 
        {
            List<Pokemon> pokemons = null;
            Pokemon pokemon = null;

            try
            {
                SqlConnection sqlConnection = new dbPokemon().CreateConnetion();
                sqlConnection.Open();
                
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "Select * from Pokemons";
                sqlCommand.CommandType = System.Data.CommandType.Text;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                pokemons = new List<Pokemon>();

                while (sqlDataReader.Read()) 
                {
                    pokemon = new Pokemon();
                    pokemon.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    pokemon.Name = Convert.ToString(sqlDataReader["Name"]);
                    pokemon.Category = Convert.ToString(sqlDataReader["Category"]);
                    pokemons.Add(pokemon);
                }

                sqlDataReader.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return pokemons;
        }
        public void Insert(Pokemon pokemon)
        {
            try
            {
                 SqlConnection sqlConnection = new dbPokemon().CreateConnetion();
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText = "INSERT INTO Pokemons (Name, Category) VALUES (@Name, @Category)";
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    
                    sqlCommand.Parameters.AddWithValue("@Name", pokemon.Name);
                    sqlCommand.Parameters.AddWithValue("@Category", pokemon.Category);

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public Pokemon SelectById(int id)
        {
            Pokemon pokemon = new Pokemon();

            try
            {
                SqlConnection sqlConnection = new dbPokemon().CreateConnetion();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Pokemons WHERE Id = @Id";
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    pokemon = new Pokemon();
                    pokemon.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    pokemon.Name = Convert.ToString(sqlDataReader["Name"]);
                    pokemon.Category = Convert.ToString(sqlDataReader["Category"]);
                }

                sqlDataReader.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (Exception exception)
            {

                throw exception;
            }

            return pokemon;
        }
        public void Update(Pokemon pokemon)
        {
            try
            {

                SqlConnection sqlConnection = new dbPokemon().CreateConnetion();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Pokemons SET Name = @Name, Category = @Category WHERE Id = @Id";
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Id", pokemon.Id);
                sqlCommand.Parameters.AddWithValue("@Name", pokemon.Name);
                sqlCommand.Parameters.AddWithValue("@Category", pokemon.Category);

                sqlCommand.ExecuteNonQuery();


                sqlConnection.Close();
                sqlConnection.Dispose();

            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public void Delete(int id)
        {
            try
            {
                
                SqlConnection sqlConnection = new dbPokemon().CreateConnetion();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Pokemons WHERE Id = @Id";
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                sqlCommand.ExecuteNonQuery();
                
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
