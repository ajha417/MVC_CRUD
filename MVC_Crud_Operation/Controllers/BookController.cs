using Microsoft.AspNetCore.Mvc;
using MVC_Crud_Operation.Models;

namespace MVC_Crud_Operation.Controllers
{
    public class BookController : Controller
    {
        BooksModel booksmodel = new BooksModel();

        public IActionResult Index()
        {
            List<BooksModel> books = booksmodel.getData();
            return View(books);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BooksModel book)
        {
            BooksModel bmodel = new BooksModel();
            bool res = bmodel.insert(book);
            if (res)
            {
                TempData["msg"] = "Data Inserted successfully!!!";
            }
            else
            {
                TempData["msg"] = "Something Went wrong!!!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditBook(string id) 
        {
            BooksModel bmodel = booksmodel.getData(id);
            return View(bmodel);

        }


        [HttpPost]
        public IActionResult EditBook(BooksModel book)
        {
            BooksModel bmodel = new BooksModel();
            bool res = bmodel.update(book);
            if (res)
            {
                TempData["msg"] = "Data updated successfully!!!";
            }
            else
            {
                TempData["msg"] = "Couldn't update data!!!";
            }
            return View();
        }
    }
}
