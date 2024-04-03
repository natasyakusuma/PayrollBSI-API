using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PayrollBSI.API.Helpers;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;


namespace PayrollBSI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeBLL _employeeBLL;
		private readonly AppSettings _appSettings;

		public EmployeeController(IEmployeeBLL employeeBLL, IOptions<AppSettings> appSettings)
		{
			_employeeBLL = employeeBLL;
			_appSettings = appSettings.Value;
		}

		[HttpGet("All")]
		public async Task<IEnumerable<EmployeeDTO>> GetAllActive()
		{
			var results = await _employeeBLL.GetAllActive();
			return results;
		}


		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<EmployeeDTO>>> SearchEmployees(string employeeName = null, string positionName = null, string roleName = null)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(employeeName) && string.IsNullOrWhiteSpace(positionName) && string.IsNullOrWhiteSpace(roleName))
				{
					return BadRequest("At least one of the parameters (employeeName, positionName, roleName) must be provided for search.");
				}

				var employees = await _employeeBLL.Search(employeeName, positionName, roleName);
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred while searching for employees: {ex.Message}");
			}
		}




		[HttpGet("{id}")]
		public async Task<ActionResult<EmployeeDTO>> GetById(int id)
		{
			var result = await _employeeBLL.GetById(id);
			return result;
		}


		[HttpPut("ChangePassword")]
		public async Task<IActionResult> ChangePassword(string username, string password)
		{
			try
			{
				var user = await _employeeBLL.GetByUsername(username);
				if (user == null)
				{
					throw new Exception("User isn't found");
				}
				await _employeeBLL.ChangePassword(username, password);
				return Ok("Password changed successfully.");
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpPost("Login")]
		public async Task<ActionResult<LoginDTO>> Login(LoginCreateDTO loginCreateDTO)
		{
			try
			{
				var employee = await _employeeBLL.Login(loginCreateDTO.Username, loginCreateDTO.Password);
				if (employee == null)
				{
					return BadRequest("Invalid username or password");
				}

				// Create claims for the authenticated user
				var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, loginCreateDTO.Username)
		};

				// Configure JWT token
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(claims),
					Expires = DateTime.UtcNow.AddHours(1), // Use UTC time for token expiration
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
						SecurityAlgorithms.HmacSha256Signature)
				};

				// Generate JWT token
				var token = tokenHandler.CreateToken(tokenDescriptor);
				var userWithToken = new LoginDTO
				{
					Username = loginCreateDTO.Username,
					Token = tokenHandler.WriteToken(token)
				};

				return Ok(userWithToken);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

	}
}










