using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.Data.Models
{
	public class PayrollDetails
	{

		public int PayrollDetailID{ get; set; }


		public int EmployeeId { get; set; }

		public string EmployeeName { get; set; }

		public DateOnly PayrollDate { get; set; }


		public decimal TotalAllowances { get; set; }


		public decimal TotalDeductions { get; set; }


		public decimal GrossPay { get; set; }


		public decimal NetPayNoTax { get; set; }

		public decimal NetPayWithTax { get; set; }
	}
}
