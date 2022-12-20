using Microsoft.AspNetCore.Mvc;

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
            var quoteObj = repo.quoteString(); 
            return View(quoteObj);
        }
    }
}
