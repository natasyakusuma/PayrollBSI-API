using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
    public class PositionCreateDTO
    {
        public string PositionName { get; set; }
        public decimal AllowanceMeal { get; set; }
        public decimal AllowanceTransport { get; set; }
        public decimal DeductionPension { get; set; }
        public decimal DeductionInsurance { get; set; }
        public decimal PayrateOvertime { get; set; }
        public decimal PayrateRegular { get; set; }
    }
}
