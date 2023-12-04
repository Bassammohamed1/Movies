using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.Data.Consts;
using Movies.Models;
using Movies.Repository.Interfaces;

namespace Movies.Controllers
{
    [Authorize(Roles = "User")]
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateProducersSelectList()
        {
            var producers = _unitOfWork.Producers.GetAll();
            SelectList List = new SelectList(producers, "Id", "Name");
            ViewBag.MyBag1 = List;
        }
        public void CreateActorsSelectList()
        {
            var actors = _unitOfWork.Actors.GetAll();
            SelectList List = new SelectList(actors, "Id", "Name");
            ViewBag.MyBag2 = List;
        }
        public IActionResult Index()
        {
            IEnumerable<Movie> result = _unitOfWork.Movies.GetAll();
            return View(result);
        }
        public IActionResult Add()
        {
            CreateProducersSelectList();
            CreateActorsSelectList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.clientFile != null)
                {
                    var stream = new MemoryStream();
                    movie.clientFile.CopyTo(stream);
                    movie.dbImage = stream.ToArray();
                }
                _unitOfWork.Movies.AddMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(movie);
            }
        }
        public IActionResult Update(int Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var movie = _unitOfWork.Movies.GetMovieById(Id);
            if (movie == null)
                return NotFound();
            var result = new MovieViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Bio = movie.Bio,
                dbImage = movie.dbImage,
                price = movie.price,
                MoiveCategory = movie.MoiveCategory,
                ProducerId = movie.ProducerId,
                ActorsId = movie.ActorMovies.Select(a => a.ActorId).ToList()
            };
            CreateProducersSelectList();
            CreateActorsSelectList();
            return View(result);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var data = _unitOfWork.Movies.GetById(movie.Id);
                if (data.clientFile != movie.clientFile)
                {
                    var stream = new MemoryStream();
                    movie.clientFile.CopyTo(stream);
                    movie.dbImage = stream.ToArray();
                }
                _unitOfWork.Movies.UpdateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(movie);
            }
        }
        public IActionResult Delete(int Id)
        {

            if (Id == null || Id == 0)
                return NotFound();
            var movie = _unitOfWork.Movies.GetById(Id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Movie movie)
        {
            _unitOfWork.Movies.Delete(movie);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            if (id == null || id == 0)
                return NotFound();
            var movie = _unitOfWork.Movies.GetMovieById(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }
        [AllowAnonymous]
        public IActionResult Filter(string searchString)
        {
            var allMovies = _unitOfWork.Movies.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Bio, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }
            return View("Index", allMovies);
        }
    }
}