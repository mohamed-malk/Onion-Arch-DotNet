namespace Services.Abstraction.ValidationsServices
{
    public interface IDepartmentValidationService
    {
        bool IsNameUnique(string name);
    }
}
