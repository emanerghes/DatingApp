using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Models;
using DattingApp_FinalApp.Models.DBObjects;
using System.Collections.Generic;

namespace DattingApp_FinalApp.Repository
{
    public class MatchRepository
    {
        public ApplicationDbContext dbContext;
        private Repository.ProfileRepository _profileRepository;
        private Repository.PostRepository _postRepository;
        private Repository.LikeRepository _likeRepository;
        public MatchRepository(ApplicationDbContext context)
        {
            dbContext = context;
            _profileRepository = new Repository.ProfileRepository(context);
            _likeRepository = new Repository.LikeRepository(context);
            _postRepository = new Repository.PostRepository(context);

        }


        public List<ProfileModel> GetOnlyTheLikedProfileRecivedFor(string email)
        {
            List<LikeModel> likesList = _likeRepository.GetAllTheLikeRecivedFor(email);
            List<ProfileModel> profileList = new List<ProfileModel>();
            foreach (LikeModel dbLike in likesList)
            {
                if (ItsAMatch(dbLike.Person, email) || ItsAMatch(email,dbLike.Person)) ;
                    profileList.Add(_profileRepository.GetProfileByName(dbLike.Person));
            }

            return profileList;
        }

        public List<ProfileModel> GetAllTheLikedProfileRecivedFor(string email)
        {
            List<LikeModel> likesList = _likeRepository.GetAllTheLikeRecivedFor(email);
            List<ProfileModel> profileList = new List<ProfileModel>();
            foreach (LikeModel dbLike in likesList)
            {
                profileList.Add(_profileRepository.GetProfileByName(dbLike.Person));
            }

            return profileList;
        }

        public List<ProfileModel> GetAllTheLikeProfileGivenFor(string email)
        {
            List<LikeModel> likesList = _likeRepository.GetAllTheLikedGivenFor(email);
            List<ProfileModel> profileList = new List<ProfileModel>();
            foreach (LikeModel dbLike in likesList)
            {
            
                profileList.Add(_profileRepository.GetProfileByName(dbLike.Likes));
            }

            return profileList;
        }

        public List<ProfileModel> GetOnlyTheLikeProfileGivenFor(string email)
        {
            List<LikeModel> likesList = _likeRepository.GetAllTheLikedGivenFor(email);
            List<ProfileModel> profileList = new List<ProfileModel>();
            foreach (LikeModel dbLike in likesList)
            {
                if (ItsAMatch(dbLike.Likes, email) || ItsAMatch(email, dbLike.Likes)) ;
                profileList.Add(_profileRepository.GetProfileByName(dbLike.Likes));
            }

            return profileList;
        }

        public List<PostModel> GetFriendsPostFor(string email)
        {
            List<LikeModel> likesList = _likeRepository.GetAllTheLikedGivenFor(email);
            List<PostModel> postList = new List<PostModel>();
            List<String> persons = new List<String>();
            foreach (LikeModel dbLike in likesList)
            {
                persons.Add(dbLike.Likes);
            }
            foreach (Post dbPost in dbContext.Posts)
            {
                if (persons.Contains(dbPost.UserEmail))
                postList.Add(GetPostByEnail(dbPost.UserEmail));
            }

            return postList;
        }

        public LikeModel GetLikeById(Guid id)
        {

            return _likeRepository.MapModelToObject(dbContext.Likes.FirstOrDefault(x => x.Id == id));
        }

        public ProfileModel GetProfileById(Guid id)
        {

            return _profileRepository.MapModelToObject(dbContext.Profiles.FirstOrDefault(x => x.Id == id));
        }

        public void LikeByMail(String person, String Like)
        {
            _likeRepository.LikeByMail(person, Like);   
            
        }

        public bool ItsAMatch(String person, String Like)
        {
            foreach (Like dbLike in dbContext.Likes)
            {
                if(dbLike.Person.Equals(Like) && dbLike.Likes.Equals(person))
                     return true;   
            }
             return false; 
        }
        public List<ProfileModel>GetAlltheMatchesFor(string email)
        {
            List <ProfileModel>  profileList = new List<ProfileModel>();
            List<ProfileModel> personsList = GetAllTheLikeProfileGivenFor(email);
            List<String> persons = new List<String>();
            foreach (ProfileModel dbLike in personsList)
            {
                persons.Add(dbLike.Email);
            }
            List<ProfileModel> likesList = GetAllTheLikedProfileRecivedFor(email);
            List<String> likes = new List<String>();
            foreach (ProfileModel dbLike in likesList)
            {
                likes.Add(dbLike.Email);
            }


           foreach (Profile model in dbContext.Profiles)
            {
                if (persons.Contains(model.Email) && likes.Contains(model.Email))
                    profileList.Add(_profileRepository.GetProfileByName(model.Email));


            }
           return profileList;
        }


        public PostModel GetPostByEnail(string email)
        {

            return _postRepository.MapModelToObject(dbContext.Posts.FirstOrDefault(x => x.UserEmail == email));
        }
    }
}
