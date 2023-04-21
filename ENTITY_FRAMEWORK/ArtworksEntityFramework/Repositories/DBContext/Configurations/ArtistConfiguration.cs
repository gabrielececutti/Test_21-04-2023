using ArtworksEntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ArtworksEntityFramework.Repositories.DBContext.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> entity)
        {
                entity.HasKey(e => e.IdArtist).HasName("PK__Artist__FB56A91037BAC086");

                entity.ToTable("Artist");

                entity.Property(e => e.IdArtist)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Artist");
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
