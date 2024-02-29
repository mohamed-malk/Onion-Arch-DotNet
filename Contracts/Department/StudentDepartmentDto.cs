namespace Contracts.Department;

/// <summary>
/// Department Data with its Studends
/// </summary>
public struct DepartmentStudentsDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Students Names
    /// </summary>
    public List<string> Students { get; set;}
}
