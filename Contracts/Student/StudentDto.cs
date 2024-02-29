namespace Contracts.Student;

/// <summary>
/// Student Data only
/// </summary>
public struct StudentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }
}
