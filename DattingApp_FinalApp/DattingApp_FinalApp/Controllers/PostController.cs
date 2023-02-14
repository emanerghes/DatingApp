using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DattingApp_FinalApp.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController
        private Repository.PostRepository _repository;

        public PostController(ApplicationDbContext DbContext)
        {
            _repository = new Repository.PostRepository(DbContext);
        }
        public ActionResult Index()
        {

            var posts = _repository.GetAllPost();
            return View("Index", posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(Guid id)
        {

            var model = _repository.GetPostById(id);
            return View("Details", model);
        }
        public ActionResult UserPost(Guid id)
        {

            var Email = User.Identity.Name;
            var model = _repository.GetAllPostFor(Email);
            return View("UserPost", model);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.PostModel model = new Models.PostModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                //if task.Result)

                Console.WriteLine("Inainte de salvare");
                _repository.InsertPost(model);

                return View("Create");
            }
            catch
            {
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetPostById(id);
            return View("Edit", model);
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(Guid id)
        {

            var model = _repository.GetPostById(id);
            return View("Delete", model);
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
