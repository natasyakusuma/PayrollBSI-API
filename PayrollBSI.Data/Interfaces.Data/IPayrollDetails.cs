using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.Domain;

namespace PayrollBSI.Data.Interfaces.Data
{
    public interface IPayrollDetails
    {
        Task<IEnumerable<PayrollDetail>> GetAll();
        Task<PayrollDetail> Get(int id);
        Task<Task> Insert(PayrollDetailsCreate obj); //void
        Task<Task> Update(PayrollDetail obj); // void
        Task Delete(int id);
    }
}
