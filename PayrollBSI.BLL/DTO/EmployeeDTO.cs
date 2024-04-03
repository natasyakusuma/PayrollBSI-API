using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PayrollBSI.BLL.DTO
{
	public class EmployeeDTO
	{
		public int EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public int PositionId { get; set; }
		public string PositionName { get; set; }
		public int IsDeleted { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }


	}
}
