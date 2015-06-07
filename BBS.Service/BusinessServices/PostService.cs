using BBS.Domain.Abstract;
using BBS.Domain.Entities;
using BBS.Service.BusinessInterfaces;
using BBS.Service.BusinessServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.BusinessServices
{
    public class PostService: BaseService, IPostService
    {
        private IPostRepository postRepository = null;
        public PostService()
        {
            this.postRepository = LoadRepository<IPostRepository>();
        }

        public IEnumerable<Post> GetPostsByBoard(int boardID)
        {
            using (var enumerator = postRepository.Find(post => post.BoardID == boardID).GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }

        public Post GetPostByID(int postID)
        {
            Post targetPost = postRepository.Find(post => post.ID == postID).FirstOrDefault();
            return targetPost;
        }

        public bool CreatePost(Post post)
        {
            if(post.UserID <= 0)
            {
                return false;
            }
            return postRepository.Create(post);
        }

        public IEnumerable<Post> GetPostByUser(int userID)
        {
            using(var enumerator = postRepository.Find(post => post.UserID == userID).
                OrderByDescending(post => post.PublishTime).
                GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}
