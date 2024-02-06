using LearningStarter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace LearningStater.Entities;

public class RecipeIngredients
{
    public int Id { get; set; }

    public int RecipeId { get; set; }
    public Recipes Recipes { get; set; }

    public int IngredientId { get; set; }
    public Ingredients Ingredients { get; set; }

    public double IngredientAmount { get; set; }
    public string IngredientMeasurement { get; set; }
}

public class RecipeIngredientsGetDto
{
    public int Id { get; set; }
    public string Description { get; set; } 
    public string Name { get; set; }
    public double IngredientAmount { get; set; }
    public string IngredientMeasurement { get; set; }
}

public class RecipesIngredientsEntityTypeConfiguration : IEntityTypeConfiguration<RecipeIngredients>
{
    public void Configure(EntityTypeBuilder<RecipeIngredients> builder)
    {
        builder.ToTable("RecipeIngredients");

        builder.HasOne(x => x.Recipes)
            .WithMany(x => x.Ingredients);

        builder.HasOne(x => x.Ingredients)
            .WithMany();
    }



}