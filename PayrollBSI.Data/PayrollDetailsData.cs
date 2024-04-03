using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.Data
{
	public class PayrollDetailsData : IPayrollDetails
	{
		private readonly AppDbContext _context;
		public PayrollDetailsData(AppDbContext context)
		{
			_context = context;
		}
		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}


		public async Task<IEnumerable<PayrollDetails>> GetAll()
		{
			try
			{
				var result = await _context.PayrollDetails.Include(pd => pd.Employee)
					.Select(pd => new PayrollDetails
					{
						PayrollDetailID = pd.PayrollDetailID,
						EmployeeId = pd.EmployeeId,
						PayrollDate = pd.PayrollDate,
						TotalAllowances = pd.TotalAllowances,
						TotalDeductions = pd.TotalDeductions,
						GrossPay = pd.GrossPay,
						NetPayNoTax = pd.NetPayNoTax,
						NetPayWithTax = pd.NetPayWithTax,

					}).ToListAsync();
				return result;
			}
			catch (Exception ex)
			{
				throw new ArgumentException($"Error occurred while fetching PayrollDetails: " + ex.Message);
			}
		}

		public Task<PayrollDetails> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<PayrollDetails>> GetPayrollDetails(int id)
		{
			try
			{
				var result = await _context.PayrollDetails
					.Include(pd => pd.Employee)
					.Where(pd => pd.EmployeeId == id)
					.Select(pd => new PayrollDetails
					{
						PayrollDetailID = pd.PayrollDetailID,
						EmployeeId = pd.EmployeeId,
						EmployeeName = pd.Employee.FirstName + " " + pd.Employee.LastName,
						PayrollDate = pd.PayrollDate,
						TotalAllowances = pd.TotalAllowances,
						TotalDeductions = pd.TotalDeductions,
						GrossPay = pd.GrossPay,
						NetPayNoTax = pd.NetPayNoTax,
						NetPayWithTax = pd.NetPayWithTax
					}).ToListAsync();
				return result;
			}
			catch (Exception ex)
			{
				throw new ArgumentException($"Error occurred while fetching PayrollDetails: " + ex.Message);
			}

		}


		public async Task<PayrollDetailsCreate> Insert(PayrollDetailsCreate obj)
		{
			try
			{
				_context.Database.ExecuteSqlInterpolatedAsync($"EXEC InsertPayrollDetails @PayrollDetailsCreate = {obj}");
				await _context.SaveChangesAsync();
				return obj;

			}
			catch (Exception ex)
			{
				throw new Exception("Error Insert Data : " + ex.Message);
			}
		}

		public Task<Task> Update(PayrollDetails obj)
		{
			throw new NotImplementedException();
		}

	}
}
