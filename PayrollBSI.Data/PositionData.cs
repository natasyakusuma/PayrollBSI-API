using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Domain;

namespace PayrollBSI.Data
{
    public class PositionData : IPosition
    {
        private readonly AppDbContext _context;
        public PositionData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                //Execute store procedure
                var result = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeletePosition @PositionID = {id}"); // untuk execute berdasarkan parameternya
				
                //Sql raw untuk get Row data dari table

				//check the result
				if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error DeletePosition Data : " + ex.Message);
            }

        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            var positions = await _context.Positions.OrderBy(p => p.PositionName).ToListAsync(); // this is EF using Lambda
            return positions;
        }

        public async Task<IEnumerable<Position>> GetAllActivePositions()
        {
            var positions = await _context.Positions
                .Where(p => p.IsActive == true && p.IsDeleted == false) //this is Linq
                .ToListAsync(); // to get all data and make it to List/Array
            return positions;
        }

        public async Task<Position> GetById(int id)
        {
            var position = await _context.Positions.FindAsync(id); // to find the specific data
            if (position == null)
            {
                throw new Exception($"Position with ID {id} not found");
            }
            return position;
        }

        public async Task<Position> Insert(Position obj)
        {
            try
            {
                _context.Positions.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Position> Update(int id, Position obj)
        {
            var position = await _context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync(); //to get one specific data 
            if (position != null)
            {
                position.PositionName = obj.PositionName;
                position.AllowanceMeal =obj.AllowanceMeal;
                position.AllowanceTransport = obj.AllowanceTransport;
                position.DeductionInsurance = obj.DeductionInsurance;
                position.DeductionPension = obj.DeductionPension;
                position.PayrateOvertime = obj.PayrateOvertime;
                position.PayrateOvertime = obj.PayrateOvertime;

                await _context.SaveChangesAsync();
            }
            return position;
        }
    }
}
