using Microsoft.AspNetCore.Mvc;

namespace EFGetStarted
{
    [ApiController]
    [Route("post")]
    public class Controller : ControllerBase
    {
        private readonly BloggingRepository bloggingRepository;
        private readonly BloggingService bloggingService;

        public Controller(
            BloggingRepository bloggingRepository,
            BloggingService bloggingService)
        {
            this.bloggingRepository = bloggingRepository;
            this.bloggingService = bloggingService;
        }

        [HttpGet]
        [Route("list")]
        public List<Post> GetPosts()
        {
            return this.bloggingRepository.GetPosts();
        }

        [HttpGet]
        [Route("blogs")]
        public List<Blog> GetBlogs()
        {
            return this.bloggingRepository.GetBlogs();
        }

        [HttpPost]
        [Route("blogs")]
        public OkObjectResult AddBlog([FromBody] Blog blog)
        {
            this.bloggingService.AddBlog(blog);
            return Ok(true);
        }

        [HttpPost]
        [Route("add")]
        public OkObjectResult AddPost([FromBody] Post post)
        {
            this.bloggingService.AddPost(post);
            return Ok(true);
        }
    }
}
