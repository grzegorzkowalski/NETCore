using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private FilmManager _manager;
        public FilmController(FilmManager manager) 
        { 
            _manager = manager;
        }
        public IActionResult Index()
        {
            var films = _manager.GetFilms();
            return View(films);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Film film)
        {
            try
            {
                _manager.AddFilm(film);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(film);
            }

        }
    }
}
