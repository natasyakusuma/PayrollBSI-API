using PayrollBSI.Data.Interfaces;
using PayrollBSI.Domain;
using Microsoft.EntityFrameworkCore;
using PayrollBSI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollBSI.Data.Interfaces.Data;

namespace PayrollBSI.Data
{
	public class EmployeeData : IEmployee
	{
		private readonly AppDbContext _context;

		public EmployeeData(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Task> ChangePassword(string username, string newPassword)
		{
			try
			{
				var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Username == username);
				if (employee == null)
				{
					throw new ArgumentException("User Not Found");
				}
				employee.Password = Helpers.Md5Hash.GetHash(newPassword);
				await _context.SaveChangesAsync();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception("Error at change the password" + ex.Message);
			}
		}

		public async Task<IEnumerable<EmployeeDetails>> GetAllActive()
		{
			try
			{
				var employeeData = await _context.Employees
				.Select(e => new EmployeeDetails
				{
					EmployeeID = e.EmployeeID,
					EmployeeName = $"{e.FirstName} {e.LastName}",
					RoleID = e.RoleID,
					RoleName = e.Role.RoleName,
					PositionID = e.PositionID,
					PositionName = e.Position.PositionName,
					IsDeleted = e.IsDeleted,
					Username = e.Username,
					Password = e.Password

				}).ToListAsync();
				if (employeeData == null || !employeeData.Any())
				{
					throw new Exception("No Employee Data Found");
				}
				return employeeData;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<EmployeeDetails> GetById(int id)
		{
			try
			{
				var employeeData = await _context.Employees
					.Where(e => e.EmployeeID == id)
					.Select(e => new EmployeeDetails
					{
						EmployeeID = e.EmployeeID,
						EmployeeName = $"{e.FirstName} {e.LastName}",
						RoleID = e.RoleID,
						RoleName = e.Role.RoleName,
						PositionID = e.PositionID,
						PositionName = e.Position.PositionName,
						IsDeleted = e.IsDeleted,
						Username = e.Username,
						Password = e.Password
					}).FirstOrDefaultAsync();

				if (employeeData == null)
				{
					throw new Exception("No Employee Data Found");
				}

				return employeeData;
			}
			catch (Exception ex)
			{
				throw new Exception("Error fetching employee data by ID: " + ex.Message);
			}
		}


		public async Task<IEnumerable<EmployeeDetails>> Search(string employeeName, string positionName, string roleName)
		{
			try
			{
				// Check if at least one of the parameters is provided
				if (string.IsNullOrWhiteSpace(employeeName) && string.IsNullOrWhiteSpace(positionName) && string.IsNullOrWhiteSpace(roleName))
				{
					throw new ArgumentException("At least one of the parameters (employeeName, positionName, roleName) must be provided for search.");
				}

				var query = _context.Employees.AsQueryable();

				// Filter by employee name if provided
				if (!string.IsNullOrWhiteSpace(employeeName))
				{
					query = query.Where(e => e.FirstName.Contains(employeeName) || e.LastName.Contains(employeeName));
				}

				// Filter by position name if provided
				if (!string.IsNullOrWhiteSpace(positionName))
				{
					query = query.Where(e => e.Position.PositionName.Contains(positionName));
				}

				// Filter by role name if provided
				if (!string.IsNullOrWhiteSpace(roleName))
				{
					query = query.Where(e => e.Role.RoleName.Contains(roleName));
				}

				var employeeData = await query
					.Select(e => new EmployeeDetails
					{
						EmployeeID = e.EmployeeID,
						EmployeeName = $"{e.FirstName} {e.LastName}",
						RoleID = e.RoleID,
						RoleName = e.Role.RoleName,
						PositionID = e.PositionID,
						PositionName = e.Position.PositionName,
						IsDeleted = e.IsDeleted,
						Username = e.Username,
						Password = e.Password
					}).ToListAsync();

				return employeeData;
			}
			catch (Exception ex)
			{
				throw new Exception("Error occurred while searching for employees: " + ex.Message);
			}
		}






		public async Task<string> GetByUsername(string username)
		{
			try
			{
				var employeeData = await _context.Employees
					.Where(e => e.Username == username)
					.Select(e => new EmployeeDetails
					{
						Username = e.Username
					})
					.FirstOrDefaultAsync();

				if (employeeData == null)
				{
					throw new Exception("Username Employee Isn't Exist");
				};
				return username;

			}
			catch (Exception ex)
			{
				throw new Exception("Error fetching employee with this Username: " + ex.Message);
			}
		}



		public async Task<Employee> Login(string username, string password)
		{
			try
			{
				string hashedPassword = Helpers.Md5Hash.GetHash(password);
				var user = await _context.Employees.FirstOrDefaultAsync(e => e.Username == username && e.Password == hashedPassword);
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception("Not Able to Login" + ex.Message);
			}
		}

	}
}
