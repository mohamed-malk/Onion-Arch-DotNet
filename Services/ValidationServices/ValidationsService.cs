using Domain.Repositories;
using Services.Abstraction.ValidationsServices;

namespace Services.ValidationServices;

public sealed class ValidationsService : IValidationsService
{
    IDepartmentValidationService _departmentValidationService;
    IStudentValidationService _studentValidationService;

    public ValidationsService(IAdminRepository repositoryAdmin)
    {
        _departmentValidationService = new DepartmentValidationService(repositoryAdmin);
        _studentValidationService = new StudentValidationService(repositoryAdmin);
    }
    public IDepartmentValidationService DepartmentValidationService =>
        _departmentValidationService;

    public IStudentValidationService StudentValidationService => _studentValidationService;

}
