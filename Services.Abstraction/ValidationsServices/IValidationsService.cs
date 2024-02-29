namespace Services.Abstraction.ValidationsServices;

public interface IValidationsService
{
   IDepartmentValidationService DepartmentValidationService { get; }
   IStudentValidationService StudentValidationService { get; }
}
