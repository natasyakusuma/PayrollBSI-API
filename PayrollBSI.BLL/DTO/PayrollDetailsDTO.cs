using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
	public class PayrollDetailsDTO
	{

		public int PayrollDetailId { get; set; }


		public int EmployeeId { get; set; }

		public DateOnly PayrollDate { get; set; }


		public decimal TotalAllowances { get; set; }


		public decimal TotalDeductions { get; set; }


		public decimal GrossPay { get; set; }


		public decimal NetPayNoTax { get; set; }

		public decimal NetPayWithTax { get; set; }
	}
}
