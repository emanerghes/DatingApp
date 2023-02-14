
using DattingApp_FinalApp.Models.DBObjects;
using DattingApp_FinalApp.Models;
using DattingApp_FinalApp.Data;
using NuGet.Protocol.Core.Types;

namespace DattingApp_FinalApp.Repository
{
    public class ProfileRepository
    {
        public ApplicationDbContext dbContext;
     

        public ProfileRepository(ApplicationDbContext context)
        {
            dbContext = context;
         
        }

        public ProfileRepository()
        {

        }

        public void InsertProfile(ProfileModel profileModel)
        {
            profileModel.Id = Guid.NewGuid();
            dbContext.Profiles.Add(MapModelToObject(profileModel));
            dbContext.SaveChanges();

        }

        public void InsertProfileByMail(ProfileModel profileModel, String email)
        {
            profileModel.Id = Guid.NewGuid();
            profileModel.Email = email;
            Console.WriteLine("S-a creat un profil nou cu guid:", profileModel.Id);
            dbContext.Profiles.Add(MapModelToObject(profileModel));
            dbContext.SaveChanges();

        }
        public ProfileModel GetProfileByName(string email)
        {

            return MapModelToObject(dbContext.Profiles.FirstOrDefault(x => x.Email == email));
        }
        public ProfileModel GetProfileById(Guid id)
        {

            return MapModelToObject(dbContext.Profiles.FirstOrDefault(x => x.Id == id));
        }


        public ProfileModel GetProfileById(string email)
        {

            return MapModelToObject(dbContext.Profiles.FirstOrDefault(x => x.Email.Equals(email)));
        }
        public ProfileModel MapModelToObject(Profile dbProfile)
        {
            ProfileModel profile = new ProfileModel();

            if (dbProfile != null)
            {
                profile.Id = dbProfile.Id;
                profile.FirstName = dbProfile.FirstName;
                profile.LastName = dbProfile.LastName;
                profile.DateOfBirth = dbProfile.DateOfBirth;
                profile.Gender = dbProfile.Gender;
                profile.Picture = dbProfile.Picture;
                profile.City = dbProfile.City;
                profile.Country = dbProfile.Country;
                profile.LookingFor = dbProfile.LookingFor;
                profile.Email = dbProfile.Email;

            }

            return profile;
        }

        public Profile MapModelToObject(ProfileModel dbProfile)
        {
            Profile profile = new Profile();

            if (dbProfile != null)
            {
                profile.Id = dbProfile.Id;
                profile.FirstName = dbProfile.FirstName;
                profile.LastName = dbProfile.LastName;
                profile.DateOfBirth = dbProfile.DateOfBirth;
                profile.Gender = dbProfile.Gender;
                profile.Picture = dbProfile.Picture;
                profile.City = dbProfile.City;
                profile.Country = dbProfile.Country;
                profile.LookingFor = dbProfile.LookingFor;
                profile.Email = dbProfile.Email;
            }

            return profile;
        }

        public void UpdateProfile(ProfileModel profileModel)
        {
            Profile existingProfile = dbContext.Profiles.FirstOrDefault(x => x.Id == profileModel.Id);
            if (existingProfile != null)
            {

                existingProfile.FirstName = profileModel.FirstName;
                existingProfile.LastName = profileModel.LastName;
                existingProfile.DateOfBirth = profileModel.DateOfBirth;
                existingProfile.Gender = profileModel.Gender;
                existingProfile.Picture = profileModel.Picture;
                existingProfile.City = profileModel.City;
                existingProfile.Country = profileModel.Country;
                existingProfile.LookingFor = profileModel.LookingFor;
                existingProfile.Email = profileModel.Email;
                dbContext.SaveChanges();

            }

        }

        public List<ProfileModel> GetAllProfiles()
        {
            List<ProfileModel> profileList = new List<ProfileModel>();
            foreach (Profile dbProfile in dbContext.Profiles)
            {
                profileList.Add(MapModelToObject(dbProfile));
            }
            return profileList;
        }

        internal PostModel GetPostByName(object likes)
        {
            throw new NotImplementedException();
        }


        //public List<ProfileModel> GetAllTheLikedProfileRecivedFor(string email)
        //{
        //    List<LikeModel> likesList = _repository.GetAllTheLikeRecivedFor(email);
        //    List<ProfileModel> profileList = new List<ProfileModel>();
        //    foreach (LikeModel dbLike in likesList)
        //    {
        //        profileList.Add(GetProfileByName(dbLike.Person));
        //    }

        //    return profileList;
        //}

        //public List<ProfileModel> GetAllTheLikeProfileFor(string email)
        //{
        //    List<LikeModel> likesList = _repository.GetAllTheLikedGivenFor(email);
        //    List<ProfileModel> profileList = new List<ProfileModel>();
        //    foreach (LikeModel dbLike in likesList)
        //    {
        //        profileList.Add(GetProfileByName(dbLike.Likes));
        //    }

        //    return profileList;
        //}
    }
}
