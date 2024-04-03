
using System.Collections.Generic;
using AutoMapper;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;
using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.BLL
{
	public class AttendanceBLL : IAttendanceBLL
	{
		private readonly IAttendance _attendanceData;
		private readonly IMapper _mapper;

		public AttendanceBLL(IAttendance attendance, IMapper mapper)
		{
			_attendanceData = attendance;
			_mapper = mapper;
		}

		public async Task<IEnumerable<AttendanceDTO>> GetAll()
		{
			try
			{
				var attendances = await _attendanceData.GetAll();
				var attendanceDto = _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
				return attendanceDto;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<AttendanceDTO>> GetByEmployeeId(int employeeId)
		{
			try
			{
				var attendances = await _attendanceData.GetByEmployeeID(employeeId);
				var attendanceDto = _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
				return attendanceDto;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while getting attendance data by employee ID.", ex);
			}
		}



		public async Task<AttendanceDTO> GetById(int id)
		{
			try
			{
				var attendance = await _attendanceData.GetById(id);
				var attendanceDto = _mapper.Map<AttendanceDTO>(attendance);
				return attendanceDto;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<AttendanceDTO> Insert(AttendanceCreateDTO obj)
		{
			try
			{
				var attendanceDetails = _mapper.Map<Attendance>(obj);
				var createdAttendanceDetails = await _attendanceData.Insert(attendanceDetails);
				var attendanceDTO = _mapper.Map<AttendanceDTO>(createdAttendanceDetails);

				var attendanceWithEmployee = await _attendanceData.GetById(attendanceDTO.AttendanceID);
				attendanceDTO = _mapper.Map<AttendanceDTO>(attendanceWithEmployee);

				return attendanceDTO;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while inserting attendance.", ex);
			}
		}



		public async Task<IEnumerable<AttendanceDTO>> Search(string employeeName)
		{
			try
			{
				var attendance = await _attendanceData.Search(employeeName);
				var attendanceDto = _mapper.Map<IEnumerable<AttendanceDTO>>(attendance);
				return attendanceDto;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task<AttendanceDTO> Update(int id, AttendanceUpdateDTO obj)
		{
			throw new NotImplementedException();
		}
	}
}
