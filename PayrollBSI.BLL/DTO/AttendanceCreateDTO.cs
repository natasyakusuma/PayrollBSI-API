using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
    public class AttendanceCreateDTO
    {
		public int EmployeeID { get; set; }
		public int OvertimeHours { get; set; }
		public int RegularHours { get; set; }
		public int AttendanceTotal { get; set; }
	}
}
