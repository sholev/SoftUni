namespace EducationSystem.Data
{
    using System.Collections.Generic;

    using EducationSystem.Model;

    public class UsersRepository : Repository<User>
    {
        private readonly Dictionary<string, User> usersByUsername;

        public UsersRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            if (this.usersByUsername.ContainsKey(username))
            {
                return this.usersByUsername[username];
            }

            return null;
        }

        public override void Add(User user)
        {
            this.usersByUsername.Add(user.UserName, user);

            base.Add(user);
        }
    }
}
