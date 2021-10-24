using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogv2.Models;

public class CategoryMap : IEntityTypeConfiguration<Category>{

    public void Configure(EntityTypeBuilder<Category> builder){
        builder.ToTable("Category");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
    }
}
