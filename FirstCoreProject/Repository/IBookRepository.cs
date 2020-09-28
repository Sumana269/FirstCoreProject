using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreProject.Models;

namespace FirstCoreProject.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Books> GetBooks();
        Books GetBookById(int id);
        void Create(Books book);
        void UpdateBooks(Books book,int? id);
        void DeleteBooks(int? id);
        //void GetGenre();
    }
}
