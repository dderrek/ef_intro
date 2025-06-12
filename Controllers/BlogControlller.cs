using EFGetStarted.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFGetStarted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BloggingRepository bloggingRepository;

        public BlogController(BloggingRepository bloggingRepository)
        {
            this.bloggingRepository = bloggingRepository;
        }

        [Route("list")]
        public List<Blog> GetBlogs()
        {
            return this.bloggingRepository.GetBlogs();
        }
    }
}
