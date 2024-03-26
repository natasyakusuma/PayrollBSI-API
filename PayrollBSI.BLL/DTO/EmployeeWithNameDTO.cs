using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
    public class EmployeeWithNameDTO
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string EmployeeName
        {
            get { return $"{FirstName} {LastName}"; }
            set { }
        }
        public string? RoleName { get; set; }
        public string? PositionName { get; set; }
        public string? Username { get; set; }
    }
}
