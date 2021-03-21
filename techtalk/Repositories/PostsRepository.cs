

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using techtalk.Models;

namespace techtalk.Repositories
{
    public class PostsRepository
    {
        private readonly IDbConnection _db;
        public PostsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Post> GetAllPosts()
        {
            string sql = @"
            SELECT 
            p.*,
            pro.*
            FROM posts p
            JOIN profiles pro ON p.CreatorId = pro.id
            ;";
            return _db.Query<Post, Profile, Post>(sql, (post, profile) =>
            {
                post.Creator = profile;
                return post;

            }, splitOn: "id");
        }

        internal Post GetById(int id)
        {
            string sql = @"
            SELECT 
            p.*,
            pro.*
            FROM posts p
            JOIN profiles pro ON p.creatorId = pro.id
            WHERE p.id = @id;";
            return _db.Query<Post, Profile, Post>(sql, (post, profile) =>
            {
                post.Creator = profile;
                return post;

            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal IEnumerable<PostCommentModel> GetCommentsByPostId(int id)
        {
            string sql = @"
            SELECT
            p.*,
            pc.id as PostCommentId,
            pro.*
            FROM postcomments pc
            JOIN posts p ON p.id = pc.postId
            JOIN profiles pro ON p.creatorId = pro.id
            WHERE commentId = @id
            ";
            return _db.Query<PostCommentModel, Profile, PostCommentModel>(sql, (post, profile) =>
            {
                post.Creator = profile;
                return post;
            }, new { id }, splitOn: "id");
        }

        internal int Create(Post newPost)
        {
            string sql = @"
            INSERT INTO posts
            (title, body, img, views, shares, saves, creatorId)
            VALUES
            (@Title, @Body, @Img, @Views, @Shares, @Saves, @CreatorId);
            SELECT LAST_INSERT_ID()";
            return _db.ExecuteScalar<int>(sql, newPost);
        }
        internal Post EditPost(Post updated)
        {
            string sql = @"
            UPDATE posts
            SET
            title = @Title,
            body = @Body,
            img = @Img
            WHERE id = @Id;";
            _db.Execute(sql, updated);
            return updated;
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM posts WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

    }
}