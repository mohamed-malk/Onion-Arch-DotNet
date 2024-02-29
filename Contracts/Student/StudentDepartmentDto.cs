namespace Contracts.Student;

/// <summary>
/// Student Data with his Department Name
/// </summary>
public struct StudentDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }

    public string DepartmentName { get; set; }
}
