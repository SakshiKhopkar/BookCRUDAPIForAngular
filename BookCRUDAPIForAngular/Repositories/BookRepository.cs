using BookCRUDAPIForAngular.Data;
using BookCRUDAPIForAngular.Model;
using Microsoft.EntityFrameworkCore;

namespace BookCRUDAPIForAngular.Repositories
{
    public class BookRepository:IBookRepository
    {
        ApplicationDbContext db;
        public BookRepository(ApplicationDbContext db)//DI Pattern 
        {
            this.db = db;
        }
        public async Task<int> AddBook(Book book)
        {
             await db.Books.AddAsync(book);
            // SaveChages() reflect the changes from Dbset to DB
            var result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteBook(int id)
        {
            int res = 0;
            var result = await db.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                 db.Books.Remove(result); // remove from DbSet
                res = await db.SaveChangesAsync();
            }

            return res;
        }

        public async Task<Book> GetBookById(int id)
        {
            var result = await db.Books.Where(x => x.Id == id).SingleOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await db.Books.ToListAsync();
        }

        public async Task<int> UpdateBook(Book book)
        {
            int res = 0;
            // find the record from Dbset that we need to modify
            //var result = (from b in db.Books
            //             where b.Id == book.Id
            //             select b).FirstOrDefault();

            var result = await db.Books.Where(x => x.Id == book.Id).FirstOrDefaultAsync();

            if (result != null)
            {
                result.Name = book.Name; // book contains new data, result contains old data
                result.Author = book.Author;
                result.Price = book.Price;

                res = await db.SaveChangesAsync();// update those changes in DB
            }

            return res;
        }
    }
}

