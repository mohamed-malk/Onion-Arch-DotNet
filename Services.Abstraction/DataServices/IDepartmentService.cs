using Contracts.Department;
using Domain.Enums;

namespace Services.Abstraction.DataServices;

/// <summary>
/// Define the Business Logic that apply on Department
/// </summary>
public interface IDepartmentService
{
    #region C > Create Operation

    /// <summary>
    /// Add new Department with thier data to <see cref="DbContext"/>
    /// </summary>
    void Add(string name, string location, string manager);

    #endregion

    #region R > Retrive Operation 

    /// <summary>
    /// Get All Students from a Table 
    /// </summary>
    /// <returns><see cref="List{T}"/></returns>
    List<DepartmentDto> GetAll();

    /// <summary>
    /// Get particular Department by Primary Key
    /// </summary>
    /// <param name="id">Primary Key value</param>
    /// <returns>in case entity is exist <see cref="DepartmentDto"/>, otherwise null</returns>
    DepartmentDto? GetById(int id);

    /// <summary>
    /// Get Departments that their name is <paramref name="name"/>
    /// </summary>
    /// <param name="name">Primary Key value</param>
    /// <returns>in case entity is exist <see cref="DepartmentDto"/>, otherwise null</returns>
    DepartmentDto? GetByName(string name);

    #endregion

    #region U > Update

    /// <summary>
    /// Update Department by Primary Key in <see cref="DbContext"/>
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
    /// Delete Department by Primary Key from <see cref="DbContext"/>
    /// </summary>
    /// <param name="id">Primary Key Value</param>
    void Delete(int id);

    #endregion
}
