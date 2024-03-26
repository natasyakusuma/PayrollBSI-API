using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.Domain;

namespace PayrollBSI.Data.Interfaces.Data
{
    public interface IPosition : ICrud<Position>
    {
        Task<IEnumerable<Position>> GetAllActivePositions();
    }
}
