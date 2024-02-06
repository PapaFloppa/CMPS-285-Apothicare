using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class Steps
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instructions { get; set; }

}

public class StepsGetDto
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instructions { get; set; }

}

public class StepsCreateDto
{
    public int StepNumber { get; set; }
    public string Instructions { get; set; }

}

public class StepsUpdateDto
{
    public int StepNumber { get; set; }
    public string Instructions { get; set; }
}

public class StepsEntityTypeConfiguration : IEntityTypeConfiguration<Steps>
{
    public void Configure(EntityTypeBuilder<Steps> builder)
    {
        builder.ToTable("Steps");
    }
}