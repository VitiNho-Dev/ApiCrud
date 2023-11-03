using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCrud;

public class ProductMap
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(property => property.Id);
        builder
            .Property(property => property.Id)
            .HasColumnName("IdProduct")
            .HasColumnType("int")
            .UseIdentityColumn();
        builder
            .Property(property => property.Name)
            .HasColumnName("NameProduct")
            .HasColumnType("varchar(15)")
            .IsRequired();
        builder
            .Property(property => property.Price)
            .HasColumnName("PriceProduct")
            .HasColumnType("money")
            .IsRequired();
        builder
            .Property(property => property.CreatedAt)
            .HasColumnName("DateCreateProduct")
            .HasColumnType("datetime2");
        builder
            .Property(property => property.UpdatedAt)
            .HasColumnName("DateUpdateProduct")
            .HasColumnType("datetime2");
    }
}