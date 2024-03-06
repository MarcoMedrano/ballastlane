using Ballastlane.Domain.Exceptions.Base;

namespace Ballastlane.Domain.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string id) : base($"The User with id '{id}' was not found.")
    {
    }
}