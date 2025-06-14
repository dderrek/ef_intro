using EFGetStarted.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFGetStarted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BloggingRepository bloggingRepository;
        private readonly BloggingService bloggingService;
        private readonly ILogger<BlogController> logger;

        public BlogController(
            BloggingRepository bloggingRepository,
            BloggingService bloggingService,
            ILogger<BlogController> logger)
        {
            this.bloggingRepository = bloggingRepository;
            this.bloggingService = bloggingService;
            this.logger = logger;
        }

        [Route("list")]
        [HttpGet]
        public List<Blog> GetBlogs()
        {
            return bloggingRepository.GetBlogs();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddBlog([FromBody] Blog blog)
        {
            try
            {
                bloggingService.AddBlog(blog);

                logger.LogInformation("Blog successfully added: {@Blog}", blog);
                return Ok(new { success = true, message = "Blog added successfully." });
            }
            catch (DbUpdateException dbEx)
            {
                logger.LogError("Database update failed while adding a blog: {@dbEx}", dbEx);
                return StatusCode(500, new { success = false, message = "Database update failed." });
            }
            catch (Exception ex)
            {
                logger.LogError("An unexpected error occurred while adding a blog: {@ex}", ex);
                return StatusCode(500, new { success = false, message = "An error occurred." });
            }
        }
    }
}
