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

namespace PayrollBSI.BLL
{
	public class PayrollDetailsBLL : IPayrollDetailsBLL
	{
		private readonly IPayrollDetails _payrollDetailsData;
		private readonly IMapper _mapper;

		public PayrollDetailsBLL(IPayrollDetails payrollDetails, IMapper mapper)
		{
			_payrollDetailsData = payrollDetails;
			_mapper = mapper;
		}

		public async Task<PayrollDetailsCreateDTO> Insert(PayrollDetailsCreateDTO obj)
		{
			try
			{
				var payrollDetails = _mapper.Map<PayrollDetailsCreate>(obj);
				var createdpayrollDetails = await _payrollDetailsData.Insert(payrollDetails);
				return _mapper.Map<PayrollDetailsCreateDTO>(createdpayrollDetails);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(ex.Message);
			}
		}

		public async Task<IEnumerable<PayrollDetailsDTO>> GetAll()
		{
			try
			{
				var payrollDetails = await _payrollDetailsData.GetAll();
				var payrollDetailsDto = _mapper.Map<IEnumerable<PayrollDetailsDTO>>(payrollDetails);
				return payrollDetailsDto;
			}
			catch (Exception ex)
			{
				throw new Exception("Error occurred while fetching PayrollDetails in BLL: " + ex.Message);
			}
		}

		public async Task<IEnumerable<GetPayrollDetailsDTO>> GetPayrollDetails(int id)
		{
			try
			{
				var payrollDetails = await _payrollDetailsData.GetPayrollDetails(id);
				var payrollDetailsDto = _mapper.Map<IEnumerable<GetPayrollDetailsDTO>>(payrollDetails);
				return payrollDetailsDto;
			}
			catch (Exception ex)
			{
				throw new Exception("Error occurred while fetching PayrollDetails in BLL: " + ex.Message);
			}
		}



	}
}
