using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.Domain;

namespace PayrollBSI.BLL.Interface.BLL
{
    public interface IEmployeeBLL
    {
        Task<Task> ChangePassword(string username, string newPassword);
        Task<IEnumerable<EmployeeDTO>> GetAll();
        Task<EmployeeDTO> GetById(int id);
        Task<EmployeeDTO> Insert(EmployeeDTO obj);
        Task<EmployeeDTO> Update(int id, EmployeeDTO obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<EmployeeWithNameDTO>> GetWithRoleNameAndPositionName();
        Task<IEnumerable<EmployeeWithNameDTO>> GetByRoleNameAndPositionName(int id);
        Task<LoginCreateDTO> Login(string username, string password);
        Task<IEnumerable<EmployeeDTO>> GetAllActiveEmployee();
        Task<EmployeeDTO> GetByUsername(string username);


    }
}
