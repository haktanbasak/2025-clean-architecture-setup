using CleanArchitecture_2025.Domain.Employees;
using CleanArchitecture_2025.Infrastructure.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Infrastructure.Repository
{
    internal sealed class EmployeeRepository : Repository<Employee, ApplicationDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
