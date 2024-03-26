using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RoleID { get; set; }
        public int PositionID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int IsDeleted { get; set; }
    }
}
