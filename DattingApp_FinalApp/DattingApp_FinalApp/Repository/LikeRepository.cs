using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Models.DBObjects;
using DattingApp_FinalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DattingApp_FinalApp.Repository
{
    public class LikeRepository
    {
        public ApplicationDbContext dbContext;
      
        public LikeRepository(ApplicationDbContext context)
        {
            dbContext = context;
      
        }

        public void InsertLike(LikeModel likeModel)
        {
            likeModel.Id = Guid.NewGuid();
            dbContext.Likes.Add(MapModelToObject(likeModel));
            dbContext.SaveChanges();

        }

        public void InsertLikeByMail(LikeModel likeModel, String email)
        {
            likeModel.Id = Guid.NewGuid();
            likeModel.Person = email;
            dbContext.Likes.Add(MapModelToObject(likeModel));
            dbContext.SaveChanges();

        }
        public void LikeByMail(  String person, String Like)
        {

            bool alreadyLike = false;
            LikeModel likeModel= new LikeModel();
            likeModel.Id = Guid.NewGuid();
            likeModel.Person = person;
            likeModel.Likes = Like;
            foreach (Like like in dbContext.Likes)
            {
                if (like.Likes.Equals(Like) && like.Person.Equals(person))
                {
                    Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                    alreadyLike = true;
                    Console.WriteLine("Already liked");

                    Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                }
                
            }
            if (alreadyLike == false)
            {
                dbContext.Likes.Add(MapModelToObject(likeModel));
                dbContext.SaveChanges();
                Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                alreadyLike = true;
                Console.WriteLine(" liked");

                Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
            }
           else
            {
                Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                alreadyLike = true;
                Console.WriteLine("Already liked");

                Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////");
            }
          

        }

        public LikeModel GetLikeById(Guid id)
        {

            return MapModelToObject(dbContext.Likes.FirstOrDefault(x => x.Id == id));
        }

        public LikeModel GetLikeByPerson(String email)
        {

            return MapModelToObject(dbContext.Likes.FirstOrDefault(x => x.Person == email));
        }

        public LikeModel GetLikeByLikes(String email)
        {

            return MapModelToObject(dbContext.Likes.FirstOrDefault(x => x.Likes == email));
        }
        public LikeModel MapModelToObject(Like dbLike)
        {
            LikeModel like = new LikeModel();

            if (dbLike != null)
            {
                like.Id = dbLike.Id;
                like.Person = dbLike.Person;
                like.Likes = dbLike.Likes;
            }

            return like;
        }

        public Like MapModelToObject(LikeModel dbLike)
        {
            Like like = new Like();

            if (dbLike != null)
            {
                like.Id = dbLike.Id;
                like.Person = dbLike.Person;
                like.Likes = dbLike.Likes;

            }
            return like;
        }

        public void UpdateLike(LikeModel likeModel)
        {
            Like existingLike = dbContext.Likes.FirstOrDefault(x => x.Id == likeModel.Id);
            if (existingLike != null)
            {

                existingLike.Person = likeModel.Person;
                existingLike.Likes = likeModel.Likes;
                dbContext.SaveChanges();

            }

        }

        public List<LikeModel> GetAllLikes()
        {
            List<LikeModel> likesList = new List<LikeModel>();
            foreach (Like dbLike in dbContext.Likes)
            {
                likesList.Add(MapModelToObject(dbLike));
            }
            return likesList;
        }

        public List<LikeModel> GetAllTheLikeRecivedFor(string email)
        {
            List<LikeModel> likeList = new List<LikeModel>();
            foreach (Like dbLike in dbContext.Likes)
            {
                if (dbLike.Likes.Equals(email))
                    likeList.Add(MapModelToObject(dbLike));
            }
            return likeList;
        }

        public List<LikeModel> GetAllTheLikedGivenFor(string email)
        {
            List<LikeModel> likeList = new List<LikeModel>();
            foreach (Like dbLike in dbContext.Likes)
            {
                if (dbLike.Person.Equals(email))
                    likeList.Add(MapModelToObject(dbLike));
            }
            return likeList;
        }

        //public List<ProfileModel> GetAllTheLikedProfileRecivedFor(string email)
        //{
        //   List <LikeModel> likesList = GetAllTheLikeRecivedFor(email);
        //    List <ProfileModel> profileList = new List<ProfileModel>(); 
        //   foreach (LikeModel dbLike in likesList)
        //    {
        //        profileList.Add(_repository.GetProfileByName(dbLike.Person));
        //    }

        //   return profileList;
        //}

        //public List<ProfileModel> GetAllTheLikeProfileFor(string email)
        //{
        //    List<LikeModel> likesList = GetAllTheLikedGivenFor(email);
        //    List<ProfileModel> profileList = new List<ProfileModel>();
        //    foreach (LikeModel dbLike in likesList)
        //    {
        //        profileList.Add(_repository.GetProfileByName(dbLike.Likes));
        //    }

        //    return profileList;
        //}
    }
}
