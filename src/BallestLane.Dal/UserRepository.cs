
using System.Data;
using Microsoft.Data.SqlClient;

namespace BallestLane.Dal;

public class UserRepository(IConfiguration config) : IUserRepository
{
    public async Task<User> GetById(string id)
    {
        using var connection = new SqlConnection(config["Database:ConnectionString"]);
        await connection.OpenAsync();

        using var command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
        command.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar) { Value = id });

        using var reader = await command.ExecuteReaderAsync();
        return await reader.ReadAsync() ? MapUserFromReader(reader) : null;
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(User entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    private User MapUserFromReader(SqlDataReader reader)
    {
        return new User
        {
            Id = reader["Id"].ToString(),
            NickName = reader["NickName"].ToString(),
            ProfilePicture = reader["ProfilePicture"].ToString()
        };
    }
}