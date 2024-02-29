namespace Services.Abstraction.DataServices;

/// <summary>
/// Deal with Service throgh <see cref="IAdminService"/> 
/// </summary>
public interface IAdminService
{
    IStudentService StudentService { get; }
    IDepartmentService DepartmentService { get; }
}
