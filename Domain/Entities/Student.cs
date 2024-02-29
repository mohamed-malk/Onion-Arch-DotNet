namespace Domain.Entities;

/// <summary>
/// Student Table
/// </summary>
public class Student : BaseEntity
{
    // PK
    public int Id { get; set; }

    #region Properties

    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }

    #endregion

    #region Relation Mapping
    
    public virtual int DepartmentId { get; set; }
    public virtual Department Department { get; set; } = null!;

    #endregion
}
