using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class UserShippingInfo
{
    public int Id { get; set; }

    public int ShippingInfoId { get; set; }
    public BillingInfo ShippingInfo { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }


}

public class UserShippingInfoGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string StreetAddress { get; set; }
    public string SuiteNumber { get; set; }

}

public class UserShippingInfontityTypeConfiguration : IEntityTypeConfiguration<UserShippingInfo>
{
    public void Configure(EntityTypeBuilder<UserShippingInfo> builder)
    {
        builder.ToTable("UserShippingInfo");

        builder.HasOne(x => x.User)
            .WithMany(x => x.ShippingInfo);


        builder.HasOne(x => x.ShippingInfo)
            .WithMany();
    }



}