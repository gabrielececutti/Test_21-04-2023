using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworksConsoleAppAdoNet.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Museum Museum { get; set; }
        public Artist Artist { get; set; }
        public Character? Character { get; set; }

    }
}
