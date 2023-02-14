
using DattingApp_FinalApp.Data;
using DattingApp_FinalApp.Models.DBObjects;
using DattingApp_FinalApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DattingApp_FinalApp.Repository
{

    public class PostRepository
    {
        public ApplicationDbContext dbContext;
        public PostRepository(ApplicationDbContext context)
        {
            dbContext = context;

        }

        public void InsertPost(PostModel postModel)
        {
            postModel.Id = Guid.NewGuid();
            dbContext.Posts.Add(MapModelToObject(postModel));
            dbContext.SaveChanges();

        }

        public void InsertPostByMail(PostModel postModel, String email)
        {
            postModel.Id = Guid.NewGuid();
            postModel.UserEmail = email;
            Console.WriteLine("S-a creat un profil noude catre:", postModel.UserEmail);
            dbContext.Posts.Add(MapModelToObject(postModel));
            dbContext.SaveChanges();

        }

     
        public PostModel GetPostById(Guid id)
        {

            return MapModelToObject(dbContext.Posts.FirstOrDefault(x => x.Id == id));
        }
        public PostModel MapModelToObject(Post dbPost)
        {
            PostModel post = new PostModel();

            if (dbPost != null)
            {
                post.Id = dbPost.Id;
                post.About = dbPost.About;
                post.UserEmail = dbPost.UserEmail;
                post.Photo = dbPost.Photo;

            }

            return post;
        }

        public Post MapModelToObject(PostModel dbPost)
        {
            Post post = new Post();

            if (dbPost != null)
            {
                post.Id = dbPost.Id;
                post.About = dbPost.About;
                post.UserEmail = dbPost.UserEmail;
                post.Photo = dbPost.Photo;

            }
            return post;
        }

        public void UpdatePost(PostModel postModel)
        {
            Post existingPost = dbContext.Posts.FirstOrDefault(x => x.Id == postModel.Id);
            if (existingPost != null)
            {

                existingPost.About = postModel.About;
                existingPost.UserEmail = postModel.UserEmail;
                existingPost.Photo = postModel.Photo;
                dbContext.SaveChanges();

            }

        }

        public List<PostModel> GetAllPost()
        {
            List<PostModel> postsList = new List<PostModel>();
            foreach (Post dbPost in dbContext.Posts)
            {
                postsList.Add(MapModelToObject(dbPost));
            }
            return postsList;
        }

        public List<PostModel> GetAllPostFor(string email)
        {
            List<PostModel> postsList = new List<PostModel>();
            foreach (Post dbPost in dbContext.Posts)
            {
                if (dbPost.UserEmail.Equals(email))
                    postsList.Add(MapModelToObject(dbPost));
            }
            return postsList;
        }



    }
}