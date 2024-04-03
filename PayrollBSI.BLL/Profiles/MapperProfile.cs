using AutoMapper;
using PayrollBSI.BLL.DTO;
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.API.Profiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			//Position Mapping
			CreateMap<Position, PositionDTO>().ReverseMap();
			CreateMap<PositionCreateDTO, Position>().ReverseMap();
			CreateMap<PositionUpdateDTO, Position>().ReverseMap();

			//Employee Mapping
			CreateMap<EmployeeDetails, EmployeeDTO>().ReverseMap();
			CreateMap<Employee, EmployeeDTO>().ReverseMap();
			CreateMap<Employee, LoginDTO>().ReverseMap();
			CreateMap<Employee, LoginCreateDTO>().ReverseMap();

			//Attendance Mapping
			CreateMap<AttendanceDetails, AttendanceDTO>().ReverseMap();
			CreateMap<AttendanceDetails, AttendanceCreateDTO>().ReverseMap();
			CreateMap<AttendanceDetails, AttendanceUpdateDTO>().ReverseMap();
			CreateMap<Attendance, AttendanceDTO>().ReverseMap();
			CreateMap<Attendance, AttendanceCreateDTO>().ReverseMap();

			//Payroll Mapping
			CreateMap<PayrollDetailsCreate, PayrollDetailsCreateDTO>().ReverseMap();



		}

	}
}
