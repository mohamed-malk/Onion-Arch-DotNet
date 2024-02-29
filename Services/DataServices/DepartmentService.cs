using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Contracts.Department;
using Services.Abstraction.DataServices;


namespace Services.DataServices;

internal sealed class DepartmentService : IDepartmentService
{
    private readonly IAdminRepository _repository;

    public DepartmentService(IAdminRepository repository) =>
        _repository = repository;

    /// <summary>
    /// Add new Department to DataBase
    /// </summary>
    public void Add(string name, string location, string manager)
    {
        _repository.DepartmentRepository.Add(new()
        {
            Name = name,
            Location = location,
            Manager = manager
        });

        _repository.SaveChanges();
    }

    /// <summary>
    /// Delete Department From DataBase
    /// </summary>
    /// <param name="id">Department Id</param>
    /// <exception cref="NotFoundException"></exception>
    public void Delete(int id)
    {
        Department? department = _repository.DepartmentRepository.GetById(id);
        if (department is null)
            throw new NotFoundException("Department");
        else
        {
            _repository.DepartmentRepository.Delete(department);
            _repository.SaveChanges();
        }
    }

    /// <summary>
    /// Get All Departments
    /// </summary>
    /// <returns><see cref="List{T}"/> Department</returns>
    public List<DepartmentDto> GetAll()
    {
        var departments = _repository.DepartmentRepository.GetAll();

        return departments.Adapt<List<DepartmentDto>>();
    }

    /// <summary>
    /// Get Department From DataBase
    /// </summary>
    /// <param name="id">department Id</param>
    /// <returns>Department View</returns>
    public DepartmentDto? GetById(int id)
    {
        Department? department = _repository.DepartmentRepository.GetById(id);

        return department.Adapt<DepartmentDto?>();
    }

    /// <summary>
    /// Get Department by nameFrom DataBase
    /// </summary>
    /// <param name="name">Name</param>
    /// <returns>Department View</returns>
    public DepartmentDto? GetByName(string name)
    {
        var department = _repository.DepartmentRepository.GetByName(name);

        return department.Adapt<DepartmentDto?>();
    }

    /// <summary>
    /// Update Department by Primary Key in DataBase
    /// Update using <see cref="Dictionary{TKey, TValue}"/>
    /// <para>
    /// TKey : Property Name | TValue : new or update value
    /// </para>
    /// </summary>
    /// <param name="id">Primary Key value</param>
    /// <param name="newValues">new Values</param>
    /// <exception cref="NotFoundException"></exception>
    /// <exception cref="PropertyException"></exception>
    public void Update(int id, Dictionary<Properties, string> newValues)
    {
        Department? department = _repository.DepartmentRepository.GetById(id);
        if (department is null)
            throw new NotFoundException("Department");

        foreach (var item in newValues)
        {
            switch (item.Key)
            {
                case Properties.Name:
                    department.Name = item.Value.ToString()!;
                    break;

                case Properties.Location:
                    department.Location = item.Value;
                    break;
                case Properties.Manager:
                    department.Manager = item.Value.ToString();
                    break; ;
                default:
                    throw new PropertyException(item.Key.ToString());
            }
        }

        _repository.DepartmentRepository.Update(department);
        _repository.SaveChanges();
    }
}
