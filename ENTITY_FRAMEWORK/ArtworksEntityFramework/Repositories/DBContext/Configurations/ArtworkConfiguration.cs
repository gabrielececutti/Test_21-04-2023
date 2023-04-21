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
    public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
    {
        public void Configure(EntityTypeBuilder<Artwork> entity)
        {
                entity.HasKey(e => e.IdArtwork).HasName("PK__Artwork__B99D1B3D4401A006");

                entity.ToTable("Artwork");

                entity.Property(e => e.IdArtwork)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Artwork");
                entity.Property(e => e.IdArtist).HasColumnName("Id_Artist");
                entity.Property(e => e.IdCharacter).HasColumnName("Id_Character");
                entity.Property(e => e.IdMuseum).HasColumnName("Id_Museum");
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdArtistNavigation).WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.IdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artwork__Id_Arti__2B3F6F97");

                entity.HasOne(d => d.IdCharacterNavigation).WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.IdCharacter)
                    .HasConstraintName("FK__Artwork__Id_Char__2C3393D0");

                entity.HasOne(d => d.IdMuseumNavigation).WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.IdMuseum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artwork__Id_Muse__2A4B4B5E");
        }
    }
}
