using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PayrollBSI.API.Helpers;
using PayrollBSI.BLL;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;


namespace PayrollBSI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttendanceController : ControllerBase
	{
		private readonly IAttendanceBLL _attendanceBLL;
		private readonly AppSettings _appSettings;

		public AttendanceController(IAttendanceBLL attendance, IOptions<AppSettings> appSettings)
		{
			_attendanceBLL = attendance;
			_appSettings = appSettings.Value;
		}

		[HttpGet("All")]
		public async Task<IEnumerable<AttendanceDTO>> GetAll()
		{
			var result = await _attendanceBLL.GetAll();
			return result;
		}


		[HttpPost("Insert")]
		public async Task<IActionResult> Post(AttendanceCreateDTO attendanceCreateDTO)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var newAttendance = await _attendanceBLL.Insert(attendanceCreateDTO);

				return CreatedAtAction("Get", new { newAttendance.AttendanceID }, newAttendance);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while processing the request.");
			}
		}




	}
}
