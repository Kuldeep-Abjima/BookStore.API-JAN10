using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repositories
{
    public interface IBooksRepository
    {
            Task<List<BookModel>> GetAllBooksAsync();

            Task<BookModel> GetBookByIdAsync(int bookId);

            Task<int> AddBookAsync(BookModel bookmodel);

            Task UpdateBookAsync(int bookId, BookModel bookModel);
            Task UpdateBookByNameAsync(string title, BookModel bookModel);

            Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int bookId);

    }
}
