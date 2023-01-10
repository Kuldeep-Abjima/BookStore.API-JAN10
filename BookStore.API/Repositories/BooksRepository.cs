using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksStoreContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(BooksStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var records = await _context.Books.Select(
            //    x => new BookModel()
            //    {
            //        ID = x.ID,
            //        Title = x.Title,
            //        Description = x.Description
            //    }).ToListAsync();
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var records = await _context.Books.Where(x => x.ID == bookId).Select(
            //    x => new BookModel()
            //    {
            //        ID = x.ID,
            //        Title = x.Title,
            //        Description = x.Description
            //    }).FirstOrDefaultAsync();

            //return records;

            var book = _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }
        public async Task<int> AddBookAsync(BookModel bookmodel)
        {
            var book = new Books()
            {
                Title = bookmodel.Title,
                Description = bookmodel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.ID;
        }
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //HITTING DATABASE TWO TIMES
            //var book = await _context.Books.FindAsync(bookId);
            //if(book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //   await _context.SaveChangesAsync();
            //}

            //HITTING DB SINGLE TIME
            var book = new Books()
            {
                ID = bookId,
                Description = bookModel.Description,
                Title = bookModel.Title
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateBookByNameAsync(string title, BookModel bookModel)
        {
            var book = await _context.Books.Where(x => x.Title == title).FirstOrDefaultAsync();
            if (book != null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;

                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }

        }
        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { ID = bookId };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }
    }
}
