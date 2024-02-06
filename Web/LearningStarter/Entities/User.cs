using System.Collections.Generic;
using System.Text.Json.Serialization;
using LearningStater.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningStarter.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

   public List<UserRole> UserRoles { get; set; } = new();
   public List<UserRecipes> Recipes { get; set; }
    public List<RecipeRatings> Ratings { get; set; }
    public List<UserBillingInfo> BillingInfo { get; set; }
    public List<UserShippingInfo> ShippingInfo { get; set; }
}

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class UserUpdateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class UserGetDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public List<UserRecipesGetDto> Recipes { get; set; }
    public List<RecipeRatingsGetDto> Ratings { get; set; }
    public List<UserBillingInfoGetDto> BillingInfo { get; set; }
    public List<UserShippingInfoGetDto> ShippingInfo { get; set; }
}

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired();

        builder.Property(x => x.LastName)
            .IsRequired();

        builder.Property(x => x.UserName)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired();
    }
}
