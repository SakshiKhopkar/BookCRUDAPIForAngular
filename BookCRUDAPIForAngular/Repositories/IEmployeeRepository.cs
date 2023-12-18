using BookCRUDAPIForAngular.Model;

namespace BookCRUDAPIForAngular.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<int> AddEmployee(Employee emp);
        Task<int> UpdateEmployee(Employee emp);
        Task<int> DeleteEmployee(int id);
    }
}
