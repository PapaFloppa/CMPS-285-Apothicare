/*using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class UserRatings
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int RatingId { get; set; }
    public Ratings Rating { get; set; }


}

public class UserRatingsGetDto
{
    public int Id { get; set; }
    public string Instructions { get; set; }
    public int StepNumber { get; set; }

}

public class UserRatingsEntityTypeConfiguration : IEntityTypeConfiguration<UserRatings>
{
    public void Configure(EntityTypeBuilder<UserRatings> builder)
    {
        builder.ToTable("UserRatings");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Rating);

        builder.HasOne(x => x.Rating)
            .WithMany();
    }



}
*/