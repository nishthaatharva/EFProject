using FluentValidation;

namespace Application.CQRS.Commands
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator() {

            RuleFor(command => command.User)
                .NotNull()
                .WithMessage("User object cannot be null.");

            RuleFor(command => command.User.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required.")
                .MaximumLength(50)
                .WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(command => command.User.LastName)
                .NotEmpty()
                .WithMessage("LastName is required.")
                .MaximumLength(50)
                .WithMessage("Last Name cannot exceed 50 characters.");

            RuleFor(command => command.User.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");           

            RuleFor(command => command.User.ContactNo)
                .NotEmpty()
                .WithMessage("Contact Number is requires.");

            RuleFor(command => command.User.City)
                .NotEmpty()
                .WithMessage("City is required.")
                .MaximumLength(50)
                .WithMessage("City cannot exceed 50 characters.");

            RuleFor(command => command.User.Gender)
                .NotEmpty()
                .WithMessage("Gender is required.")
                .MaximumLength(10)
                .WithMessage("Gender cannot exceed 10 characters.");          

        }
    }
}
