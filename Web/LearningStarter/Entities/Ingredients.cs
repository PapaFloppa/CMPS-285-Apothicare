using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class Ingredients
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IngredientTags> Tags { get; set; }
}

public class IngredientsGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IngredientTagsGetDto> Tags { get; set; }
}

public class IngredientsCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }

}

public class IngredientsUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }

}

public class IngredientsEntityTypeConfiguration : IEntityTypeConfiguration<Ingredients>
{
    public void Configure(EntityTypeBuilder<Ingredients> builder)
    {
        builder.ToTable("Ingredients");
    }
}