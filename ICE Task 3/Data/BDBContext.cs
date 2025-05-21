using System;
using System.Collections.Generic;
using ICE_Task_3.Models;
using Microsoft.EntityFrameworkCore;

namespace ICE_Task_3.Data;

public partial class BDBContext : DbContext
{
    public BDBContext()
    {
    }

    public BDBContext(DbContextOptions<BDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BandInfo> BandInfos { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BandInfo>(entity =>
        {
            entity.HasKey(e => e.BandId).HasName("PK__BandInfo__A0369388C551203B");

            entity.ToTable("BandInfo");

            entity.Property(e => e.BandId).HasColumnName("BandID");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
