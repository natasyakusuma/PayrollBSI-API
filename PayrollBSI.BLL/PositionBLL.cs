using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.Interface.BLL;
using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Domain;

namespace PayrollBSI.BLL
{
    public class PositionBLL : IPositionBLL
    {
        private readonly IPosition _positionData;
        private readonly IMapper _mapper;
        public PositionBLL(IPosition positionData, IMapper mapper)
        {
            _positionData = positionData;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            var position = await _positionData.GetById(id);
            if (position == null)
            {
                return false;
            }
            await _positionData.Delete(id);
            return true;

        }

        public async Task<IEnumerable<PositionDTO>> GetAll()
        {
            var positions = await _positionData.GetAll();
            var positionsDto = _mapper.Map<IEnumerable<PositionDTO>>(positions);
            return positionsDto;
        }


        public async Task<IEnumerable<PositionDTO>> GetAllActivePositions()
        {
            try
            {
                var positions = await _positionData.GetAllActivePositions();
                var positionsDto = _mapper.Map<IEnumerable<PositionDTO>>(positions);
                return positionsDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<PositionDTO> GetById(int id)
        {
            try
            {
                var position = await _positionData.GetById(id);
                var positionDto = _mapper.Map<PositionDTO>(position);
                return positionDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }


        }

        public async Task<PositionDTO> Insert(PositionCreateDTO obj)
        {
            try
            {
                var position = _mapper.Map<Position>(obj); // Map to Position entity
                position.IsActive = true; // Set IsActive to true (1)
                position.IsDeleted = false; // Set IsDeleted to false (0)

                var createdPosition = await _positionData.Insert(position); // Insert the mapped Position entity
                return _mapper.Map<PositionDTO>(createdPosition); // Map the created Position entity back to PositionDTO
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }



        public async Task<PositionDTO> Update(int id, PositionUpdateDTO obj)
        {
            try
            {
                var position = _mapper.Map<Position>(obj);
                await _positionData.Update(id, position);
                var updatedPositionDto = _mapper.Map<PositionDTO>(position);
                return updatedPositionDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            //throw new NotImplementedException();
        }
    }
}
