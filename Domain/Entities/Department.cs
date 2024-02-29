namespace Domain.Entities;

/// <summary>
/// Department Table
/// </summary>
public class Department : BaseEntity
{
    // PK
    public int Id { get; set; }

    #region Properties

    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Manager { get; set; } = null!;
    
    #endregion

    // Avoid Join Statements 
    public virtual List<Student> Students { get; set; } = null!;
}
