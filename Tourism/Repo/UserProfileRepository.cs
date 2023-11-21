// UserProfileRepository.cs
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tourism.Context;
using Tourism.Model;

public class UserProfileRepository
{
    private readonly ApplicationDbContext _context;

    public UserProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserProfile> GetUserProfile(Guid userId)
    {
        var userProfiles = await _context.UserProfiles
            .FromSqlRaw("EXEC [dbo].[GetUserProfile] @UserId = {0}", userId)
            .ToListAsync();

        return userProfiles.FirstOrDefault();
    }

    public async Task InsertUserProfile(Guid userId, string username, string firstname, string lastname, string password, string email)
    {
        await _context.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[InsertUserProfile] @UserId, @Username, @Firstname, @Lastname, @Password, @Email",
            new SqlParameter("@UserId", userId),
            new SqlParameter("@Username", username),
            new SqlParameter("@Firstname", firstname),
            new SqlParameter("@Lastname", lastname),
            new SqlParameter("@Password", password),
            new SqlParameter("@Email", email));
    }
}
