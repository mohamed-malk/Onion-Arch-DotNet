using Services.Abstraction.ValidationsServices;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Validation;
public class DepartmentNameUniqueAttribute : ValidationAttribute
{
    private readonly IValidationsService _validationsService;
    public DepartmentNameUniqueAttribute(IValidationsService validationsService) =>
        _validationsService = validationsService;
   
    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        return _validationsService
            .DepartmentValidationService
            .IsNameUnique(value.ToString()!);
    }
}