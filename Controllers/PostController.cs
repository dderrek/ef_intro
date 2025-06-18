using EFGetStarted.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFGetStarted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly BloggingRepository bloggingRepository;
        private readonly BloggingService bloggingService;

        private readonly ILogger<PostController> logger;

        public PostController(
            BloggingRepository bloggingRepository,
            BloggingService bloggingService,
            ILogger<PostController> logger)
        {
            this.bloggingRepository = bloggingRepository;
            this.bloggingService = bloggingService;
            this.logger = logger;
        }

        [Route("list")]
        [HttpGet]
        public List<Post> GetPost()
        {
            return bloggingRepository.GetPosts();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddPost([FromBody] Post post)
        {
            try
            {
                bloggingService.AddPost(post);

                logger.LogInformation("Post successfully added: {@Post}", post);
                return Ok(new { success = true, message = "Post added successfully." });
            }
            catch (DbUpdateException dbEx)
            {
                logger.LogError("Database update failed while adding a post: {@dbEx}", dbEx);
                return StatusCode(500, new { success = false, message = "Database update failed." });
            }
            catch (Exception ex)
            {
                logger.LogError("An unexpected error occurred while adding a post: {@ex}", ex);
                return StatusCode(500, new { success = false, message = "An error occurred." });
            }
        }

        [Route("delete/{postId}")]
        [HttpDelete]
        public IActionResult DeletePost([FromRoute] int postId)
        {
            try
            {
                var deletionSuccessful = bloggingService.DeletePost(postId);
                return deletionSuccessful ?
                    Ok(deletionSuccessful) :
                    StatusCode(500, new { success = false, message = "An unexpected error occurred." }); ;
            }
            catch (DbUpdateException dbEx)
            {
                logger.LogError("Database update failed while deleting the post: {@dbEx}", dbEx);
                return StatusCode(500, new { success = false, message = "Database update failed." });
            }
            catch (Exception ex)
            {
                logger.LogError("An unexpected error occurred while deleting the post: {@ex}", ex);
                return StatusCode(500, new { success = false, message = "An error occurred." });
            }
        }
    }
}
