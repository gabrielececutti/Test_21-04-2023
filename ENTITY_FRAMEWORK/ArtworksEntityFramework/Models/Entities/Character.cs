using System;
using System.Collections.Generic;

namespace ArtworksEntityFramework.Models.Entities;

public partial class Character
{
    public int IdCharacter { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}
