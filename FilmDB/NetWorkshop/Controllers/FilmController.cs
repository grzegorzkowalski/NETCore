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
            var film = new Film()
            {
                ID = 2,
                Title = "Uwolnić orkę",
                Year = 1993
            };

            _manager.AddFilm(film);
            return View();
        }
    }
}
