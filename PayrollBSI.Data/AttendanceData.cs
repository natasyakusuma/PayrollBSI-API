using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.Data.Interfaces.Data;
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

        public Task<IEnumerable<Attendance>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetAttendanceByEmployeeID(int employeeID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetAttendanceByEmployeeName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetAttendanceWithEmployeeName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> Insert(Attendance obj)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> Update(int id, Attendance obj)
        {
            throw new NotImplementedException();
        }
    }
}
