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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editFilm = _manager.GetFilm(id);
            return View(editFilm);
        }

        [HttpPost]
        public IActionResult Edit(Film film)
        {
            try
            {
                _manager.UpdateFilm(film);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(film);
            }
        }

        [HttpGet]
        public IActionResult RemoveFilm(int id) 
        {
            var deleteFilm = _manager.GetFilm(id);
            return View(deleteFilm);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var deleteItem = _manager.GetFilm(id);
            _manager.RemoveFilm(id);
            return RedirectToAction("Index");
        }
    }
}
