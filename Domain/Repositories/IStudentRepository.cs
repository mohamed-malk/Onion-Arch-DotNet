using Domain.Entities;

namespace Domain.Repositories;

/// <summary>
/// Define CRUD Operations for Student Table
/// </summary>
public interface IStudentRepository:
    IEntityRepository<Student>
{
    /// <summary>
    /// Get Students that their name is <paramref name="name"/>
    /// </summary>
    /// <param name="id">Primary Key value</param>
    /// <returns><see cref="List{T}"/></returns>
    List<Student> GetByName(string name);
}
