using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace PayrollBSI.Domain;

[Table("Attendance")]
public partial class Attendance
{
	[Key]
	[Column("AttendanceID")]
	public int AttendanceId { get; set; }

	[Column("EmployeeID")]
	public int EmployeeId { get; set; }

	public int OvertimeHours { get; set; }

	public int RegularHours { get; set; }

	public int AttendanceTotal { get; set; }

	[ForeignKey("EmployeeID")]
	[InverseProperty("Attendances")]
	public virtual Employee Employee { get; set; } = null!;
}
