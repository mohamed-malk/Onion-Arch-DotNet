using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public sealed class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;
    
    private IStudentRepository? _studentRepository;
    private IDepartmentRepository? _departmentRepository;

    public AdminRepository(ApplicationDbContext context)
        => _context = context;


    public IStudentRepository StudentRepository
    {
        get
        {
            if (_studentRepository == null) 
                _studentRepository = new StudentRepository(_context);
        
            return _studentRepository;
        }
    }

    public IDepartmentRepository DepartmentRepository
    {
        get
        {
            if (_departmentRepository == null)
                _departmentRepository = new DepartmentRepository(_context);
           
            return _departmentRepository;
        }
    }

    public int SaveChanges() => _context.SaveChanges();
}
