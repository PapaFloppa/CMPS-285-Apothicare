using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace LearningStater.Entities;

public class BillingInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Zip {  get; set; }
    public string StreetAddress { get; set; }
    public string SuiteNumber { get; set;}
    public string NameOnCard { get; set;}
    public string CardNumber { get; set;}
    public int ExpirationMonth { get; set;}
    public int ExpirationYear { get; set;}
    public int CVV { get; set;}

}

public class BillingInfoGetDto
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
    public string NameOnCard { get; set; }
    public string CardNumber { get; set; }
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public int CVV { get; set; }

}

public class BillingInfoCreateDto
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

public class BillingInfoUpdateDto
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

public class BillingInfoEntityTypeConfiguration : IEntityTypeConfiguration<BillingInfo>
{
    public void Configure(EntityTypeBuilder<BillingInfo> builder)
    {
        builder.ToTable("BillingInfo");
    }
}