using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LearningStarter.Entities;

public class RecipeRatings
{
    public int Id { get; set; }

    public int RecipeId { get; set; }
    public Recipes Recipes { get; set; }

    public int RatingId { get; set; }
    public Ratings Ratings { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}

public class RecipeRatingsGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
}

public class RecipeRatingsEntityTypeConfiguration : IEntityTypeConfiguration<RecipeRatings>
{
    public void Configure(EntityTypeBuilder<RecipeRatings> builder)
    {
        builder.ToTable("RecipeRatings");

        builder.HasOne(x => x.Recipes)
            .WithMany(x => x.Ratings);

        builder.HasOne(x => x.Ratings)
                .WithMany();
    }



}