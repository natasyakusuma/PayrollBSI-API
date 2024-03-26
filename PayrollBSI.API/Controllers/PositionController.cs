using Microsoft.AspNetCore.Mvc;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;

namespace PayrollBSI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionBLL _positionBLL;

        public PositionController(IPositionBLL positionBLL)
        {
            _positionBLL = positionBLL;
        }

        [HttpGet]
        public async Task<IEnumerable<PositionDTO>> Get()
        {
            var results = await _positionBLL.GetAll();
            return results;
        }

        [HttpGet("/api/Position/Active")]
        public async Task<IEnumerable<PositionDTO>> GetAll()
        {
            var results = await _positionBLL.GetAllActivePositions();
            return results;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _positionBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, PositionCreateDTO positionCreateDTO)
        {
            try
            {
                var newPosition = await _positionBLL.Insert(positionCreateDTO);
                return CreatedAtAction("Get", new { id = id }, newPosition);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _positionBLL.Delete(id);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut("Edit{id}")]
        public async Task<IActionResult> Update(int id, PositionUpdateDTO positionUpdateDTO)
        {
            await _positionBLL.Update(id, positionUpdateDTO);
            return Ok("Update data sucess");
        }


    }
}
