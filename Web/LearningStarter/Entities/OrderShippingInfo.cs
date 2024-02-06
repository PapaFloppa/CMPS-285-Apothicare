using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class OrderShippingInfo
{
    public int Id { get; set; }

    public int ShippingInfoId { get; set; }
    public ShippingInfo ShippingInfo { get; set; }

    public int OrderId { get; set; }
    public Orders Order { get; set; }


}

public class OrderShippingInfoGetDto
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

public class OrderShippingInfoEntityTypeConfiguration : IEntityTypeConfiguration<OrderShippingInfo>
{
    public void Configure(EntityTypeBuilder<OrderShippingInfo> builder)
    {
        builder.ToTable("OrderShippingInfo");

        builder.HasOne(x => x.Order)
            .WithMany(x => x.ShippingInfo);


        builder.HasOne(x => x.ShippingInfo)
            .WithMany();
    }



}