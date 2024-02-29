namespace Domain.Entities;

/// <summary>
/// It represents that the classes inherited from it
/// are tables in the database
/// </summary>
public interface BaseEntity
{
    // The Primary Key 
    int Id { get; set; }
}
