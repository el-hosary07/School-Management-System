using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books
                .Include(b => b.BookIssues)
                .ThenInclude(bi => bi.Student)
                .ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            book.CopiesAvailable = book.TotalCopies;
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(book);

            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult IssueBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null || book.CopiesAvailable <= 0)
                return NotFound();

            ViewBag.Book = book;
            ViewBag.Students = _context.Students.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IssueBook(int bookId, int studentId)
        {
            var book = _context.Books.Find(bookId);
            var student = _context.Students.Find(studentId);

            if (book == null || student == null || book.CopiesAvailable <= 0)
                return NotFound();

            var bookIssue = new BookIssue
            {
                IssueDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14),
                StudentId = studentId,
                BookId = bookId
            };

            _context.BookIssues.Add(bookIssue);
            book.CopiesAvailable--;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }



}
