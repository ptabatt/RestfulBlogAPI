using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize] // This attribute requires authentication for all actions in this controller
[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    IPostService _postService;
    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public IActionResult GetPosts()
    {
        var posts = _postService.GetPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public IActionResult GetPostById(int id)
    {
        var post = _postService.GetPostById(id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] PostDto postDto)
    {
        _postService.CreatePost(postDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePost(int id, [FromBody] PostDto postDto)
    {
        var updatedPost = _postService.UpdatePost(id, postDto);
        if (updatedPost == null)
        {
            return NotFound();
        }
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePost(int id)
    {
        _postService.DeletePost(id);
        return NoContent();
    }
}
