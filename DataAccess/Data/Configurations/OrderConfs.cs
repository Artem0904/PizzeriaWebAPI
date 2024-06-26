﻿using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Configurations
{
    public class OrderConfs : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.UserId).IsRequired(false);

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Pizzas).WithMany(x => x.Orders);
            builder.HasMany(x => x.Beverages).WithMany(x => x.Orders);
        }
    }
}
