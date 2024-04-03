using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.Data.Models
{
	public class EmployeeDetails
	{
		public int EmployeeID{ get; set; }
		public string EmployeeName { get; set; }
		public int RoleID { get; set; }
		public string RoleName { get; set; }
		public int PositionID { get; set; }
		public string PositionName { get; set; }
		public int IsDeleted { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }


	}
}
