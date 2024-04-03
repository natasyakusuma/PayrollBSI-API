using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PayrollBSI.BLL.DTO.Validator
{
    public class PositionCreateDTOValidator : AbstractValidator<PositionCreateDTO>
    {
        public PositionCreateDTOValidator()
        {
            RuleFor(x => x.PositionName).NotEmpty().WithMessage("Position Name is Required");
            RuleFor(x => x.AllowanceMeal).NotEmpty().WithMessage("Allowance Meal is Required");
            RuleFor(x => x.AllowanceTransport).NotEmpty().WithMessage("Allowance Transport is Required");
            RuleFor(x => x.DeductionPension).NotEmpty().WithMessage("Deduction Pension is Required");
            RuleFor(x => x.DeductionInsurance).NotEmpty().WithMessage("Deduction Insurance is Required");
            RuleFor(x => x.PayrateOvertime).NotEmpty().WithMessage("Payrate Overtime is Required");
            RuleFor(x => x.PayrateRegular).NotEmpty().WithMessage("Payrate Regular is Required");

        }
    }
}
