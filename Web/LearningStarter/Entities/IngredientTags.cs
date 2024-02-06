using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class IngredientTags
{
    public int Id { get; set; }

    public int IngredientsId { get; set; }
    public Ingredients Ingredient { get; set; }

    public int TagsId { get; set; }
    public Steps Tags { get; set; }


}

public class IngredientTagsGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class IngredientTagsEntityTypeConfiguration : IEntityTypeConfiguration<IngredientTags>
{
    public void Configure(EntityTypeBuilder<IngredientTags> builder)
    {
        builder.ToTable("IngredientTags");

        builder.HasOne(x => x.Ingredient)
            .WithMany(x => x.Tags);

        builder.HasOne(x => x.Tags)
            .WithMany();
    }



}