using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

internal sealed class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context) =>
        _context = context;

    #region  The Implementation of CRUD operations

    public void Add(Student entity) => _context.Add(entity);

    public void Delete(Student entity) => _context.Remove(entity);

    public List<Student> GetAll() => _context.Students
        .Include(s => s.Department).ToList();                                     

    public Student? GetById(int id) => _context.Students
        .Include(s => s.Department)
        .FirstOrDefault(s => s.Id == id);

    public List<Student> GetByName(string name) => _context.Students
        .Where(s => s.Name.ToLower() == name.ToLower())
        .Include(s => s.Department).ToList();

    public void Update(Student entity) => _context.Update(entity);

    #endregion
}
