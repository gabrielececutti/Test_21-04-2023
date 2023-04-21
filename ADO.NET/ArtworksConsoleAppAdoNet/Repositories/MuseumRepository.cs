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

        public List<Museum>? GetByPictureName(string pictureName)
        {
            var query = @"select Museum.Id_Museum, Museum.MuseumName, Museum.City
                        from Artwork
                        join Museum on Artwork.Id_Museum = Museum.Id_Museum
                        where Artwork.Name = @pictureName";
            return GetMuseums(query, "@pictureName", pictureName);
        }

        private List<Museum>? GetMuseums(string command, string parameterName, object value)
        {
            try
            {
                using var cn = new SqlConnection(Constants.ConnectionString);
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
