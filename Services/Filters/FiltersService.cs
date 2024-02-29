using Services.Abstraction.Filters;

namespace Services.Filters;

public sealed class FiltersService : IFiltersService
{
    private readonly IStudentFilterService _studentFiltersService;
    private readonly IDepartmentFilterService _departmentFiltersService;

    public FiltersService()
    {
        _studentFiltersService = new StudentFilterService();
        _departmentFiltersService = new DepartmentFilterService();
    }

    public IStudentFilterService StudentFilterService => _studentFiltersService;

    public IDepartmentFilterService DepartmentFilterService => _departmentFiltersService;
}
