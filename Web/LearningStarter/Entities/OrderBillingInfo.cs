using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class OrderBillingInfo
{
    public int Id { get; set; }

    public int BillingInfoId { get; set; }
    public BillingInfo BillingInfo { get; set; }

    public int OrderId { get; set; }
    public Orders Order { get; set; }


}

public class OrderBillingInfoGetDto
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

public class OrderBillingInfoEntityTypeConfiguration : IEntityTypeConfiguration<OrderBillingInfo>
{
    public void Configure(EntityTypeBuilder<OrderBillingInfo> builder)
    {
        builder.ToTable("OrderBillingInfo");

        builder.HasOne(x => x.Order)
            .WithMany(x => x.BillingInfo);


        builder.HasOne(x => x.BillingInfo)
            .WithMany();
    }



}