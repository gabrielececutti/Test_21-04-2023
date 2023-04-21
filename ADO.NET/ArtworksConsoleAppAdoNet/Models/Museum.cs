using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworksConsoleAppAdoNet.Models
{
    public class Museum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public override string ToString() => $"Name: {Name}, City: {City}";
    }
}
