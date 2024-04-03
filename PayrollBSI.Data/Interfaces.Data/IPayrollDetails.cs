
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.Data.Interfaces.Data
{
	public interface IPayrollDetails
	{
		Task<IEnumerable<PayrollDetails>> GetAll();
		Task<PayrollDetailsCreate> Insert(PayrollDetailsCreate obj); //void
		Task<Task> Update(PayrollDetails obj); // void
		Task Delete(int id);
		Task<IEnumerable<PayrollDetails>> GetPayrollDetails(int id);
		Task<PayrollDetails> GetById(int id);


	}
}
