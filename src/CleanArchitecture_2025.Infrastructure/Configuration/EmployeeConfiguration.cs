using CleanArchitecture_2025.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Infrastructure.Configuration
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //PersonelInformation ve Address'i ayrı tablo olarak değil de içinde bulunan propertyleri Employee tablosunda sütun olarak eklemek için
            builder.OwnsOne(p => p.PersonelInformation, builder =>
            {
                builder.Property(i => i.TCNo).HasColumnName("TCNO");
                builder.Property(i => i.Phone1).HasColumnName("Phone1");
                builder.Property(i => i.Phone2).HasColumnName("Phone2");
                builder.Property(i => i.Email).HasColumnName("Email");
            });

            builder.OwnsOne(p => p.Address, builder =>
            {
                builder.Property(i => i.Country).HasColumnName("Country");
                builder.Property(i => i.City).HasColumnName("City");
                builder.Property(i => i.Town).HasColumnName("Town");
                builder.Property(i => i.FullAddress).HasColumnName("FullAddress");
            });

            builder.Property(i => i.Salary).HasColumnType("money");
        }
    }
}
