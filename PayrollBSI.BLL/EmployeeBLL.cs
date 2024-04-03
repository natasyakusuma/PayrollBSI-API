using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;
using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Data.Models;
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



		public async Task<IEnumerable<EmployeeDTO>> GetAllActive()
		{
			try
			{
				var employees = await _employeeData.GetAllActive();
				var employeeDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
				return employeeDto;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
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
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<EmployeeDTO>> Search(string employeeName, string positionName, string roleName)
		{
			try
			{
				var employee = await _employeeData.Search(employeeName, positionName, roleName);
				var employeeDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employee);
				return employeeDto;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while searching for employees.", ex);
			}
		}


		public async Task<string> GetByUsername(string username)
		{
			try
			{
				var employee = await _employeeData.GetByUsername(username);
				if (employee == null)
				{
					throw new ArgumentException("Employee not found");
				}
				// Return just the username property
				return username;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
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
	}
}
