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
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> entity)
        {
                entity.HasKey(e => e.IdCharacter).HasName("PK__Characte__CDD73BE097DD29FB");

                entity.ToTable("Character");

                entity.Property(e => e.IdCharacter)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Character");
                entity.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
