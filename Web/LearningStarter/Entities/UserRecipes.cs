using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LearningStarter.Entities;

public class UserRecipes
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int RecipesId { get; set; }
    public Recipes Recipes { get; set; }
}

public class UserRecipesGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BodyText { get; set; }
    public string ImageURL { get; set; }
}

public class UserRecipesUpdateDto
{
    public int UsersId { get; set; }
    public int RecipesId { get; set; }

}

public class UserRecipesCreateDto
{
    public int UsersId { get; set; }
    public int RecipesId { get; set; }
}

public class UserRecipesEntityTypeConfiguration : IEntityTypeConfiguration<UserRecipes>
{
    public void Configure(EntityTypeBuilder<UserRecipes> builder)
    {
        builder.ToTable("UserRecipes");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Recipes);

        builder.HasOne(x => x.Recipes)
            .WithMany();
    }



}