using Contracts.Student;
using Domain.Enums;

namespace Services.Abstraction.DataServices;

/// <summary>
/// Define the Business Logic that apply on Student
/// </summary>
public interface IStudentService
{
    #region C > Create Operation

    /// <summary>
    /// Add new Student with thier data to <see cref="DbContext"/>
    /// </summary>
    void Add(string name, int age, string address, string? image, int deptId);

    #endregion

    #region R > Retrive Operation 

    /// <summary>
    /// Get All Students from a Table 
    /// </summary>
    /// <returns><see cref="List{T}"/></returns>
    List<StudentDepartmentDto> GetAll();

    /// <summary>
    /// Get particular Student by Primary Key
    /// </summary>
    /// <param name="id">Primary Key value</param>
    /// <returns>in case entity is exist <see cref="StudentDepartmentDto"/>, otherwise null</returns>
    StudentDepartmentDto? GetById(int id);

    /// <summary>
    /// Get Students that their name is <paramref name="name"/>
    /// </summary>
    /// <param name="name">Primary Key value</param>
    /// <returns>in case entity is exist <see cref="List{T}"/> Students</returns>
    List<StudentDto> GetByName(string name);

    #endregion

    #region U > Update

    /// <summary>
    /// Update Student by Primary Key in <see cref="DbContext"/>
    /// Update using <see cref="Dictionary{TKey, TValue}"/>
    /// <para>
    /// TKey : Property Name | TValue : new or update value
    /// </para>
    /// </summary>
    /// <param name="id">Primary Key value</param>
    /// <param name="newValues">new Values</param>
    void Update(int id, Dictionary<Properties, string> newValues);

    #endregion

    #region D > Delete

    /// <summary>
    /// Delete Student by Primary Key from <see cref="DbContext"/>
    /// </summary>
    /// <param name="id">Primary Key Value</param>
    void Delete(int id);

    #endregion
}
