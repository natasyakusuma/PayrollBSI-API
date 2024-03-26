using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.Domain;

namespace PayrollBSI.Data.Interfaces.Data
{
    public interface IAttendance : ICrud<Attendance>
    {
        Task<IEnumerable<Attendance>> GetAttendanceByEmployeeID(int employeeID);
        Task<IEnumerable<Attendance>> GetAttendanceByEmployeeName(string employeeName);
        Task<IEnumerable<Attendance>> GetAttendanceWithEmployeeName(string employeeName);
    }
}
