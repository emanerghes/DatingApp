using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace DattingApp_FinalApp.Controllers
{
    public class MatchController : Controller
    {
        private Repository.MatchRepository _repository;
    
        public MatchController(ApplicationDbContext DbContext)
        {
            _repository = new Repository.MatchRepository(DbContext);
        }
     
        public ActionResult GetAllTheLikedProfileRecivedFor()
        {

            var likes = _repository.GetOnlyTheLikedProfileRecivedFor(User.Identity.Name);
            return View("Index", likes);

        }
        public ActionResult GetTheMatchesFor()
        {

            var likes = _repository.GetAlltheMatchesFor(User.Identity.Name);
            return View("Index", likes);

        }

        public ActionResult GetAllTheLikeProfileGivenFor()
        {
            var likes = _repository.GetOnlyTheLikeProfileGivenFor(User.Identity.Name);
            return View("Index", likes);

        }

        public ActionResult GetFriendsPostFor()
        {
            var posts = _repository.GetFriendsPostFor(User.Identity.Name);
            return View( "GetFriendsPostFor", posts);

        }

        public ActionResult NewLike(Guid id)
        {

            var profile = _repository.GetProfileById(id);
            _repository.LikeByMail(User.Identity.Name, profile.Email);
            var likes = _repository.GetAllTheLikedProfileRecivedFor(User.Identity.Name);
            if (_repository.ItsAMatch(User.Identity.Name, profile.Email)) 
                 return View("ItsAMatch", likes);   
            else
            return View("Index", likes);
        }
        // GET: MatchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MatchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MatchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MatchController/Edit/5
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

        // GET: MatchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MatchController/Delete/5
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
