using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class OrderProducts
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Orders Orders { get; set; }

    public int ProductId { get; set; }
    public Products Products { get; set; }

    public int Quantity { get; set; }
    public int Total {  get; set; }

}

public class OrderProductsGetDto
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public int Total { get; set; }
}

public class OrderProductsEntityTypeConfiguration : IEntityTypeConfiguration<OrderProducts>
{
    public void Configure(EntityTypeBuilder<OrderProducts> builder)
    {
        builder.ToTable("OrderProducts");

        builder.HasOne(x => x.Orders)
            .WithMany(x => x.Products);

        builder.HasOne(x => x.Products)
            .WithMany();
    }



}