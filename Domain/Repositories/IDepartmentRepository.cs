using Domain.Entities;

namespace Domain.Repositories;

/// <summary>
/// Define CRUD Operations for Department Table
/// </summary>
public interface IDepartmentRepository :
    IEntityRepository<Department>
{
    /// <summary>
    /// Get Department that its name is <paramref name="name"/>
    /// </summary>
    /// <param name="name">Primary Key value</param>
    /// <returns>in case entity is exist <see cref="Department"/>, otherwise null</returns>
    Department? GetByName(string name);
}
