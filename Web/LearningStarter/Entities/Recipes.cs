using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class Recipes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BodyText { get; set; }

    public string ImageUrl { get; set; }

    public List<RecipeRatings> Ratings { get; set; }
    public List<RecipeIngredients> Ingredients { get; set; }
    public List<RecipeSteps> Steps { get; set; }
    public List<RecipeTags> Tags { get; set; }

}

public class RecipesGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BodyText { get; set; }
    public string ImageUrl { get; set; }
    public List<RecipeRatingsGetDto> Ratings { get; set; }
    public List<RecipeIngredientsGetDto> Ingredients { get; set; }
    public List<RecipeStepsGetDto> Steps { get; set; }
    public List<RecipeTagsGetDto> Tags { get; set; }
}

public class RecipesCreateDto
{
    public string Name { get; set; }
    public string BodyText { get; set; }
    public string ImageUrl { get; set; }

}

public class RecipesUpdateDto
{
    public string Name { get; set; }
    public string BodyText { get; set; }
    public string ImageUrl { get; set; }
}

public class RecipesEntityTypeConfiguration : IEntityTypeConfiguration<Recipes>
{
    public void Configure(EntityTypeBuilder<Recipes> builder)
    {
        builder.ToTable("Recipes");
    }
}
