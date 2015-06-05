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
            IEnumerable<Post> targetPosts = postRepository.Find(post => post.BoardID == boardID);
            return targetPosts;
        }

        public Post GetPostByID(int postID)
        {
            Post targetPost = postRepository.Find(post => post.ID == postID).FirstOrDefault();
            return targetPost;
        }
    }
}
