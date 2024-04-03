using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;

namespace PayrollBSI.BLL.Interface.BLL
{
	public interface IPayrollDetailsBLL
	{
		Task<IEnumerable<PayrollDetailsDTO>> GetAll();
		Task<IEnumerable<GetPayrollDetailsDTO>> GetPayrollDetails(int id);

		Task<PayrollDetailsCreateDTO> Insert(PayrollDetailsCreateDTO obj);
	}
}
