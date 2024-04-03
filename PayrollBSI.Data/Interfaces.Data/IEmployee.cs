using PayrollBSI.Data.Models;
using PayrollBSI.Domain;


namespace PayrollBSI.Data.Interfaces.Data
{
	public interface IEmployee 
	{
		Task<EmployeeDetails> GetById(int id);
		Task<Employee> Login(string username, string password);
		Task<Task> ChangePassword(string username, string newPassword);
		Task<string> GetByUsername(string username);
		Task<IEnumerable<EmployeeDetails>> Search (string employeeName, string positionName, string roleName);
		Task<IEnumerable<EmployeeDetails>> GetAllActive();
	}

}
