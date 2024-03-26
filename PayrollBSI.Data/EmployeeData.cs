using PayrollBSI.Data.Interfaces.Data;
using PayrollBSI.Domain;
using Microsoft.EntityFrameworkCore;


namespace PayrollBSI.Data
{
    public class EmployeeData : IEmployee
    {
        private readonly AppDbContext _context;

        public EmployeeData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Task> ChangePassword(string username, string newPassword)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Username == username);
                if (employee == null)
                {
                    throw new ArgumentException("User not found");
                }
                employee.Password = Helpers.Md5Hash.GetHash(newPassword);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees
                .OrderBy(e => e.FirstName) // Order by first name
                .ThenBy(e => e.LastName)   // Then by last name
                .ToListAsync();

            // Concatenate first name and last name and store it in EmployeeName
            employees.ForEach(e => e.EmployeeName = $"{e.FirstName} {e.LastName}");

            return employees;
        }



        public async Task<IEnumerable<Employee>> GetAllActiveEmployee()
        {
            var employees = await _context.Employees
                .Where(e => e.IsDeleted == 0)
                .ToListAsync();
            return employees;
        }



        public async Task<Employee> GetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found");
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetByRoleNameAndPositionName(int id)
        {
            try
            {
                var employees = await _context.Employees
                    .Include(e => e.Role) // Include the Role navigation property
                    .Include(e => e.Position) // Include the Position navigation property
                    .Where(e => e.RoleId == id && e.IsDeleted == 0) // Filter by id and active employees
                    .ToListAsync();

                return employees;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching employees by role name and position name: " + ex.Message);
            }
        }

        public async Task<Employee> GetByUsername(string username)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Username == username);
            if (employee == null)
            {
                throw new ArgumentException("User not found");
            }
            return employee;
        }

        public async Task<IEnumerable<EmployeeWithRoleAndPositionName>> GetWithRoleNameAndPositionName()
        {
            try
            {
                var employees = await _context.EmployeeWithRoleAndPositionName
                    .FromSqlRaw("EXEC GetemployeesDetail")
                    .ToListAsync();
                return employees;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching employee with role name and position name:" + ex.Message);
            }
        }


        public Task<Employee> Insert(Employee obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Login(string username, string password)
        {
            string hashedPassword = Helpers.Md5Hash.GetHash(password);
            var user = await _context.Employees
                      .FirstOrDefaultAsync(e => e.Username == username && e.Password == hashedPassword);
            return user;
        }

        public Task<Employee> Update(int id, Employee obj)
        {
            throw new NotImplementedException();
        }



    }
}
