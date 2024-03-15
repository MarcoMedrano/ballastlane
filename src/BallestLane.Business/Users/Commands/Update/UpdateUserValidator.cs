using FluentValidation;

namespace BallestLane.Business;

public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(u => u.Id).NotEmpty();
    }
}
