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
    public interface INewModelRepository
    {
        public List<NewModel>? GetByArtistNationality (string artistNationality);
    }
    public class NewModelRepository : INewModelRepository
    {
        public List<NewModel>? GetByArtistNationality(string artistNationality)
        {
            var query = @"select m.Id_Museum, m.MuseumName, m.City, aw.Name as ArtworkName, c.Name as CharacterName
                        from Museum m
                        inner join Artwork aw on m.Id_Museum = aw.Id_Museum
                        inner join Artist a on aw.Id_Artist = a.Id_Artist
                        left join Character c on aw.Id_Character = c.Id_Character
                        where a.Country = @nationality";
            return GetNewModels(query, "@nationality", artistNationality);
        }
       
        private List<NewModel>? GetNewModels(string command, string parameter, object value)
        {
            try
            {
                var connection = new SqlConnection(Constants.ConnectionString);
                var cmd = new SqlCommand(command, connection);
                connection.Open();
                cmd.Parameters.AddWithValue(parameter, value);
                using var reader = cmd.ExecuteReader();
                var newModels = new List<NewModel>();
                while (reader?.Read() == true)
                {
                    var newModel = new NewModel
                    {
                        Museum = new Museum
                        {
                            Id = reader.GetInt32("Id_Museum"),
                            Name = reader.GetString("MuseumName"),
                            City = reader.GetString("City")
                        },
                        ArtworkName = reader.GetString("ArtworkName"),
                        CharacterName = reader.IsDBNull(reader.GetOrdinal("CharacterName")) ? null : reader.GetString("CharacterName")
                    };
                    newModels.Add(newModel);
                }
                return newModels;
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex);
                return null;
            }
        }
    }
}
