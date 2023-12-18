using BookCRUDAPIForAngular.Model;

namespace BookCRUDAPIForAngular.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<int> AddStudent(Student stud);
        Task<int> UpdateStudent(Student stud);
        Task<int> DeleteStudent(int id);
    }
}
