public interface IPostService
{
    List<PostDto> GetPosts();
    PostDto GetPostById(int id);
    PostDto CreatePost(PostDto postDto);
    PostDto UpdatePost(int id, PostDto postDto);
    void DeletePost(int id);
}