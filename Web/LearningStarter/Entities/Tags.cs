using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace LearningStater.Entities;

public class Tags
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class TagsGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class TagsCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class TagsUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}
public class TagsEntityTypeConfiguration : IEntityTypeConfiguration<Tags>
{
    public void Configure(EntityTypeBuilder<Tags> builder)
    {
        builder.ToTable("Tags");
    }
}