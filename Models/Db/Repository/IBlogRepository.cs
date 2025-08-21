namespace ASP_MVC.Models.Db.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();

        Task AddRequest(Request request);

        Task<Request[]> GetRequests();
    }
}
