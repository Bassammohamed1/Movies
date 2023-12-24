using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Repository.Interfaces;

namespace Movies.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ActorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Actor> result = _unitOfWork.Actors.GetAll();
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(Actor actor)
        {
            if (ModelState.IsValid)
            {
                if (actor.clientFile != null)
                {
                    var stream = new MemoryStream();
                    actor.clientFile.CopyTo(stream);
                    actor.dbImage = stream.ToArray();
                }
                _unitOfWork.Actors.Add(actor);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(actor);
            }
        }
        public IActionResult Update(int Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var actor = _unitOfWork.Actors.GetById(Id);
            if (actor == null)
                return NotFound();
            return View(actor);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Actor actor)
        {
            if (ModelState.IsValid)
            {
                if (actor.clientFile != null)
                {
                    var stream = new MemoryStream();
                    actor.clientFile.CopyTo(stream);
                    actor.dbImage = stream.ToArray();
                }
                _unitOfWork.Actors.Update(actor);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(actor);
            }
        }
        public IActionResult Delete(int Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var actor = _unitOfWork.Actors.GetById(Id);
            if (actor == null)
                return NotFound();
            return View(actor);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Actor actor)
        {
            _unitOfWork.Actors.Delete(actor);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}