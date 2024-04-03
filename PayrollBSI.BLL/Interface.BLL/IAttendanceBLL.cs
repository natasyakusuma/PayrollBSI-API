
using PayrollBSI.BLL.DTO;
using PayrollBSI.Data.Models;

namespace PayrollBSI.BLL.Interface.BLL
{
    public interface IAttendanceBLL
    {
        Task<IEnumerable<AttendanceDTO>> GetAll();
        Task<AttendanceDTO> GetById(int id);
		Task<IEnumerable<AttendanceDTO>> Search(string employeeName);
		Task<AttendanceDTO> Insert(AttendanceCreateDTO obj);
		Task<AttendanceDTO> Update(int id, AttendanceUpdateDTO obj);
		Task<IEnumerable<AttendanceDTO>> GetByEmployeeId(int employeeId);

    }
}
