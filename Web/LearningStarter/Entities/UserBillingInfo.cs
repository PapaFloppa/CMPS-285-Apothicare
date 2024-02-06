using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class UserBillingInfo
{
    public int Id { get; set; }

    public int BillingInfoId { get; set; }
    public BillingInfo BillingInfo { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }


}

public class UserBillingInfoGetDto
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string StreetAddress { get; set; }
    public string SuiteNumber { get; set; }
    public string NameOnCard { get; set; }
    public string CardNumber { get; set; }
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public int CVV { get; set; }

}

public class UserBillingInfontityTypeConfiguration : IEntityTypeConfiguration<UserBillingInfo>
{
    public void Configure(EntityTypeBuilder<UserBillingInfo> builder)
    {
        builder.ToTable("UserBillingInfo");

        builder.HasOne(x => x.User)
            .WithMany(x => x.BillingInfo);


        builder.HasOne(x => x.BillingInfo)
            .WithMany();
    }



}