using BookCRUDAPIForAngular.Data;
using BookCRUDAPIForAngular.Model;
using Microsoft.EntityFrameworkCore;

namespace BookCRUDAPIForAngular.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public async Task<int> AddStudent(Student stud)
        {
            await db.Students.AddAsync(stud);
            // SaveChages() reflect the changes from Dbset to DB
            var result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int res = 0;
            var result = await db.Students.Where(x => x.RollNo == id).FirstOrDefaultAsync();
            if (result != null)
            {
                db.Students.Remove(result); // remove from DbSet
                res = await db.SaveChangesAsync();
            }

            return res;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var result = await db.Students.Where(x => x.RollNo == id).SingleOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var result = await db.Students.ToListAsync();
            return result;
        }

        public async Task<int> UpdateStudent(Student stud)
        {
            int res = 0;
            // find the record from Dbset that we need to modify
            //var result = (from b in db.Books
            //             where b.Id == book.Id
            //             select b).FirstOrDefault();

            var result = await db.Students.Where(x => x.RollNo == stud.RollNo).FirstOrDefaultAsync();

            if (result != null)
            {
                result.Name = stud.Name; // book contains new data, result contains old data
                result.Percentage = stud.Percentage;
                result.City = stud.City;

                res = await db.SaveChangesAsync();// update those changes in DB
            }

            return res;
        }
    }
}
