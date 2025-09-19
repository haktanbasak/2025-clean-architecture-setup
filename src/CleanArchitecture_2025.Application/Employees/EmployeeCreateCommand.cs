using CleanArchitecture_2025.Domain.Employees;
using FluentValidation;
using GenericRepository;
using Mapster;
using MediatR;
using TS.Result;

namespace CleanArchitecture_2025.Application.Employees
{
    public sealed record EmployeeCreateCommand(
        string FirstName,
        string LastName,
        DateOnly BirthDate,
        decimal Salary,
        PersonelInformation PersonelInformation,
        Address? Address) : IRequest<Result<string>>;

    public sealed class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
    {
        public EmployeeCreateCommandValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.PersonelInformation.TCNo).MinimumLength(11).WithMessage("Geçerli bir TC numarası yazın.").MaximumLength(11).WithMessage("Geçerli bir TC numarası yazın.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş olamaz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş olamaz.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum tarihi alanı boş olamaz.");
            RuleFor(x => x.Salary).GreaterThan(0).WithMessage("Maaş 0'dan büyük olmalıdır.");
            RuleFor(x => x.PersonelInformation.TCNo).NotEmpty().WithMessage("TC Kimlik Numarası boş olamaz.");
        }
    }
    internal sealed class EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) : IRequestHandler<EmployeeCreateCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var isEmployeeExists = await employeeRepository.AnyAsync(x => x.PersonelInformation.TCNo == request.PersonelInformation.TCNo, cancellationToken);
            if (isEmployeeExists)
            {
                return Result<string>.Failure("Bu TC Kimlik Numarasına sahip personel zaten kayıtlı.");
            }

            Employee employee = request.Adapt<Employee>();

            employeeRepository.Add(employee);
            
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Personel kaydı başarıyla tamamlandı.";
        }
    }
}