using Podium.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Podium.Data
{
    public interface IUser
    {
        User GetUser(int id);
        int AddUser(User user);
    }
    public class InMemoryUser : IUser
    {
        private readonly List<User> _users;
        public InMemoryUser()
        {
            _users = new List<User>();
        }

        public User GetUser(int id)
        {
            return _users
                .Select(x => new User { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, DOB = x.DOB, Email = x.Email }) // Creating DTO
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public int AddUser(User user)
        {
            // This must be perform on database 
            int id = 1;
            if (_users.Count != 0)
                id = _users.Max(x => x.Id) + 1;
            user.Id = id;
            _users.Add(user);
            return id;
        }
    }
}
