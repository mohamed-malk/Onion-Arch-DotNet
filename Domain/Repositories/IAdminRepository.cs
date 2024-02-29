namespace Domain.Repositories;

/// <summary>
/// Main Repository 
/// </summary>
public interface IAdminRepository
{
    IStudentRepository StudentRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    
    /// <summary>
    /// Apply Changes in DataBase
    /// </summary>
    /// <returns>number of affected rows</returns>
    int SaveChanges();
}
