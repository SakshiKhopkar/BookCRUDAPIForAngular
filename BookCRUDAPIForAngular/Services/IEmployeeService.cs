using BookCRUDAPIForAngular.Model;

namespace BookCRUDAPIForAngular.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<int> AddEmployee(Employee emp);
        Task<int> UpdateEmployee(Employee emp);
        Task<int> DeleteEmployee(int id);
    }
}
