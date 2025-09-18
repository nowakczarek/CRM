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
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(l => l.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(l => l.Stage)
                .IsRequired();

            builder.Property(l => l.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne<ApplicationUser>()
                .WithMany(u => u.Leads)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Contact)
                .WithMany(c => c.Leads)
                .HasForeignKey(l => l.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Company)
                .WithMany(c => c.Leads)
                .HasForeignKey(l => l.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
