using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserJobInfoController : ControllerBase
{
    private DataContextDapper _dapper;
    
    public UserJobInfoController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsersJobInfo")]
    // public IActionResult Test()
    public IEnumerable<UserJobInfo> GetUsersJobInfo()
    {
        string sql = @"
            SELECT [UserId],
                [JobTitle],
                [Department]
            FROM TutorialAppSchema.UserJobInfo
        ";
        IEnumerable<UserJobInfo> usersJobInfo = _dapper.LoadData<UserJobInfo>(sql);
        return usersJobInfo;
    }

    [HttpGet("GetSingleUserJobInfo/{userId}")]
    // public IActionResult Test()
    public UserJobInfo GetSingleUserJobInfo(int userId)
    {
        string sql = @"
            SELECT [UserId],
                [JobTitle],
                [Department] 
            FROM TutorialAppSchema.UserJobInfo
            WHERE UserId = " + userId.ToString();
        UserJobInfo userJobInfo = _dapper.LoadDataSingle<UserJobInfo>(sql);
        return userJobInfo;
    }

    [HttpPut("EditUserJobInfo")]
    public IActionResult EditUserJobInfo(UserJobInfo userJobInfo)
    {
        string sql = @"
        UPDATE TutorialAppSchema.UserJobInfo
            SET [JobTitle] = '" + userJobInfo.JobTitle +
                "', [Department] = '" + userJobInfo.Department +
            "' WHERE UserId = " + userJobInfo.UserId;
        Console.WriteLine(sql);
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to update userJobInfo");
    }

    [HttpPost("AddUserJobInfo")]
    public IActionResult AddUserJobInfo(UserJobInfoToAddDto userJobInfo)
    {
        string sql = @"INSERT INTO TutorialAppSchema.UserJobInfo(
                [JobTitle],
                [Department] 
            ) VALUES (" +
                "'" + userJobInfo.JobTitle +
                "', '" + userJobInfo.Department +
            "')";
        
        Console.WriteLine(sql);
        
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to add userJobInfo");
    }

    [HttpDelete("DeleteUserJobInfo/{userId}")]
    public IActionResult DeleteUserJobInfo(int userId)
    {
        string sql = @"DELETE FROM TutorialAppSchema.UserJobInfo
                        WHERE UserId = " + userId.ToString();
        
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to delete userJobInfo");
    }
}

