using ArtworksConsoleAppAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworksConsoleAppAdoNet.Repositories
{
    public interface IArtistRepository
    {
        List<Artist> GetByCounrtyArtwork (string country);
    }
    public class ArtistRepositorty : IArtistRepository
    {
        public List<Artist> GetByCounrtyArtwork(string country)
        {
            var query = @"select Artist.Id_Artist, Artist.Name, Artist.Country
                from Artist 
                join Artwork on Artist.Id_Artist = Artwork.Id_Artist
                join Museum on Artwork.Id_Museum = Museum.Id_Museum 
                where Museum.City = @country";
            return GetArtists(query, "@country", country);
        }

        private List<Artist>? GetArtists (string command, string parameterName, object value)
        {
            try
            {
                using var cn = new SqlConnection(Constants.ConnectionString);
                using var cmd = new SqlCommand(command, cn);
                cn.Open();
                cmd.Parameters.AddWithValue(parameterName, value);
                using var reader = cmd.ExecuteReader();
                List<Artist> result = new List<Artist>();
                while (reader?.Read() == true)
                {
                    var artist = new Artist()
                    {
                        Id = reader.GetInt32("Id_Artist"),
                        Name = reader.GetString("Name"),
                        Country = reader.GetString("Country")
                    };
                    result.Add(artist);
                }
                return result;
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex);
            }
            return null;
        }
    }
}
