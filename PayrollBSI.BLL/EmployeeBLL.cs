using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;
using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Domain;

namespace PayrollBSI.BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IEmployee _employeeData;
        private readonly IMapper _mapper;
        public EmployeeBLL(IEmployee employeeData, IMapper mapper)
        {
            _employeeData = employeeData;
            _mapper = mapper;
        }

        public async Task<Task> ChangePassword(string username, string newPassword)
        {
            try
            {
                var changePassword = await _employeeData.ChangePassword(username, newPassword);
                return changePassword;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var employees = await _employeeData.GetAll();
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllActiveEmployee()
        {
            var employees = await _employeeData.GetAllActiveEmployee();
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return employeeDto;

        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            try
            {
                var employee = await _employeeData.GetById(id);
                var employeeDto = _mapper.Map<EmployeeDTO>(employee);
                return employeeDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public Task<IEnumerable<EmployeeWithNameDTO>> GetByRoleNameAndPositionName(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDTO> GetByUsername(string username)
        {
            var employee = await _employeeData.GetByUsername(username);
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);
            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeWithNameDTO>> GetWithRoleNameAndPositionName()
        {
            var employess = await _employeeData.GetWithRoleNameAndPositionName();
            var employeeNameDto = _mapper.Map<IEnumerable<EmployeeWithNameDTO>>(employess);
            return employeeNameDto;
        }

        public Task<EmployeeDTO> Insert(EmployeeDTO obj)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginCreateDTO> Login(string username, string password)
        {
            try
            {
                var login = await _employeeData.Login(username, password);
                var loginDto = _mapper.Map<LoginCreateDTO>(login);
                return loginDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<EmployeeDTO> Update(int id, EmployeeDTO obj)
        {
            throw new NotImplementedException();
        }


    }
}
