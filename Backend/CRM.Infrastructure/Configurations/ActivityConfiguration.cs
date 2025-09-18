using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;
using CRM.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Type)
                .IsRequired();

            builder.Property(a => a.Subject)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Description)
                .HasMaxLength(1000);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(a => a.Company)
                .WithMany(c => c.Activities)
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Contact)
                .WithMany()
                .HasForeignKey(a => a.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ApplicationUser>()
                .WithMany(u => u.Activities)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
