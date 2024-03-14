using FluentValidation;

namespace BallestLane.Business;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Id).NotEmpty();
        RuleFor(u => u.Nickname).NotEmpty();
    }
}
