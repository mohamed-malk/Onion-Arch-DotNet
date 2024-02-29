using Domain.Repositories;
using Contracts.Student;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Enums;
using Mapster;
using Services.Abstraction.DataServices;


namespace Services.DataServices;

internal sealed class StudentService : IStudentService
{
    private readonly IAdminRepository _repository;

    public StudentService(IAdminRepository repository) =>
        _repository = repository;

    /// <summary>
    /// Add new Student to DataBase
    /// </summary>
    public void Add(string name, int age, string address,
        string? image, int deptId)
    {
        _repository.StudentRepository.Add(new()
        {
            Name = name,
            Age = age,
            Address = address,
            Image = image,
            DepartmentId = deptId
        });

        _repository.SaveChanges();
    }

    /// <summary>
    /// Delete Student From DataBase
    /// </summary>
    /// <param name="id">student Id</param>
    /// <exception cref="NotFoundException"></exception>
    public void Delete(int id)
    {
        Student? student = _repository.StudentRepository.GetById(id);
        if (student is null)
            throw new NotFoundException("Student");
        else
        {
            _repository.StudentRepository.Delete(student);
            _repository.SaveChanges();
        }
    }

    /// <summary>
    /// Get All Student
    /// </summary>
    /// <returns><see cref="List{T}"/> Students</returns>
    public List<StudentDepartmentDto> GetAll()
    {
        var students = _repository.StudentRepository.GetAll();

        return students.Adapt<List<StudentDepartmentDto>>();
    }

    /// <summary>
    /// Get Student From DataBase
    /// </summary>
    /// <param name="id">student Id</param>
    /// <returns>Student View</returns>
    public StudentDepartmentDto? GetById(int id)
    {
        Student? student = _repository.StudentRepository.GetById(id);

        return student.Adapt<StudentDepartmentDto?>();
    }

    /// <summary>
    /// Get Students by nameFrom DataBase
    /// </summary>
    /// <param name="name">Name</param>
    /// <returns>List of Student View</returns>
    public List<StudentDto> GetByName(string name)
    {
        var students = _repository.StudentRepository.GetByName(name);

        return students.Adapt<List<StudentDto>>();
    }

    /// <summary>
    /// Update Entity by Primary Key in DataBase
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
        Student? student = _repository.StudentRepository.GetById(id);
        if (student is null)
            throw new NotFoundException("Student");

        foreach (var item in newValues)
        {
            switch (item.Key)
            {
                case Properties.Name:
                    student.Name = item.Value.ToString()!;
                    break;

                case Properties.Age:
                    student.Age = int.Parse(item.Value);
                    break;
                case Properties.Address:
                    student.Address = item.Value.ToString();
                    break;
                case Properties.Image:
                    student.Image = item.Value.ToString();
                    break;
                default:
                    throw new PropertyException(item.Key.ToString());
            }
        }

        _repository.StudentRepository.Update(student);
        _repository.SaveChanges();
    }
}
