using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class Ratings
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    public RecipeRatings User { get; set; }

}


public class RatingsGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    public RecipeRatings User { get; set; }

}

public class RatingsCreateDto
{
    public string Name { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
}

public class RatingsUpdateDto
{
    public string Name { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
}

public class RatingsEntityTypeConfiguration : IEntityTypeConfiguration<Ratings>
{
    public void Configure(EntityTypeBuilder<Ratings> builder)
    {
        builder.ToTable("Ratings");
    }
}