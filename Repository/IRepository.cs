using copernicus_back.Entity;

namespace copernicus_back.Repository
{
    public interface IRepository
    {
        List<User> getUsers();
        Task<User> getUserById();
    }
}
