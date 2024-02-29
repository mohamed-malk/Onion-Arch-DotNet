using Domain.Entities;

namespace Domain.Repositories;

/// <summary>
/// Define CRUD Operations (Shared) for all Tables
/// </summary>
public interface IEntityRepository<T> where T : BaseEntity
{
    #region C > Create Operation

    /// <summary>
    /// Add new Entity to <see cref="DbContext"/>
    /// </summary>
    /// <param name="entity"><see cref="BaseEntity"/>object</param>
    void Add(T entity);

    #endregion

    #region R > Retrive Operation 

    /// <summary>
    /// Get All entities from a Table 
    /// </summary>
    /// <returns><see cref="List{T}"/></returns>
    List<T> GetAll();

    /// <summary>
    /// Get particular Entity by Primary Key
    /// </summary>
    /// <param name="id">Primary Key value</param>
    /// <returns>in case entity is exist <see cref="BaseEntity"/>, otherwise null</returns>
    T? GetById(int id);

    #endregion

    #region U > Update

    /// <summary>
    /// Update Entity object in <see cref="DbContext"/>
    /// </summary>
    /// <param name="entity"><see cref="BaseEntity"/> object</param>
    void Update(T entity);

    #endregion

    #region D > Delete

    /// <summary>
    /// Delete Entity object from <see cref="DbContext"/>
    /// </summary>
    /// <param name="entity"><see cref="BaseEntity"/> object</param>
    void Delete(T entity);

    #endregion
}
