using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class RecipeSteps
{
    public int Id { get; set; }

    public int RecipeId { get; set; }
    public Recipes Recipe { get; set; }

    public int StepId { get; set; }
    public Steps Step { get; set; }


}

public class RecipeStepsGetDto
{
    public int Id { get; set; }
    public string Instructions { get; set; }
    public int StepNumber { get; set; }

}

public class RecipeStepsEntityTypeConfiguration : IEntityTypeConfiguration<RecipeSteps>
{
    public void Configure(EntityTypeBuilder<RecipeSteps> builder)
    {
        builder.ToTable("RecipeSteps");

        builder.HasOne(x => x.Recipe)
            .WithMany(x => x.Steps);

        builder.HasOne(x => x.Step)
            .WithMany();
    }



}