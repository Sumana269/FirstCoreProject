using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreProject.Models;
using FirstCoreProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace FirstCoreProject.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository _repository = null;
        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var books = _repository.GetBooks();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = _repository.GetBookById(id);
            return View(book);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Books book)
        {
              //Genre = GetGenres();
            if (!ModelState.IsValid)
            {
                return View();
            }
            _repository.Create(book);
            return RedirectToAction("Index", "Books");
        }
        [HttpGet]
        public IActionResult UpdateBooks(int id)
        {
            var books = _repository.GetBookById(id);
            
            return View();
        }
        [HttpPost]
        public IActionResult UpdateBooks(Books book,int? id)
        {
           
            if (!ModelState.IsValid)
            {
                return View();
            }
            _repository.UpdateBooks(book, id);
            return RedirectToAction("Index", "Books");
            
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _repository.DeleteBooks(id);
            if (id != null)
            {
                return View();
                
            }
            return RedirectToAction("Index", "Books");
        }
        public void GetGenres()
        {
            
        }
        public IActionResult New()
        {
            return View();
        }
    }
}
