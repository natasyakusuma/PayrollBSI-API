using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.BLL.Interface.BLL
{
	public interface IEmployeeBLL
	{
		Task<Task> ChangePassword(string username, string newPassword);
		Task<EmployeeDTO> GetById(int id);
		Task<LoginCreateDTO> Login(string username, string password);
		Task<IEnumerable<EmployeeDTO>> GetAllActive();
		Task<IEnumerable<EmployeeDTO>> Search(string employeeName, string positionName, string roleName);

		Task<string> GetByUsername(string username);


	}
}
