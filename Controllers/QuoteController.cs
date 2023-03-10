using Microsoft.AspNetCore.Mvc;
using QuoteComment.Models;
using QuoteComment; 

namespace QuoteComment.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository repo;
        public QuoteController(IQuoteRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            Quote quoteObj = repo.quoteString();
            repo.InsertQuote(quoteObj);
            return View(quoteObj);
        }
        public IActionResult GetAllQuotes()
        {
            var quote = repo.GetAllQuote();

            return View(quote);
        }
        public IActionResult EditComment()
        {
            Quote quoteObj = repo.quoteString();
            return View(quoteObj); 
        }

        [HttpPost]
        public IActionResult EditComment(Quote quoteToUpdate)
        {
            repo.EditComment(quoteToUpdate);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult InsertQuoteToDatabase(Quote quoteToInsert)
        {
            repo.EditComment(quoteToInsert);

            return RedirectToAction("Index");
        }
    }
}
