using ArtworksConsoleAppAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworksConsoleAppAdoNet.Repositories
{
    public interface IMuseumRepository
    {
        List<Museum>? GetByPictureName (string pictureName);
    }
    public class MuseumRepository : IMuseumRepository
    {
        private const string ConnectionString = @"Server=DESKTOP-476F63V\SQLEXPRESS; Database=Artworks; Integrated Security=true; TrustServerCertificate=True";

        public List<Museum>? GetByPictureName(string pictureName)
        {
            var query = "select Museum.City\r\nfrom Artwork\r\njoin Museum on Artwork.Id_Museum = Museum.Id_Museum\r\nwhere Artwork.Name = 'Flora'";
            return GetMuseums(query, "@pictureName", pictureName);
        }

        private List<Museum>? GetMuseums(string command, string parameterName, object value)
        {
            try
            {
                using var cn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand(command, cn);
                cn.Open();
                cmd.Parameters.AddWithValue(parameterName, value);
                using var reader = cmd.ExecuteReader();
                var result = new List<Museum>();
                while (reader?.Read() == true)
                {
                    var museum = new Museum()
                    {
                        Id = reader.GetInt32("Id_Museum"),
                        Name = reader.GetString("MuseumName"),
                        City = reader.GetString("City")
                    };
                    result.Add(museum);
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
