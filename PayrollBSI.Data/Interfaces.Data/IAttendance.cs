using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.Data.Interfaces.Data
{
    public interface IAttendance : ICrud<AttendanceDetails>
    {
		Task<Attendance> Insert(Attendance obj);
		Task<Attendance> GetById(int id);
		Task<IEnumerable<AttendanceDetails>> GetByEmployeeID(int employeeID);
		Task<IEnumerable<AttendanceDetails>> Search(string employeeName);

	}
}
