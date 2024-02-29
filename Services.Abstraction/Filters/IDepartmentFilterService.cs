namespace Services.Abstraction.Filters;

public interface IDepartmentFilterService
{
    /// <summary>
    /// Restract the location  
    /// </summary>
    /// <param name="location">location property value</param>
    /// <returns>pass filter or not</returns>
    public bool LocationFiler(string location);
}
