using LearningStater.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LearningStarter.Entities;

public class Orders
{
    public int Id { get; set; }
    public string TrackingNumber { get; set;}
    public string OrderNumber { get; set; }
    public int Quantity { get; set; }
    public List<OrderProducts> Products { get; set; }
    public List<OrderBillingInfo> BillingInfo { get; set; }
    public List<OrderShippingInfo> ShippingInfo { get; set; }

}

public class OrdersGetDto
{
    public int Id { get; set; }
    public string TrackingNumber { get; set; }
    public string OrderNumber { get; set; }
    public int Quantity { get; set; }
    public List<OrderProductsGetDto> Products { get; set; }
    public List<OrderBillingInfoGetDto> BillingInfo { get; set; }
    public List<OrderShippingInfoGetDto> ShippinngInfo { get; set; }
}

public class OrdersCreateDto
{
    public string TrackingNumber { get; set; }
    public string OrderNumber { get; set; }
    public int Quantity { get; set; }
}

public class OrdersUpdateDto
{

    public string TrackingNumber { get; set; }
    public string OrderNumber { get; set; }
    public int Quantity { get; set; }
}

public class OrdersEntityTypeConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.ToTable("Orders");
    }
}
