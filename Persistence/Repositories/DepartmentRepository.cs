using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

internal sealed class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context) =>
        _context = context;

    #region  The Implementation of CRUD operations

    public void Add(Department entity) => _context.Add(entity);

    public void Delete(Department entity) => _context.Remove(entity);

    public List<Department> GetAll() => _context.Departments
        .Include(s => s.Students).ToList();

    public Department? GetById(int id) => _context.Departments
        .Include(s => s.Students)
        .FirstOrDefault(s => s.Id == id);

    public Department? GetByName(string name) => _context.Departments
        .Include(s => s.Students)
        .FirstOrDefault(s => s.Name.ToLower() == name.ToLower());

    public void Update(Department entity) => _context.Remove(entity);

    #endregion
}
