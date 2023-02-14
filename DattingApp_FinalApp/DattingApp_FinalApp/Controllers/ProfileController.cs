using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Models;
using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DattingApp_FinalApp.Controllers
{
    public class ProfileController : Controller
    {
        private Repository.ProfileRepository _repository;
        // GET: MemberController
        public ProfileController(ApplicationDbContext DbContext)
        {
            _repository = new Repository.ProfileRepository(DbContext);
        }
        public ActionResult Index()
        {
            var profiles = _repository.GetAllProfiles();
            return View("Index", profiles);
        }
        public ActionResult Discover()
        {

            var profiles = _repository.GetAllProfiles();
            return View("Discover", profiles);

        }

        //public ActionResult Likes()
        //{
        //    var user = User.Identity.Name;

        //    var profiles = _repository.GetAllTheLikedProfileRecivedFor(user);
        //    return View("Discover", profiles);
        //}

        // GET: ProfileController/Details/5
        public ActionResult UserDetails(Guid id)
        {
            var user = User.Identity.Name;


            ProfileModel profile;
            profile = _repository.GetProfileByName(user);
            Console.WriteLine("/////////////////////////////////////////");
            Console.Write(user);
            Console.WriteLine("/////////////////////////////////////////");
            if (profile.Email != null)
                return View("UserDetails", profile);
            else
                return View("Create", user);
        }
        public ActionResult Details(Guid id)
        {
            

            ProfileModel profile;
            profile = _repository.GetProfileById(id);
          
                return View("Details", profile);
          
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.ProfileModel model = new Models.ProfileModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                //if task.Result)

                Console.WriteLine("Inainte de salvare");
                _repository.InsertProfile(model);

                return View("Create");
            }
            catch
            {
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile(IFormCollection collection, string email)
        {
            try
            {
                Models.ProfileModel model = new Models.ProfileModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                //if task.Result)

                Console.WriteLine("Inainte de salvare");
                _repository.InsertProfileByMail(model, email);

                return View("Create");
            }
            catch
            {
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(Guid id)
        {

            var model = _repository.GetProfileById(id);
            return View("Edit", model);
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new Models.ProfileModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                _repository.UpdateProfile(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        public ActionResult EditProfile(Guid id)
        {

            var model = _repository.GetProfileById(id);
            return View("Edit", model);
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new Models.ProfileModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                _repository.UpdateProfile(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }


        // GET: ProfileController/Delete/5
        public ActionResult Delete(Guid id)
        {

            var model = _repository.GetProfileById(id);
            return View("Delete", model);
            return View();
        }

        // POST: ProfileController/Delete/5
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
