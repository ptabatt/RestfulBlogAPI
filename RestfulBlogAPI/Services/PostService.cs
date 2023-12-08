public class PostService : IPostService
{
    private readonly ApplicationDbContext _context;

    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<PostDto> GetPosts()
    {
        // Implement logic to retrieve a list of all blog posts from the database
        var posts = _context.Posts.Select(p => new PostDto { Title = p.Title, Content = p.Content }).ToList();
        return posts;
    }

    public PostDto GetPostById(int id)
    {
        // Implement logic to retrieve a specific blog post by ID from the database
        var post = _context.Posts.Where(p => p.Id == id)
                                  .Select(p => new PostDto { Title = p.Title, Content = p.Content })
                                  .FirstOrDefault();
        return post;
    }

    public PostDto CreatePost(PostDto postDto)
    {
        // Implement logic to create a new blog post in the database
        var newPost = new Post { Title = postDto.Title, Content = postDto.Content };
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return new PostDto { Title = newPost.Title, Content = newPost.Content };
    }

    public PostDto UpdatePost(int id, PostDto postDto)
    {
        // Implement logic to update an existing blog post by ID in the database
        var existingPost = _context.Posts.Find(id);
        if (existingPost != null)
        {
            existingPost.Title = postDto.Title;
            existingPost.Content = postDto.Content;
            _context.SaveChanges();
            return new PostDto { Title = existingPost.Title, Content = existingPost.Content };
        }
        return null;
    }

    public void DeletePost(int id)
    {
        // Implement logic to delete a blog post by ID from the database
        var postToDelete = _context.Posts.Find(id);
        if (postToDelete != null)
        {
            _context.Posts.Remove(postToDelete);
            _context.SaveChanges();
        }
    }
}