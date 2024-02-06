using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class RecipeTags
{
    public int Id { get; set; }

    public int RecipesId { get; set; }
    public Recipes Recipes { get; set; }

    public int TagsId { get; set; }
    public Steps Tags { get; set; }


}

public class RecipeTagsGetDto
{
    public int Id { get; set; }
    public string Instructions { get; set; }
    public int StepNumber { get; set; }

}

public class RecipeTagsEntityTypeConfiguration : IEntityTypeConfiguration<RecipeTags>
{
    public void Configure(EntityTypeBuilder<RecipeTags> builder)
    {
        builder.ToTable("RecipeTags");

        builder.HasOne(x => x.Recipes)
            .WithMany(x => x.Tags);

        builder.HasOne(x => x.Tags)
            .WithMany();
    }



}