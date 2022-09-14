using copernicus_back.Entity;

namespace copernicus_back.Repository
{
    public class RepositorioContext : IRepository
    {
        private List<User> _users;

        private User _user;

        public List<User> getUsers()
        {
            return _users;
        }

        public async Task<User> getUserById()
        {

            return _user;
        }
    }
}
