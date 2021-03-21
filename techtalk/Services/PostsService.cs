


using System;
using System.Collections.Generic;
using techtalk.Models;
// using System;
// using techtalk.Models;
using techtalk.Repositories;

namespace techtalk.Services
{
    public class PostsService
    {
        private readonly PostsRepository _repo;
        private readonly CommentsRepository _cr;
        public PostsService(PostsRepository repo, CommentsRepository cr)
        {
            _repo = repo;
            _cr = cr;
        }

        public IEnumerable<Post> GetAll()
        {
            IEnumerable<Post> posts = _repo.GetAllPosts();
            return posts;
        }

        internal Post GetPostsById(int id)
        {
            Post post = _repo.GetById(id);
            if (post == null)
            {
                throw new Exception("Invalid Id");
            }
            return post;
        }

        internal Post Create(Post newPost)
        {
            newPost.Id = _repo.Create(newPost);
            return newPost;
        }

        internal Post Edit(Post updated, string id)
        {
            Post original = GetPostsById(updated.Id);
            if (original.CreatorId != id) { throw new Exception("Access Denied: You cannot edit items you did not create."); }
            updated.Title = updated.Title == null ? original.Title : updated.Title;
            updated.Body = updated.Body == null ? original.Body : updated.Body;
            updated.Img = updated.Img == null ? original.Img : updated.Img;
            return _repo.EditPost(updated);
        }


        internal string Delete(int id, string userId)
        {
            Post original = _repo.GetById(id);
            if (original == null) { throw new Exception("Invalid Id"); }
            if (original.CreatorId != userId) { throw new Exception("Access Denied: You do not own this post."); }
            _repo.Remove(id);
            return "Successfully Deleted";
        }
    }
}
