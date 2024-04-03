using Microsoft.EntityFrameworkCore;
using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.Data
{
	public class AttendanceData : IAttendance
	{
		private readonly AppDbContext _context;

		public AttendanceData(AppDbContext context)
		{
			_context = context;
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<AttendanceDetails>> GetAll()
		{
			try
			{
				var attendanceData = await _context.Attendances
					.Select(a => new AttendanceDetails
					{
						AttendanceId = a.AttendanceId,
						EmployeeId = a.EmployeeId,
						EmployeeName = $"{a.Employee.FirstName} {a.Employee.LastName}",
						OvertimeHours = a.OvertimeHours,
						RegularHours = a.RegularHours,
						AttendanceTotal = a.AttendanceTotal
					}).ToListAsync();
				if (attendanceData == null)
				{
					throw new Exception("No Attendance Data Found");
				}

				return attendanceData;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<AttendanceDetails>> GetByEmployeeID(int EmployeeID)
		{
			try
			{
				var attendanceData = await _context.Attendances
					.Where(a => a.EmployeeId == EmployeeID)
					.Select(a => new AttendanceDetails
					{
						AttendanceId = a.AttendanceId,
						EmployeeId = a.EmployeeId,
						EmployeeName = $"{a.Employee.FirstName} {a.Employee.LastName}",
						OvertimeHours = a.OvertimeHours,
						RegularHours = a.RegularHours,
						AttendanceTotal = a.AttendanceTotal
					})
					.ToListAsync();

				if (attendanceData == null || !attendanceData.Any())
				{
					throw new Exception($"No attendance data found for employee with ID {EmployeeID}");
				}

				return attendanceData;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error retrieving attendance data for employee with ID {EmployeeID}: {ex.Message}");
			}
		}

		public async Task<Attendance> GetById(int id)
		{
			var attendance = await _context.Attendances
				.Include(e => e.Employee).SingleOrDefaultAsync(a => a.AttendanceId == id);
			return attendance;
		}

		public async Task<Attendance> Insert(Attendance obj)
		{
			_context.Attendances.Add(obj);
			await _context.SaveChangesAsync();
			return obj;
		}

		public Task<AttendanceDetails> Insert(AttendanceDetails obj)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<AttendanceDetails>> Search(string employeeName)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(employeeName))
				{
					throw new ArgumentException("You must provide the employeeName for search.");
				}

				var query = _context.Attendances
					.Where(a => a.Employee.FirstName.Contains(employeeName) || a.Employee.LastName.Contains(employeeName))
					.Select(a => new AttendanceDetails
					{
						AttendanceId = a.AttendanceId,
						EmployeeId = a.EmployeeId,
						EmployeeName = $"{a.Employee.FirstName} {a.Employee.LastName}",
						OvertimeHours = a.OvertimeHours,
						RegularHours = a.RegularHours,
						AttendanceTotal = a.AttendanceTotal
					});

				var attendanceData = await query.ToListAsync();
				return attendanceData;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while searching for attendance data: " + ex.Message);
			}
		}


		public Task<AttendanceDetails> Update(int id, AttendanceDetails obj)
		{
			throw new NotImplementedException();
		}

		Task<AttendanceDetails> ICrud<AttendanceDetails>.GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
