using FirstCoreProject.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FirstCoreProject.Repository
{
    public class MockBookRepository : IBookRepository
    {
        public Books Create(Books book)
        {
            throw new NotImplementedException();
        }

        public Books DeleteBooks(int id)
        {
            throw new NotImplementedException();
        }

        public Books DeleteBooks(int? id)
        {
            throw new NotImplementedException();
        }

        public Books GetBookById(int id)
        {
            var books = GetBooks();
            return books.FirstOrDefault(b => b.Id == id);
            
        }

        public IEnumerable<Books> GetBooks()
        {
            return new List<Books>
            {
              new Books {Id=1,BookName="Making of New India",Author="Dr. Bibek Debroy",PublishedDate=Convert.ToDateTime("09/08/2009") },
              new Books {Id=2,BookName="Whispers of Time",Author="Dr. Krishna Saksena",PublishedDate=Convert.ToDateTime("23/05/2006") }

            };
        }

        public void GetGenre()
        {
            throw new NotImplementedException();
        }

        public void UpdateBooks(Books book, int? id)
        {
            throw new NotImplementedException();
        }

        void IBookRepository.Create(Books book)
        {
            throw new NotImplementedException();
        }

        void IBookRepository.DeleteBooks(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
