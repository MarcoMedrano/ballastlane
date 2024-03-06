using Ballastlane.Domain.Exceptions.Base;

namespace Ballastlane.Domain.Exceptions;

public class NftNotFoundException : NotFoundException
{
    public NftNotFoundException(long id) : base($"The Nft with id '{id}' was not found.")
    {
    }
}