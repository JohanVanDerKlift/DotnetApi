using AutoMapper;
using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    DataContextEF _entityFramework;
    private IMapper _mapper;
    
    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
        _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserToAddDto, User>();
            cfg.CreateMap<UserSalary, UserSalary>();
            cfg.CreateMap<UserJobInfo, UserJobInfo>();
        }));
    }

    [HttpGet("GetUsers")]
    // public IActionResult Test()
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = _entityFramework.Users.ToList();
        return users;
    }

    [HttpGet("GetSingleUser/{userId}")]
    // public IActionResult Test()
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

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        User? userDb = _entityFramework.Users
            .FirstOrDefault(u => u.UserId == user.UserId);
        if (userDb != null)
        {
            userDb.Active = user.Active;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;
            userDb.Gender = user.Gender;
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            
            throw new Exception("Failed to update user");
            
        }

        throw new Exception(" Failed to get user");

    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserToAddDto user)
    {
        User userDb = _mapper.Map<User>(user);

        _entityFramework.Add(userDb);
        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok();
        }

        throw new Exception(" Failed to add user");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        User? userDb = _entityFramework.Users
            .FirstOrDefault(u => u.UserId == userId);
        if (userDb != null)
        {
            _entityFramework.Users.Remove(userDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            
            throw new Exception("Failed to delete user");
            
        }

        throw new Exception(" Failed to get user");
    }
    
    [HttpGet("UserSalary/{userId}")]
    // public IActionResult Test()
    public IEnumerable<UserSalary> GetUserSalaryEf(int userId)
    {
        return _entityFramework.UserSalary
            .Where(u => u.UserId == userId)
            .ToList();
    }
    
    [HttpPost("UserSalary")]
    public IActionResult PostUserSalaryEf(UserSalary userSalaryForInsert)
    {
        _entityFramework.UserSalary.Add(userSalaryForInsert);
        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok();
        }

        throw new Exception("Adding UserSalary failed on save");
    }

    [HttpPut("UserSalary")]
    public IActionResult PutUserSalaryEf(UserSalary userSalaryForUpdate)
    {
        UserSalary? userSalaryToUpdate = _entityFramework.UserSalary
            .FirstOrDefault(u => u.UserId == userSalaryForUpdate.UserId);
        
        if (userSalaryToUpdate != null)
        {
            _mapper.Map(userSalaryForUpdate, userSalaryToUpdate);
            
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            
            throw new Exception("Updating UserSalary failed on save");
            
        }

        throw new Exception(" Failed to get user");

    }

    

    [HttpDelete("Usersalary/{userId}")]
    public IActionResult DeleteUserSalary(int userId)
    {
        UserSalary? userSalaryToDelete = _entityFramework.UserSalary
            .FirstOrDefault(u => u.UserId == userId);
        if (userSalaryToDelete != null)
        {
            _entityFramework.UserSalary.Remove(userSalaryToDelete);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            
            throw new Exception("Deleting UserSalary failed on save");
            
        }

        throw new Exception(" Failed to find UserSalary to delete");
    }
    
    [HttpGet("UserJobInfo/{userId}")]
    // public IActionResult Test()
    public IEnumerable<UserJobInfo> GetUserJobInfoEf(int userId)
    {
        return _entityFramework.UserJobInfo
            .Where(u => u.UserId == userId)
            .ToList();
    }
    
    [HttpPost("UserJobInfo")]
    public IActionResult PostUserJobInfoEf(UserJobInfo userJobInfoForInsert)
    {
        _entityFramework.UserJobInfo.Add(userJobInfoForInsert);
        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok();
        }

        throw new Exception("Adding UserJobInfo failed on save");
    }

    [HttpPut("UserJobInfo")]
    public IActionResult PutUserJobInfoEf(UserJobInfo userJobInfoForUpdate)
    {
        UserJobInfo? userJobInfoToUpdate = _entityFramework.UserJobInfo
            .FirstOrDefault(u => u.UserId == userJobInfoForUpdate.UserId);
        
        if (userJobInfoForUpdate != null)
        {
            _mapper.Map(userJobInfoForUpdate, userJobInfoToUpdate);
            
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            
            throw new Exception("Updating UserJobInfo failed on save");
            
        }

        throw new Exception(" Failed to get UserJobInfo");

    }

    

    [HttpDelete("UserJobInfo/{userId}")]
    public IActionResult DeleteUserJobInfo(int userId)
    {
        UserJobInfo? userJobInfoToDelete = _entityFramework.UserJobInfo
            .FirstOrDefault(u => u.UserId == userId);
        if (userJobInfoToDelete != null)
        {
            _entityFramework.UserJobInfo.Remove(userJobInfoToDelete);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            
            throw new Exception("Deleting UserJobInfo failed on save");
            
        }

        throw new Exception(" Failed to find UserJobInfo to delete");
    }
}

