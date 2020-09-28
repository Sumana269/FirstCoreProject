using FirstCoreProject.Data;
using FirstCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext _dbContext = null;
        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Books GetBookById(int id)
        {
            return _dbContext.Books.ToList().SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Books> GetBooks()
        {
            return _dbContext.Books.ToList();
        }
       

        public void Create(Books book)
        {
            //Genre = GetGenre();
            //var books = _dbContext.Books.ToList();
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
           
        }

        public void UpdateBooks(Books book,int? id)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            var books = _dbContext.Books.SingleOrDefault(b => b.Id == id.Value);
            books.BookName = book.BookName;
            books.Author = book.Author;
            books.PublishedDate = book.PublishedDate;
            _dbContext.SaveChanges();
            
        }

        public void DeleteBooks(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
           
        }

        //public void GetGenre()
        //{
        //    //var genres = _dbContext.Books.AsEnumerable().Select(b=> new SelectListItem
        //    //{
        //    //    Text = b.Genre,


        //    //});
        //    new SelectListItem { Text = "Mythology", Value = "Mythology" };
        //    new SelectListItem { Text = "Historical", Value = "Historical" } ;
        //    new SelectListItem { Text = "Biography", Value = "Biography" };
        //    new SelectListItem { Text = "Autobiography", Value = "Autobiography" };


        //}
    }
}
