namespace Services.Filters;

internal sealed class DepartmentFilterService 
    : Abstraction.Filters.IDepartmentFilterService
{
    public bool LocationFiler(string location) =>
        location == "EG" || location == "USA";
}
