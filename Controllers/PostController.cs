using EFGetStarted.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFGetStarted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly BloggingRepository bloggingRepository;

        public PostController(BloggingRepository bloggingRepository)
        {
            this.bloggingRepository = bloggingRepository;
        }

        [Route("list")]
        public List<Post> GetPost()
        {
            return this.bloggingRepository.GetPosts();
        }
    }
}
