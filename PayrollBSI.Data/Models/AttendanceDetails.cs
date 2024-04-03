using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.Data.Models
{
	public class AttendanceDetails
	{
		public int AttendanceId { get; set; }

		public int EmployeeId  { get; set; }
		public string EmployeeName { get; set; }

		public int OvertimeHours { get; set; }

		public int RegularHours { get; set; }

		public int AttendanceTotal { get; set; }

	}
}
