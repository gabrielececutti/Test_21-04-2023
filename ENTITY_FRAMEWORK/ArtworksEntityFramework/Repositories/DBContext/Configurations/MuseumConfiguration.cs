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
    public class MuseumConfiguration : IEntityTypeConfiguration<Museum>
    {
        public void Configure(EntityTypeBuilder<Museum> entity)
        {
                entity.HasKey(e => e.IdMuseum).HasName("PK__Museum__84BA05225CCC4267");

                entity.ToTable("Museum");

                entity.Property(e => e.IdMuseum)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Museum");
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.MuseumName).HasMaxLength(50);
        }
    }
}

