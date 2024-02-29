namespace Contracts.Student;

/// <summary>
/// Data of Student to Create New Object
/// </summary>
public struct StudentCreateDto
{
    //public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }
    public int DepartmentId { get; set; }
}
