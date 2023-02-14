using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DattingApp_FinalApp.Controllers
{
    public class LikeController : Controller
    {
        private Repository.LikeRepository _repository;
        private Repository.ProfileRepository _profileRepository;

        public LikeController(ApplicationDbContext DbContext)
        {
            _repository = new Repository.LikeRepository(DbContext);
        }
        public ActionResult Index()
        {
            var likes = _repository.GetAllLikes();
            return View("Index",likes);
        }

        // GET: LikeController/Details/5
        public ActionResult Details(Guid id)
        {

            ProfileModel profile = _profileRepository.GetProfileById(id);
            _repository.LikeByMail(User.Identity.Name, profile.Email);

            return View("Details", profile);
         
        }
        public ActionResult UserLikedPerson(int id)
        {

            var likes = _repository.GetAllTheLikedGivenFor(User.Identity.Name);
            return View("UserLikedPerson", likes);
        }


        // GET: LikeController/Create
        public ActionResult Create()
        {
            return View();
        }

      

        // POST: LikeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.LikeModel model = new Models.LikeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                //if task.Result)

                Console.WriteLine("Inainte de salvare");
                _repository.InsertLike(model);

                return View("Create");
            }
            catch
            {
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        // GET: LikeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LikeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LikeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LikeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
