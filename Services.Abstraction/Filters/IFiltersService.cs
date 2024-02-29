namespace Services.Abstraction.Filters;

public interface IFiltersService
{
    public IStudentFilterService StudentFilterService { get; }
    public IDepartmentFilterService DepartmentFilterService { get; }
}
