using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Persistence.Validation;
using System.Reflection;

namespace Persistence.Configuration;

internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        #region Properties Constrains

        builder.Property(s => s.Name)
           .IsRequired()
           .HasMaxLength(80);
        builder.Property(s => s.Location)
            .HasMaxLength(3)
            .HasDefaultValue("EG");
        builder.Property(s => s.Manager)
           .IsRequired()
           .HasMaxLength(120);

        #endregion
    }
}