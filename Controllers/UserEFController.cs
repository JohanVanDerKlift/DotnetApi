// using AutoMapper;
// using DotnetAPI.Data;
// using DotnetAPI.Dtos;
// using DotnetAPI.Models;
// using Microsoft.AspNetCore.Mvc;
//
// namespace DotnetAPI.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class UserEFController : ControllerBase
// {
//     private IUserRepository _userRepository;
//     private IMapper _mapper;
//     
//     public UserEFController(IUserRepository userRepository)
//     {
//         _userRepository = userRepository;
//         _mapper = new Mapper(new MapperConfiguration(cfg =>
//         {
//             cfg.CreateMap<UserToAddDto, User>();
//             cfg.CreateMap<UserSalary, UserSalary>();
//             cfg.CreateMap<UserJobInfo, UserJobInfo>();
//         }));
//     }
//
//     [HttpGet("GetUsers")]
//     // public IActionResult Test()
//     public IEnumerable<User> GetUsers()
//     {
//         IEnumerable<User> users = _userRepository.GetUsers();
//         return users;
//     }
//
//     [HttpGet("GetSingleUser/{userId}")]
//     // public IActionResult Test()
//     public User GetSingleUser(int userId)
//     {
//         return _userRepository.GetSingleUser(userId);
//     }
//
//     [HttpPut("EditUser")]
//     public IActionResult EditUser(User user)
//     {
//         User? userDb = _userRepository.GetSingleUser(user.UserId);
//         if (userDb != null)
//         {
//             userDb.Active = user.Active;
//             userDb.FirstName = user.FirstName;
//             userDb.LastName = user.LastName;
//             userDb.Email = user.Email;
//             userDb.Gender = user.Gender;
//             if (_userRepository.SaveChanges())
//             {
//                 return Ok();
//             }
//             
//             throw new Exception("Failed to update user");
//         }
//
//         throw new Exception(" Failed to get user");
//     }
//
//     [HttpPost("AddUser")]
//     public IActionResult AddUser(UserToAddDto user)
//     {
//         User userDb = _mapper.Map<User>(user);
//
//         _userRepository.AddEntity<User>(userDb);
//         if (_userRepository.SaveChanges())
//         {
//             return Ok();
//         }
//
//         throw new Exception(" Failed to add user");
//     }
//
//     [HttpDelete("DeleteUser/{userId}")]
//     public IActionResult DeleteUser(int userId)
//     {
//         User? userDb = _userRepository.GetSingleUser(userId);
//         if (userDb != null)
//         {
//             _userRepository.RemoveEntity<User>(userDb);
//             if (_userRepository.SaveChanges())
//             {
//                 return Ok();
//             }
//             
//             throw new Exception("Failed to delete user");
//         }
//
//         throw new Exception(" Failed to get user");
//     }
//     
//     [HttpGet("UserSalary/{userId}")]
//     // public IActionResult Test()
//     public UserSalary GetUserSalaryEf(int userId)
//     {
//         return _userRepository.GetSingleUserSalary(userId);
//     }
//     
//     [HttpPost("UserSalary")]
//     public IActionResult PostUserSalaryEf(UserSalary userSalaryForInsert)
//     {
//         _userRepository.AddEntity<UserSalary>(userSalaryForInsert);
//         if (_userRepository.SaveChanges())
//         {
//             return Ok();
//         }
//
//         throw new Exception("Adding UserSalary failed on save");
//     }
//
//     [HttpPut("UserSalary")]
//     public IActionResult PutUserSalaryEf(UserSalary userSalaryForUpdate)
//     {
//         UserSalary? userSalaryToUpdate = _userRepository.GetSingleUserSalary(userSalaryForUpdate.UserId);
//         
//         if (userSalaryToUpdate != null)
//         {
//             _mapper.Map(userSalaryForUpdate, userSalaryToUpdate);
//             
//             if (_userRepository.SaveChanges())
//             {
//                 return Ok();
//             }
//             
//             throw new Exception("Updating UserSalary failed on save");
//             
//         }
//
//         throw new Exception(" Failed to get user");
//
//     }
//
//     
//
//     [HttpDelete("UserSalary/{userId}")]
//     public IActionResult DeleteUserSalary(int userId)
//     {
//         UserSalary? userSalaryToDelete = _userRepository.GetSingleUserSalary(userId);
//         if (userSalaryToDelete != null)
//         {
//             _userRepository.RemoveEntity<UserSalary>(userSalaryToDelete);
//             if (_userRepository.SaveChanges())
//             {
//                 return Ok();
//             }
//             
//             throw new Exception("Deleting UserSalary failed on save");
//             
//         }
//
//         throw new Exception(" Failed to find UserSalary to delete");
//     }
//     
//     [HttpGet("UserJobInfo/{userId}")]
//     // public IActionResult Test()
//     public UserJobInfo GetUserJobInfoEf(int userId)
//     {
//         return _userRepository.GetSingleUserJobInfo(userId);
//     }
//     
//     [HttpPost("UserJobInfo")]
//     public IActionResult PostUserJobInfoEf(UserJobInfo userJobInfoForInsert)
//     {
//         _userRepository.AddEntity<UserJobInfo>(userJobInfoForInsert);
//         if (_userRepository.SaveChanges())
//         {
//             return Ok();
//         }
//
//         throw new Exception("Adding UserJobInfo failed on save");
//     }
//
//     [HttpPut("UserJobInfo")]
//     public IActionResult PutUserJobInfoEf(UserJobInfo userJobInfoForUpdate)
//     {
//         UserJobInfo? userJobInfoToUpdate = _userRepository.GetSingleUserJobInfo(userJobInfoForUpdate.UserId);
//         
//         if (userJobInfoForUpdate != null)
//         {
//             _mapper.Map(userJobInfoForUpdate, userJobInfoToUpdate);
//             
//             if (_userRepository.SaveChanges())
//             {
//                 return Ok();
//             }
//             
//             throw new Exception("Updating UserJobInfo failed on save");
//             
//         }
//
//         throw new Exception(" Failed to get UserJobInfo");
//
//     }
//
//     
//
//     [HttpDelete("UserJobInfo/{userId}")]
//     public IActionResult DeleteUserJobInfo(int userId)
//     {
//         UserJobInfo? userJobInfoToDelete = _userRepository.GetSingleUserJobInfo(userId);
//         if (userJobInfoToDelete != null)
//         {
//             _userRepository.RemoveEntity<UserJobInfo>(userJobInfoToDelete);
//             if (_userRepository.SaveChanges())
//             {
//                 return Ok();
//             }
//             
//             throw new Exception("Deleting UserJobInfo failed on save");
//             
//         }
//
//         throw new Exception(" Failed to find UserJobInfo to delete");
//     }
// }
//
