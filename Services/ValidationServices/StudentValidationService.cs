using Domain.Repositories;
using Services.Abstraction.ValidationsServices;

namespace Services.ValidationServices
{
    internal class StudentValidationService : IStudentValidationService
    {
        private readonly IAdminRepository _repository;

        public StudentValidationService(IAdminRepository repository) =>
            _repository = repository;
    }
}
