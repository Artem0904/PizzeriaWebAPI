﻿using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    public class PizzaConfs : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.CookingTimeMin).IsRequired();

            builder.HasOne(x => x.PizzaSize).WithMany(x => x.Pizzas).HasForeignKey(x => x.PizzaSizeId);
            builder.HasMany(x => x.Orders).WithMany(x => x.Pizzas);

        }
    }
}
