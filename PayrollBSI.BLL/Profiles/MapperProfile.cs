using AutoMapper;
using PayrollBSI.BLL.DTO;
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
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeWithRoleAndPositionName, EmployeeWithNameDTO>().ReverseMap();
            CreateMap<Employee, LoginDTO>().ReverseMap();
            CreateMap<Employee, LoginCreateDTO>().ReverseMap();

        }

    }
}
