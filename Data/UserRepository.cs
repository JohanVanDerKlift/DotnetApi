using AutoMapper;
using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public class UserRepository : IUserRepository
    {
        DataContextEF _entityFramework;
        private IMapper _mapper;

        public UserRepository(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);
        }

        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }

        // public bool AddEntity<T>(T entityToAdd)
        public void AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);
                // return true;
            }
            // return false;
        }
        
        // public bool AddEntity<T>(T entityToAdd)
        public void RemoveEntity<T>(T entityToRemove)
        {
            if (entityToRemove != null)
            {
                _entityFramework.Remove(entityToRemove);
                // return true;
            }
            // return false;
        }
        
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _entityFramework.Users.ToList();
            return users;
        }
        
        public UserSalary GetSingleUserSalary(int userId)
        {
            UserSalary? userSalary = _entityFramework.UserSalary
                .FirstOrDefault(u => u.UserId == userId);
            if (userSalary != null)
            {
                return userSalary;
            }

            throw new Exception("Failed to get userSalary");
        }
        
        public User GetSingleUser(int userId)
        {
            User? user = _entityFramework.Users
                .FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                return user;
            }

            throw new Exception("Failed to get user");
        }
        
        public UserJobInfo GetSingleUserJobInfo(int userId)
        {
            UserJobInfo? userJobInfo = _entityFramework.UserJobInfo
                .FirstOrDefault(u => u.UserId == userId);
            if (userJobInfo != null)
            {
                return userJobInfo;
            }

            throw new Exception("Failed to get userJobInfo");
        }
    }
}

