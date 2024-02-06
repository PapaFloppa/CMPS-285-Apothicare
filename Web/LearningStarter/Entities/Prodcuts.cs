using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStater.Entities;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}

public class ProductsGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}

public class ProductsCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}

public class ProductsUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}

public class ProductsEntityTypeConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("Products");
    }
}