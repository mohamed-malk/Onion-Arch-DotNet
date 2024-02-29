using Domain.Entities;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Repositories;
using Persistence.Validation;
using Services.ValidationServices;

namespace Persistence.Context;

public partial class ApplicationDbContext
{
    // 😐😐
    private void VaidateDepartment(object department)
    {
        var validation = new DepartmentNameUniqueAttribute(
                                       new ValidationsService(
                                           new AdminRepository(this)));

        if (department == null)
            throw new ArgumentNullException(nameof(department));
        if (department is Department)
        {
            var departmentObj = department as Department;
            if (!validation.IsValid(departmentObj!.Name))
                throw new AlreadyExistException("Department");
        }
    }
    public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
    {
        VaidateDepartment(entity);
        return base.Add(entity);

    }
    public override EntityEntry Add(object entity)
    {
        VaidateDepartment(entity);
        return base.Add(entity);
    }
}
