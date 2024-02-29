using Domain.Repositories;
using Services.Abstraction.DataServices;

namespace Services.DataServices;

public sealed class AdminService : IAdminService
{
    private readonly IStudentService _studentService;
    private readonly IDepartmentService _departmentService;
    public AdminService(IAdminRepository repositoryAdmin)
    {
        _studentService = new StudentService(repositoryAdmin);
        _departmentService = new DepartmentService(repositoryAdmin);
    }
    public IStudentService StudentService => _studentService;
    public IDepartmentService DepartmentService => _departmentService;
}
