using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;

namespace PayrollBSI.BLL.Interface.BLL
{
    public interface IPositionBLL
    {
        Task<bool> Delete(int id);
        Task<PositionDTO> Insert(PositionCreateDTO obj);
        Task<PositionDTO> Update(int id,PositionUpdateDTO obj);
        Task<IEnumerable<PositionDTO>> GetAll();
        Task<PositionDTO> GetById(int id);
        Task<IEnumerable<PositionDTO>> GetAllActivePositions();
    }
}
