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
        List<Artist>? GetByCounrtyArtwork (string country);
    }
    public class ArtistRepositorty : IArtistRepository
    {
        private const string ConnectionString = @"Server=DESKTOP-476F63V\SQLEXPRESS; Database=Artworks; Integrated Security=true; TrustServerCertificate=True";
        public List<Artist>? GetByCounrtyArtwork(string country)
        {
            var query = "select distinct Artist.Name\r\nfrom Artist\r\njoin Artwork on Artist.Id_Artist = Artwork.Id_Artist\r\njoin Museum on Artwork.Id_Museum = Museum.Id_Museum\r\nwhere Museum.City = @country";
            return GetArtists(query, "@country", country);
        }

        private List<Artist>? GetArtists (string command, string parameterName, object value)
        {
            try
            {
                using var cn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand(command, cn);
                cn.Open();
                cmd.Parameters.AddWithValue(parameterName, value);
                using var reader = cmd.ExecuteReader();
                var result = new List<Artist>();
                while (reader?.Read() == true)
                {
                    var artist = new Artist()
                    {
                        Id = reader.GetInt32("Id_Artist"),
                        Name = reader.GetString("Name"),
                        Country = reader.GetString("Counrty")
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
