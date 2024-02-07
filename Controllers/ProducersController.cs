using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Data.Consts;
using Movies.Models;
using Movies.Repository.Interfaces;

namespace Movies.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProducersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize("Permission.Producers.View")]
        public IActionResult Index()
        {
            IEnumerable<Producer> result = _unitOfWork.Producers.GetAll();
            return View(result);
        }
        [Authorize("Permission.Producers.Add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(Producer producer)
        {
            if (ModelState.IsValid)
            {
                if (producer.clientFile != null)
                {
                    var stream = new MemoryStream();
                    producer.clientFile.CopyTo(stream);
                    producer.dbImage = stream.ToArray();
                }
                _unitOfWork.Producers.Add(producer);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(producer);
            }
        }
        [Authorize("Permission.Producers.Update")]
        public IActionResult Update(int Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var producer = _unitOfWork.Producers.GetById(Id);
            if (producer == null)
                return NotFound();
            return View(producer);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Producer producer)
        {
            if (ModelState.IsValid)
            {
                if (producer.clientFile != null)
                {
                    var stream = new MemoryStream();
                    producer.clientFile.CopyTo(stream);
                    producer.dbImage = stream.ToArray();
                }
                _unitOfWork.Producers.Update(producer);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(producer);
            }
        }
        [Authorize("Permission.Producers.Delete")]
        public IActionResult Delete(int Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var producer = _unitOfWork.Producers.GetById(Id);
            if (producer == null)
                return NotFound();
            return View(producer);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Producer producer)
        {
            _unitOfWork.Producers.Delete(producer);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}