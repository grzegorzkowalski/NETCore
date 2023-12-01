using FilmDB.Models;
using NetWorkshop.Data;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Repositories
{
    public class FilmManager
    {
        private ApplicationDbContext _context;

        public FilmManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public FilmManager AddFilm(Film film)
        {
           
            _context.Films.Add(film);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException exp)
            {
                Console.WriteLine(exp.Message);
                film.ID = 0;
                _context.SaveChanges();
            }

            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            var filmToDelete = GetFilm(id);
            _context.Films.Remove(filmToDelete);
            _context.SaveChanges();
            return this;
        }

        public FilmManager UpdateFilm(Film film)
        {
            _context.Update(film);
            _context.SaveChanges();
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            var updateFilm = GetFilm(id);
            if (String.IsNullOrEmpty(newTitle)) 
            {
                newTitle = "Brak tytułu";
            }

            updateFilm.Title = newTitle;
            _context.SaveChanges();
            return this;
        }

        public Film GetFilm(int id)
        {
            return _context.Films.Single(x => x.ID == id);
        }

        public List<Film> GetFilms()
        {
            return _context.Films.ToList();
        }
    }
}
