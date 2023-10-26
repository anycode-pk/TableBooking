using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBooking.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableBooking.Model.Models;


namespace TableBooking.Model.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {

        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Date).IsRequired();
            builder.Property(b => b.DurationInMinutes).IsRequired();
            builder.Property(b => b.UserId).IsRequired();

            // Configure any other settings or relationships here
        }
    }
}

