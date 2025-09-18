using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;
using CRM.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Industry)
                .HasMaxLength(100);

            builder.Property(c => c.NIP)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Website)
                .HasMaxLength(300);

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(c => c.Address)
                .HasMaxLength(150);

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne<ApplicationUser>()
                .WithMany(u => u.Companies)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Contacts)
                .WithOne(cn => cn.Company)
                .HasForeignKey(cn => cn.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Leads)
                .WithOne(l => l.Company)
                .HasForeignKey(l => l.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Activities)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
