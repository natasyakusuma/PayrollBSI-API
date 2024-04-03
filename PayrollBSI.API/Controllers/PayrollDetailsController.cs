using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PayrollBSI.API.Helpers;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;

namespace PayrollBSI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PayrollDetailsController : ControllerBase
	{
		private readonly IPayrollDetailsBLL _payrollDetailsBLL;
		private readonly AppSettings _appSettings;

		public PayrollDetailsController(IPayrollDetailsBLL payrollDetails, IOptions<AppSettings> appSettings)
		{
			_payrollDetailsBLL = payrollDetails;
			_appSettings = appSettings.Value;
		}

		[HttpPost("Insert")]
		public async Task<IActionResult> Post(int id, PayrollDetailsCreateDTO payrollDetailsCreateDTO)
		{
			try
			{
				var newPayrollDetails = await _payrollDetailsBLL.Insert(payrollDetailsCreateDTO);
				return CreatedAtAction("Get", new { id }, newPayrollDetails);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}


		}
	}
}

