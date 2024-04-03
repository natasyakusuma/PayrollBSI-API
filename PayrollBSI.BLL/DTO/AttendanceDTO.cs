using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
    public class AttendanceDTO
    {
		public int AttendanceID { get; set; }
		public int EmployeeID { get; set; }
		public int OvertimeHours { get; set; }
		public int RegularHours { get; set; }
		public int AttendanceTotal { get; set; }

		public EmployeeDTO Employee { get; set; }

	}
}
