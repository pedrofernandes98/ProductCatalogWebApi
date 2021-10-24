using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogv2.Models;

public class ProductMap : IEntityTypeConfiguration<Product>{

    public void Configure(EntityTypeBuilder<Product> builder){
        builder.ToTable("Product");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.description).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
        builder.Property(x => x.image).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
        builder.Property(x => x.createDate).IsRequired();
        builder.Property(x => x.price).IsRequired().HasColumnType("money");
        builder.Property(x => x.quantity).IsRequired();
        builder.Property(x => x.title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
        builder.HasOne(x => x.category).WithMany(x => x.Products);
    }
}

