using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PayrollBSI.Domain
{
    public class EmployeeWithRoleAndPositionName
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string RoleName { get; set; }
        public string PositionName { get; set; }

        public string Username { get; set; } = null!;

    }
}
