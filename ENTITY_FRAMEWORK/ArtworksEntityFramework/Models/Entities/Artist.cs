using System;
using System.Collections.Generic;

namespace ArtworksEntityFramework.Models.Entities;

public partial class Artist
{
    public int IdArtist { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}
