using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.Domain;

namespace PayrollBSI.Data.Interfaces.Data
{
    public interface IEmployee : ICrud<Employee>
    {
        Task<IEnumerable<EmployeeWithRoleAndPositionName>> GetWithRoleNameAndPositionName();

        Task<IEnumerable<Employee>> GetByRoleNameAndPositionName(int id);

        Task <Employee> Login(string username, string password);
        Task<Task> ChangePassword(string username, string newPassword);

        Task<IEnumerable<Employee>> GetAllActiveEmployee();

        Task<Employee> GetByUsername(string username);
    }

}
