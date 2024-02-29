using Domain.Repositories;
using Services.Abstraction.ValidationsServices;
using System.ComponentModel.DataAnnotations;

namespace Services.ValidationServices;

public sealed class DepartmentValidationService : IDepartmentValidationService
{
    private readonly IAdminRepository _repository;

    public DepartmentValidationService(IAdminRepository repository) =>
        _repository = repository;
    public bool IsNameUnique(string name) =>
        _repository.DepartmentRepository.GetByName(name) == null;
}
