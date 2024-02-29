using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        #region Properties Constrains
       
        builder.Property(s => s.Name)
           .IsRequired()
           .HasMaxLength(80);
        builder.Property(s => s.Address)
            .HasMaxLength(120)
            .HasDefaultValue("Cairo");
        builder.Property(s => s.Age)
            .IsRequired();
        
        #endregion

        // RelationShip Mapping
        builder
            .HasOne(b => b.Department).WithMany(b => b.Students)
            .HasForeignKey(b => b.DepartmentId);

        // Other Constraints
        builder.ToTable(b =>
        b.HasCheckConstraint("ImageExtenstions",
            "[Image] like '%.png'"));
    }
}
