using BookCRUDAPIForAngular.Data;
using BookCRUDAPIForAngular.Model;
using Microsoft.EntityFrameworkCore;

namespace BookCRUDAPIForAngular.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> AddEmployee(Employee emp)
        {
            await db.Employees.AddAsync(emp);
            // SaveChages() reflect the changes from Dbset to DB
            var result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            int res = 0;
            var result = await db.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                db.Employees.Remove(result); // remove from DbSet
                res = await db.SaveChangesAsync();
            }

            return res;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var result = await db.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await db.Employees.ToListAsync();
            return result;
        }

        public async Task<int> UpdateEmployee(Employee emp)
        {
            int res = 0;
            // find the record from Dbset that we need to modify
            //var result = (from b in db.Books
            //             where b.Id == book.Id
            //             select b).FirstOrDefault();

            var result = await db.Employees.Where(x => x.Id == emp.Id).FirstOrDefaultAsync();

            if (result != null)
            {
                result.Name = emp.Name; // book contains new data, result contains old data
                result.Email = emp.Email;
                result.Age = emp.Age;
                result.Salary = emp.Salary;

                res = await db.SaveChangesAsync();// update those changes in DB
            }

            return res;
        }
    }
}

